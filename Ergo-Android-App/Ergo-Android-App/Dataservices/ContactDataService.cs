using System.Collections.Generic;
using System;

namespace ErgoAndroidApp.Dataservices
{
    public static class ContactDataService
    {
        static List<ContactModel> contacts;

        public static void init() {
            if (ContactDataService.contacts == null) {
				ContactDataService.InsertDemoContent();
			}
            Console.WriteLine("Got Contacts {0}", ContactDataService.contacts.ToArray().ToString());
        }

        public static ContactModel[] getContacts() {

            return ContactDataService.contacts.ToArray();
        }

        public static List<string> GetContactsAsStringList()
		{
            List<string> contactNames = new List<string>();
            foreach(ContactModel contact in ContactDataService.contacts) {
                contactNames.Add(contact.Name);
            }

            return contactNames;
		}

        private static void InsertDemoContent() {

            ContactDataService.contacts = new List<ContactModel>();
            for (int i = 1; i < 10; ++i) {
                string name = "Kunde " + i;
                string street = "Lessingstraße";
                string city = "Weimar";
                string housenumber = ""+i;
                string zip = "99425";

                ContactModel contact = ContactModel.CreateContact(name, 
                                                        street, 
                                                        city, 
                                                        housenumber, 
                                                        zip);
                
                ContactDataService.contacts.Add(contact);
            }
        }

        public static void AddContact(ContactModel _contact) {
            ContactDataService.contacts.Add(_contact);
            Console.WriteLine("added conctact: {0}", _contact.Name);
            // save
   //         ContactDataService.contacts.ToArray().ToString();
			//ISharedPreferences prefs = Application.Context.GetSharedPreferences("default", FileCreationMode.Private);
		}

        public static void RemoveContact(ContactModel _contact) {
            ContactDataService.contacts.Remove(_contact);
            // save 
		}
    }
}
