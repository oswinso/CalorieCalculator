using System;
using SQLite;

namespace CalorieCalculator
{
	public class FoodGroup {
		[PrimaryKey]
		public string ID { get; set; }
		public string Description { get; set; }
	}
}

