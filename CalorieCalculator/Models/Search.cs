using System;

namespace CalorieCalculator
{
	public class Search
	{
		public string Name { get; set; }
		public string Text { get; set; }

		public Search () : this ("")
		{
		}

		public Search (string name) {
			Name = name;
			Text = "";
		}
	}
}

