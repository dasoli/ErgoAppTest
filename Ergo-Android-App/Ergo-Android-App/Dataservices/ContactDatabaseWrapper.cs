using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace ErgoAndroidApp.Dataservices
{
	public class ContactModelDatabase
	{
		readonly SQLiteAsyncConnection database;

		public ContactModelDatabase(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<ContactModel>().Wait();
            database.CreateTableAsync<OrderModel>().Wait();
            this.InsertDemoContentAsync();
		}

        private Task InsertDemoContentAsync()
		{
            List<ContactModel> contacts = this.GetItemsAsync().Result;

            if(contacts.Count == 0) {
				for (int i = 1; i < 10; ++i)
				{
					string name = "Kunde " + i;
					string street = "Lessingstraße";
					string city = "Weimar";
					string housenumber = "" + i;
					string zip = "99425";

					ContactModel contact = ContactModel.CreateContact(name,
																	street,
																	city,
																	housenumber,
																	zip);

                    this.SaveItemAsync(contact).Wait();
				}
            }

            return Task.CompletedTask;
		}

		public Task<List<ContactModel>> GetItemsAsync()
		{
			return database.Table<ContactModel>().ToListAsync();
		}

        public List<string> ConvertListToStringNames(List<ContactModel> _list)
		{
			List<string> contactNames = new List<string>();
			foreach (ContactModel contact in _list)
			{
				contactNames.Add(contact.Name);
			}

			return contactNames;
		}

		public Task<ContactModel> GetItemAsync(int id)
		{
			return database.Table<ContactModel>().Where(i => i.ID == id).FirstOrDefaultAsync();
		}

		public Task<int> SaveItemAsync(ContactModel item)
		{
			if (item.ID != 0)
			{
				return database.UpdateAsync(item);
			}
			else
			{
				return database.InsertAsync(item);
			}
		}

		public Task<int> DeleteItemAsync(ContactModel item)
		{
			return database.DeleteAsync(item);
		}

		public Task<List<OrderModel>> GetOrdersAsync()
		{
			return database.Table<OrderModel>().ToListAsync();
		}

        // orders

		public Task<OrderModel> GetOrderAsync(int id)
		{
			return database.Table<OrderModel>().Where(i => i.ID == id).FirstOrDefaultAsync();
		}

		public Task<int> SaveOrderAsync(OrderModel item)
		{
			if (item.ID != 0)
			{
				return database.UpdateAsync(item);
			}
			else
			{
				return database.InsertAsync(item);
			}
		}

		public Task<int> DeleteOrderAsync(OrderModel item)
		{
			return database.DeleteAsync(item);
		}
	}
}


