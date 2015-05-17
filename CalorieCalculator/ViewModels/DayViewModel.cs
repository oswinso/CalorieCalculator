using System.Collections.ObjectModel;
using System.ComponentModel;


namespace CalorieCalculator
{	
	public class DayPageModel : INotifyPropertyChanged {
		public ObservableCollection<FoodRecord> FoodRecords { get; set; }

		public DayPageModel () {
			FoodRecords = new ObservableCollection<FoodRecord> ();

			var recordDB = App.RecordDB.GetRecords ("breakfast");
			foreach (var record in recordDB) {
				FoodRecords.Add (record);
			}
		}
	}
}

