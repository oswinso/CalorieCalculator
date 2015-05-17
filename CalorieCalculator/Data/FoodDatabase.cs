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

		public IEnumerable<Food> GetItemsSearch (String query)
		{
			if (query.Length > 0) {
				lock (locker) {
					return database.Query<Food> ("SELECT * FROM food WHERE Name LIKE \"" + query+"%\"");
				}
			}
			return GetItems ();
		}
	}
}

