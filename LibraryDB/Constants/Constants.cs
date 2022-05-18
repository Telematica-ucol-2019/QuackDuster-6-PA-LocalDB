using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LibraryDB.Constants
{
    public static class Constants
    {
        private const string DatabaseFileName = "dbLibrary.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            //DB in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            //DB if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            //Enable multi threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFileName);
            }
        }
    }


}
