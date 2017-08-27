using System;
using System.IO;

namespace ErgoAndroidApp.Helper
{
    public static class Filehelper
    {
		public static string GetLocalFilePath(string filename)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			return Path.Combine(path, filename);
		}
    }
}
