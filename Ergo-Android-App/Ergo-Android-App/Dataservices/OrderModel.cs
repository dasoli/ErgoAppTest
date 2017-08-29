using System;
using SQLite;

namespace ErgoAndroidApp
{
	public class OrderModel
	{
        public static OrderModel Create(string _orderName, int _contactId, int _distance, string _orderText)
		{
            OrderModel model = new OrderModel();
			model.ContactId = _contactId;
			model.Distance = _distance;
            model.OrderText = _orderText;
            model.OrderName = _orderName;

			return model;
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
        public string OrderName { get; set; }
        public int ContactId { get; set; }
        public string OrderText { get; set; }
		public int Distance { get; set; }
	}
}

