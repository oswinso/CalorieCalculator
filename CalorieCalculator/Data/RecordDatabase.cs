using System;
using SQLite;
using Xamarin.Forms;
using System.Collections.Generic;

namespace CalorieCalculator
{
	public class RecordDatabase
	{
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
				return database.Query<FoodRecord> ("SELECT * FROM foodrecord WHERE meal = \""+meal+"\"");
			}
		}

		public void AddRecord(int foodID, int measurementType, int measurement, string meal) {
			lock (locker) {
				database.Insert (new FoodRecord () {
					id=1,
					FoodID = foodID,
					MeasurementType = measurementType,
					Measurement = measurement,
					Meal = meal,
					Calories = 1337
				});
				var a = database.Query<FoodRecord> ("SELECT * FROM foodrecord");
				System.Diagnostics.Debug.WriteLine (a[0].FoodID);
			}
		}
	}
}

