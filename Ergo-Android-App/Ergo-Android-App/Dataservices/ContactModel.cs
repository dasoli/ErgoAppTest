using System;
using SQLite;

namespace ErgoAndroidApp
{
    public class ContactModel
    {
        public static ContactModel CreateContact(string _name,
								    string _street,
								    string _housenumber,
								    string _city,
                                    string _zip) 
        {
            ContactModel model = new ContactModel();

            if (_name != null && _name != "")
			{
				model.Name = _name;
			}
            if(_street != null && _street != "") 
            {
               model.Street = _street; 
            }
            if (_housenumber != null && _housenumber != "")
            {
                model.Housenumber = _housenumber;
            }
            if (_street != null && _street != "")
            {
            }
			if (_city != null && _city != "")
			{
                model.City = _city;
			}
			if (_zip != null && _zip != "")
			{
                model.Zip = _zip;
			}

            return model;
        }

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
		public string Housenumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public float Distance { get; set; }
    }
}

