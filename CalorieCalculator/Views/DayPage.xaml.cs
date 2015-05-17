using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CalorieCalculator
{
	public partial class DayPage : ContentPage
	{
		public DayPage ()
		{
			InitializeComponent ();
			var viewmodel = new DayPageModel();
			this.BindingContext = viewmodel;
		}

		public void OnButtonClicked(object sender, EventArgs args) {
			Navigation.PushAsync (new FoodListPage ("breakfast"));
		}
	}
}

