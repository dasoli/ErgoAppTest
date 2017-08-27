using System;
using ErgoAndroidApp.Helper;

namespace ErgoAndroidApp.Dataservices
{
    public static class AppDataStore
    {
        public static string googleGeoCodeApiKey = "AIzaSyDQAByTG720-7tVyN5rgkxqlJCgLojxCNA";
        static ContactModelDatabase database;

		public static ContactModelDatabase Database
		{
			get
			{
				if (database == null)
				{
                    database = new ContactModelDatabase(Filehelper.GetLocalFilePath("TodoSQLite.db3"));
				}
				return database;
			}
		}
    }
}
