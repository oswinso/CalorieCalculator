using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CalorieCalculator
{
	public partial class FoodSummaryPage : ContentPage
	{
		private string meal;
		private FoodViewModel viewmodel;
		public FoodSummaryPage (FoodViewModel foodViewModel, string meal)
		{
			InitializeComponent ();
			this.meal = meal;
			viewmodel = foodViewModel;
			this.BindingContext = viewmodel;
		}

		public void OnButtonClick(object sender, EventArgs args) {
			App.RecordDB.AddRecord (viewmodel.id, 0, 1, meal);
			Navigation.PopToRootAsync ();
		}
	}
}

