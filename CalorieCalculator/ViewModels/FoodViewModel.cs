using System;
using System.ComponentModel;

namespace CalorieCalculator
{
	public class FoodViewModel : INotifyPropertyChanged
	{
		private Food _food;
		private int _quantityindex;
		private int _measurementindex;
		public event PropertyChangedEventHandler PropertyChanged;
		public string ButtonName { get; set; }

		public FoodViewModel ( Food food )
		{
			this._food = food;
		}

		protected virtual void OnPropertyChanged(string propertyName) {
			if (PropertyChanged != null) {
				PropertyChanged ( this, new PropertyChangedEventArgs (propertyName) );
			}
		}

		public int id
		{
			get { return this._food.id; }
			set {
				if (_food != null)
				{
					this._food.id = value;
					OnPropertyChanged ("id");
				}
			}
		}

		public string Name {
			get { return _food != null ? _food.Name : null; }
			set {
				if (_food != null) {
					_food.Name = value;
					OnPropertyChanged ("Name");
				}
			}
		}

		public int Calories {
			get { return _food.Calories; }
			set {
				if (_food != null) {
					_food.Calories = value;
					OnPropertyChanged ("Calories");
				}
			}
		}

		public string TotalFat {
			get { return _food != null ? _food.TotalFat.ToString() : "None"; }
			set {
				if (_food != null) {
					_food.TotalFat = float.Parse(value);
					OnPropertyChanged ("TotalFat");
				}
			}
		}

		public string Cholesterol {
			get { return _food != null ? _food.Cholesterol.ToString() : "None"; }
			set {
				if (_food != null) {
					_food.Cholesterol = float.Parse(value);
					OnPropertyChanged ("Cholesterol");
				}
			}
		}

		public int QuantityIndex {
			get { return _quantityindex; }
			set {
				_quantityindex = value;
				OnPropertyChanged ("QuantityIndex");
			}
		}

		public int MeasurementIndex {
			get { return _measurementindex; }
			set {
				_measurementindex = value;
				OnPropertyChanged ("MeasurementIndex");
			}
		}

	}
}

