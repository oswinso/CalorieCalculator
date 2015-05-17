using System.Collections.ObjectModel;


namespace CalorieCalculator
{	
	public class FoodListViewModel
	{
		public ObservableCollection<Food> Foods { get; set; }
		Search search;

		public FoodListViewModel (Search search) {
			Foods = new ObservableCollection<Food> ();
			this.search = search;

			var foodDB = App.FoodDB.GetItems ();
			foreach (var food in foodDB) {
				Foods.Add (food);
			}
		}

		public void Search () {
			Foods.Clear ();
			var foodDB = App.FoodDB.GetItemsSearch (SearchText);
			foreach (var food in foodDB) {
				Foods.Add (food);
			}
		}

		public string SearchText {
			get { return search.Text; }
			set { search.Text = value ?? ""; }
		}

	}
}

