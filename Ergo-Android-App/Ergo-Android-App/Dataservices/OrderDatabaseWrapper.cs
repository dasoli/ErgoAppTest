using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace ErgoAndroidApp.Dataservices
{
	public class OrderModelDatabase
	{
		readonly SQLiteAsyncConnection database;

		public OrderModelDatabase(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<ContactModel>().Wait();
		}


	}
}


