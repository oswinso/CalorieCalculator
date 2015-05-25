using System.Collections.ObjectModel;
using System.ComponentModel;
using CalorieCalculator;
using System.Collections.Generic;


namespace CalorieCalculator
{	
	public class DayViewModel : INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;

		private ObservableCollection<FoodRecord> _foodRecords;
		public int _total;
		public string _text;

		protected virtual void OnPropertyChanged(string propertyName) {
			if (PropertyChanged != null) {
				PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
			}
		}

		public string Text {
			get { 
				return _text;
			}
			set {
				_text = value;
				OnPropertyChanged ("Text");
			}
		}

		public int Total {
			get {
				return _total;
			}
			set {
				_total = value;
				Text = "Total Calories: " + Total;
				OnPropertyChanged ("Total");
			}
		}
		public DayViewModel () {
			FoodRecords = new ObservableCollection<FoodRecord>();
			Total = 0;
		}

		public ObservableCollection<FoodRecord> FoodRecords
		{
			get { return _foodRecords; }
			set {
				_foodRecords = value;
				OnPropertyChanged ("FoodRecords");
			}
		}

		public void update() {
			FoodRecords.Clear ();
			var recordDB = App.RecordDB.GetRecords ("breakfast");
			int tmp = 0;
			foreach (var record in recordDB) {
				FoodRecords.Add (record);
				tmp += record.Calories;
			}
			Total = tmp;
		}

	}
}

