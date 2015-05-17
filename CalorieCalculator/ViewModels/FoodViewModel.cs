using System;
using System.ComponentModel;

namespace CalorieCalculator
{
	public class FoodViewModel : INotifyPropertyChanged {
		private Food _food;
		public event PropertyChangedEventHandler PropertyChanged;

		public FoodViewModel (Food food)
		{
			_food = food;

		}

		public int id {
			get { return _food.id; }
			set {
				if (_food != null) {
					_food.id = value;

					if (PropertyChanged != null) {
						PropertyChanged (this, new PropertyChangedEventArgs ("id"));
					}
				}
			}
		}

		public string Name {
			get { return _food != null ? _food.Name : null; }
			set {
				if (_food != null) {
					_food.Name = value;

					if (PropertyChanged != null) {
						PropertyChanged (this, new PropertyChangedEventArgs ("Name"));
					}
				}
			}
		}

		public string Calories {
			get { return _food != null ? _food.Calories.ToString() : "None"; }
			set {
				if (_food != null) {
					_food.Calories = int.Parse(value);

					if (PropertyChanged != null) {
						PropertyChanged (this, new PropertyChangedEventArgs ("Calories"));
					}
				}
			}
		}

		public string TotalFat {
			get { return _food != null ? _food.TotalFat.ToString() : "None"; }
			set {
				if (_food != null) {
					_food.TotalFat = float.Parse(value);

					if (PropertyChanged != null) {
						PropertyChanged (this, new PropertyChangedEventArgs ("Total Fat"));
					}
				}
			}
		}

		public string Cholesterol {
			get { return _food != null ? _food.Cholesterol.ToString() : "None"; }
			set {
				if (_food != null) {
					_food.Cholesterol = float.Parse(value);

					if (PropertyChanged != null) {
						PropertyChanged (this, new PropertyChangedEventArgs ("Cholesterol"));
					}
				}
			}
		}


	}
}

