using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CalorieCalculator
{
	public partial class FoodListPage : ContentPage
	{
		private Search search;
		private FoodListViewModel viewmodel;
		private string meal;

		public FoodListPage (string meal)
		{
			InitializeComponent ();

			search = new Search();
			viewmodel = new FoodListViewModel(search);
			this.meal = meal;
			this.BindingContext = viewmodel;
		}

		public void OnItemSelected(object sender, ItemTappedEventArgs args) {
			var food = args.Item as Food;
			if (food == null)
				return;

			Navigation.PushAsync (new FoodSummaryPage (new FoodViewModel (food), meal));
			//Reset the selected item
			foodList.SelectedItem = null;
		}

		private void OnValueChanged (object sender, TextChangedEventArgs e) {
			viewmodel.Search();
		}

		private void OnSelectedIndexChanged(object sender, EventArgs args) {
			viewmodel.Search();
			foodList.ScrollTo (viewmodel.Foods [0], ScrollToPosition.Start, false);
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged ();
			this.picker.Items.Clear ();
			picker.Items.Add ("All");
			foreach (KeyValuePair<string, string> group in FoodGroup.foodGroup) {
				picker.Items.Add (group.Value);
			}
		}
	}
}

