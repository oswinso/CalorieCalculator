using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CalorieCalculator
{
	public partial class FoodSummaryPage : ContentPage
	{
		private string meal;
		private int recordID;
		private FoodViewModel viewmodel;
		public string ButtonName;

		public FoodSummaryPage (FoodViewModel foodViewModel, string meal)
		{
			InitializeComponent ();
			this.meal = meal;
			viewmodel = foodViewModel;
			viewmodel.ButtonName = "Add to Foods";
			this.BindingContext = viewmodel;
			recordID = -1;
			viewmodel.QuantityIndex = 0;
			viewmodel.MeasurementIndex = 0;
			SaveButton.IsVisible = false;
		}
		public FoodSummaryPage (FoodViewModel foodViewModel, FoodRecord record)
		{
			InitializeComponent ();
			this.recordID = record.ID;
			viewmodel = foodViewModel;
			viewmodel.ButtonName = "Remove from Foods";
			this.BindingContext = viewmodel;
			viewmodel.QuantityIndex = record.Measurement - 1;
			viewmodel.MeasurementIndex = record.MeasurementType;
		}

		public void OnButtonClick(object sender, EventArgs args) {
			if (recordID == -1) {
				App.RecordDB.AddRecord (viewmodel.ID, viewmodel.Name, viewmodel.MeasurementIndex, viewmodel.QuantityIndex+1, meal, viewmodel.Calories);
			} else {
				App.RecordDB.DeleteRecord (recordID);
			}
			Navigation.PopToRootAsync ();
		}

		public void OnSaveButtonClick(object sender, EventArgs args) {
			App.RecordDB.UpdateRecord (recordID, viewmodel.ID, viewmodel.Name, viewmodel.MeasurementIndex, viewmodel.QuantityIndex+1, meal, viewmodel.Calories);
			Navigation.PopToRootAsync ();
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged ();
			QuantityPicker.Items.Clear ();
			for (int i = 1; i < 10; i++) {
				QuantityPicker.Items.Add (i.ToString());
			}
			MeasurementPicker.Items.Clear ();
			MeasurementPicker.Items.Add ("100 g");
			MeasurementPicker.Items.Add ("Pounds");
			MeasurementPicker.Items.Add ("Ounces");
		}
	}
}

