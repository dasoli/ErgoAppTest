using System;
using ErgoAndroidApp.Helper;

namespace ErgoAndroidApp.Dataservices
{
    public static class AppDataStore
    {
        public static string googleGeoCodeApiKey = "AIzaSyDQAByTG720-7tVyN5rgkxqlJCgLojxCNA";
        public static string currentPos = "50.929350,11.589948"; // schiller uni

        static ContactModelDatabase database;

		public static ContactModelDatabase Database
		{
			get
			{
				if (database == null)
				{
                    database = new ContactModelDatabase(Filehelper.GetLocalFilePath("Ergo.db3"));
				}
				return database;
			}
		}
    }
}
