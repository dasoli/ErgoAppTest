using System;
using SQLite;

namespace ErgoAndroidApp
{
	public class OrderModel
	{
		public static OrderModel Create(int _contactId, float _distance)
		{
            OrderModel model = new OrderModel();
			model.ContactId = _contactId;
			model.Distance = _distance;

			return model;
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
        public int ContactId { get; set; }
		public float Distance { get; set; }
	}
}

