using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CalorieCalculator
{
	public partial class DayPage : ContentPage
	{
		private DayViewModel viewmodel;
		public DayPage ()
		{
			InitializeComponent ();
			viewmodel = new DayViewModel();
			this.BindingContext = viewmodel;
		}

		public void OnButtonClicked(object sender, EventArgs args) {
			Navigation.PushAsync (new FoodListPage ("breakfast"));
		}

		public void update() {
			viewmodel.update ();
		}

		public void OnItemSelected(object sender, ItemTappedEventArgs args) {
			FoodRecord record = args.Item as FoodRecord;
			Food food = App.FoodDB.GetFoodFromRecord (record);
			if (food == null)
				return;

			Navigation.PushAsync (new FoodSummaryPage (new FoodViewModel (food), record));
			//Reset the selected item
			recordList.SelectedItem = null;
		}
	}
}

