using System;
using System.ComponentModel;

namespace CalorieCalculator
{
	public class FoodViewModel : INotifyPropertyChanged
	{
		private Food food;
		private int quantityIndex;
		private int measurementIndex;

		public event PropertyChangedEventHandler PropertyChanged;

		public string ButtonName { get; set; }

		public FoodViewModel(Food food)
		{
			this.food = food;
		}

		public int ID
		{
			get
			{
				return this.food.id;
			}

			set
			{
				if (this.food != null)
				{
					this.food.id = value;
					this.OnPropertyChanged("id");
				}
			}
		}

		public string Name
		{
			get
			{
				return this.food != null ? this.food.Name : null;
			}

			set
			{
				if (this.food != null)
				{
					this.food.Name = value;
					this.OnPropertyChanged("Name");
				}
			}
		}

		public int Calories
		{
			get
			{
				return this.food.Calories;
			}

			set
			{
				if (this.food != null)
				{
					this.food.Calories = value;
					this.OnPropertyChanged("Calories");
				}
			}
		}

		public string TotalFat
		{
			get
			{
				return this.food != null ? this.food.TotalFat.ToString() : "None";
			}

			set
			{
				if (this.food != null)
				{
					this.food.TotalFat = float.Parse(value);
					this.OnPropertyChanged("TotalFat");
				}
			}
		}

		public string Cholesterol
		{
			get
			{
				return this.food != null ? this.food.Cholesterol.ToString() : "None";
			}

			set
			{
				if (this.food != null)
				{
					this.food.Cholesterol = float.Parse(value);
					this.OnPropertyChanged("Cholesterol");
				}
			}
		}

		public int QuantityIndex
		{
			get
			{
				return this.quantityIndex;
			}

			set
			{
				this.quantityIndex = value;
				this.OnPropertyChanged("QuantityIndex");
			}
		}

		public int MeasurementIndex
		{
			get
			{
				return this.measurementIndex;
			}

			set
			{
				this.measurementIndex = value;
				this.OnPropertyChanged("MeasurementIndex");
			}
		}

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}