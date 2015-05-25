using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace CalorieCalculator
{
	public class App : Application
	{
		static FoodDatabase foodDB;
		static RecordDatabase recordDB;
		static DayPage daypage;

		public App ()
		{
			// The root page of your application
			daypage = new DayPage ();
			MainPage = GetMainPage();
			daypage.update ();
		}

		public static FoodDatabase FoodDB {
			get {
				if (foodDB == null) {
					foodDB = new FoodDatabase ();
				}
				return foodDB;
			}
		}

		public static RecordDatabase RecordDB {
			get {
				if (recordDB == null) {
					recordDB = new RecordDatabase ();
				}
				return recordDB;
			}
		}

		public static DayPage dayPage {
			get {
				if (daypage == null) {
					daypage = new DayPage();
				}
				return daypage;
			}
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

		public static Page GetMainPage() {
			return new NavigationPage (daypage);
		}
	}
}

