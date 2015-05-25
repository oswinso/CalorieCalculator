using SQLite;
using SQLiteNetExtensions.Attributes;

namespace CalorieCalculator
{
	public class Food
	{
		[PrimaryKey, AutoIncrement]
		public int id { get; set; }
		public string Name { get; set; }
		public string FoodGroup { get; set; }
		public int Calories { get; set; }
		public float Protein { get; set; }
		public float TotalFat { get; set; }
		public float Carbohydrates { get; set; }
		public float Fiber { get; set; }
		public float Sugar { get; set; }
		public int Calcium { get; set; }
		public int Sodium { get; set; }
		public float SatFat { get; set; }
		public float Cholesterol { get; set; }
	}
}

