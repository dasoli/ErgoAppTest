using System;
namespace ErgoAndroidApp
{
    public class ContactModel
    {
        public ContactModel(string _name, 
                            string _street,
                            string _housenumber,
                            string _city, 
                            string _zip)
        {
            this.name = _name;
            this.street = _street;
            this.housenumber = _housenumber;
            this.city = _city;
            this.zip = _zip;
        }

        public string name;
        public string street;
        public string housenumber;
        public string city;
        public string zip;

    }
}
