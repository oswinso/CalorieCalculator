using System;
using SQLite;

namespace CalorieCalculator
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}

