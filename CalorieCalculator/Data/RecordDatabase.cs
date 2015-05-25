using System;
using SQLite;
using Xamarin.Forms;
using System.Collections.Generic;

namespace CalorieCalculator
{
	public class RecordDatabase
	{
		const float PoundConstant = 0.220462f;
		const float OunceConstant = 3.5274f;
		static object locker = new object();
		SQLiteConnection database;

		public RecordDatabase ()
		{
			database = DependencyService.Get<ISQLite> ().GetConnection ();
			database.CreateTable<FoodRecord> ();
		}

		public IEnumerable<FoodRecord> GetRecords (String meal)
		{
			lock (locker) {
				return database.Query<FoodRecord> ("SELECT * FROM foodrecord WHERE meal LIKE \""+meal+"\"");
			}
		}

		public void AddRecord(int foodID, string name, int measurementType, int measurement, string meal, int calories) {
			lock (locker) {
				database.Insert (new FoodRecord () {
					ID=1,
					FoodID = foodID,
					Name = name,
					MeasurementType = measurementType,
					Measurement = measurement,
					Meal = meal,
					Calories = (int)(measurementType==0?calories*measurement:
						measurementType==1?calories*measurement*PoundConstant:
						calories*measurement*OunceConstant)
				});
				App.dayPage.update ();
			}
		}

		public void UpdateRecord(int recordID, int foodID, string name, int measurementType, int measurement, string meal, int calories)
		{
			lock (locker) {
				var cal = (int)(measurementType == 0 ? calories * measurement :
					measurementType == 1 ? calories * measurement * PoundConstant :
					calories * measurement * OunceConstant);
				string query = "UPDATE foodrecord SET MeasurementType=\"" + measurementType + "\", Measurement=\"" + measurement +
					"\", Calories=\"" + cal + "\" WHERE ID=" + recordID;
				database.Execute (query);
			}
			App.dayPage.update ();
		}

		public void DeleteRecord(int recordID) {
			lock (locker) {
				String query = "DELETE FROM foodrecord WHERE id = \"" + recordID + "\"";
				database.Execute (query);
			}
			App.dayPage.update ();
		}



		public void clear() {
			database.DeleteAll<FoodRecord> ();
		}
	}
}

