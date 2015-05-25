using System.Collections.ObjectModel;
using System.Collections.Generic;
using Xamarin.Forms;


namespace CalorieCalculator
{	
	public class FoodListViewModel
	{
		public ObservableCollection<Food> Foods { get; set; }
		IEnumerable<Food> foodDB;
		Search search;
		public int _index;

		public FoodListViewModel (Search search) {
			Foods = new ObservableCollection<Food> ();
			this.search = search;
			Index = -1;
		}

		public void Search () {
			// If It isn't the first time loading into the foodlist view.
			if (Index != -1) {
				// If user enters something into search.
				if (SearchText.Length > 0) {
					// If the category isn't "all", search using query and foodgroup
					if (Index == 0) {
						foodDB = App.FoodDB.GetItemsSearchName (SearchText);
					} else {
						foodDB = App.FoodDB.GetItemsSearch (SearchText, FoodGroup.getKeyFromIndex (Index));
					}
				// If user doesn't enter anything into search, search only using foodgroup
				} else {
					// If category is all, display all
					if (Index == 0) {
						foodDB = App.FoodDB.GetItems ();
					} else {
						foodDB = App.FoodDB.GetItemsSearchGroup (FoodGroup.getKeyFromIndex (Index));
					}
				}
				// Clear food, and place all of query into food. 
				Foods.Clear ();
				foreach (var food in foodDB) {
					Foods.Add (food);
				}
			}
		}

		public int Index {
			get { return _index; }
			set { _index = value; }
		}

		public string SearchText {
			get { return search.Text; }
			set { search.Text = value ?? ""; }
		}
	}
}

