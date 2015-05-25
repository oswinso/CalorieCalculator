using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using CalorieCalculator;

namespace CalorieCalculator
{
	public class FoodDatabase
	{
		static object locker = new object ();

		SQLiteConnection database;

		/// <summary>
		/// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
		/// if the database doesn't exist, it will create the database and all the tables.
		/// </summary>
		/// <param name='path'>
		/// Path.
		/// </param>
		public FoodDatabase()
		{
			database = DependencyService.Get<ISQLite> ().GetConnection ();
			// create the tables
			database.CreateTable<Food>();
		}

		public IEnumerable<Food> GetItems ()
		{
			lock (locker) {
				return (from i in database.Table<Food>() select i).ToList();
			}
		}

		public IEnumerable<Food> GetItemsSearch (String name, String group)
		{
			lock (locker) {
				String query = "SELECT * FROM food WHERE Name LIKE \"%" + name + "%\" AND FOODGROUP LIKE \"" + group + "\"";
				System.Diagnostics.Debug.WriteLine (query);
				return database.Query<Food> (query);
			}
		}

		public IEnumerable<Food> GetItemsSearchName (String name)
		{
			lock (locker) {
				String query = "SELECT * FROM food WHERE Name LIKE \"%" + name + "%\"";
				System.Diagnostics.Debug.WriteLine (query);
				return database.Query<Food> (query);
			}
		}

		public IEnumerable<Food> GetItemsSearchGroup (String group)
		{
			lock (locker) {
				String query = "SELECT * FROM food WHERE FOODGROUP LIKE \"" + group + "\"";
				System.Diagnostics.Debug.WriteLine (query);
				return database.Query<Food> (query);
			}
		}

		public Food GetFoodFromRecord (FoodRecord record)
		{
			lock (locker) {
				return database.Get<Food> (record.FoodID);
			}
		}
	}
}

