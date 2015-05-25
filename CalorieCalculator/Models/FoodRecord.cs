using System;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace CalorieCalculator
{
	public class FoodRecord
	{
		/*MeasurementType:
		 * 1 = 100g
		 * 2 = pound
		 * 3 = ounce
		 * 
		 * Meal:
		 * Breakfast, Lunch, Dinner
		 */

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		[ForeignKey(typeof(Food))]
		public int FoodID { get; set; }
		public string Name { get; set; }
		public int Calories { get; set; }
		public int MeasurementType { get; set; }
		public int Measurement { get; set; }
		public string Meal { get; set; }
	}
}

