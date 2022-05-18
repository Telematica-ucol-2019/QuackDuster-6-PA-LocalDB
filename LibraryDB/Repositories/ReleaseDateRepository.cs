using LibraryDB.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LibraryDB.Repositories
{
    public class ReleaseDateRepository
    {
        SQLiteConnection connection;

        public ReleaseDateRepository()
        {
            connection = new SQLiteConnection(Constants.Constants.DatabasePath, Constants.Constants.Flags);
            connection.CreateTable<ReleaseDate>();
        }

        public void Init()
        {
            connection.CreateTable<ReleaseDate>();
        }

        public void InsertOrUpdate(ReleaseDate release)
        {
            if (release.Id == 0)
            {
                Debug.WriteLine($"Id before register {release.Id}");
                connection.Insert(release);
                Debug.WriteLine($"Id after register {release.Id}");
            }
            else
            {
                Debug.WriteLine($"Id before updating {release.Id}");
                connection.Update(release);
                Debug.WriteLine($"Id after updating {release.Id}");
            }
        }

        public ReleaseDate GetById(int Id)
        {
            return connection.Table<ReleaseDate>().FirstOrDefault(item => item.Id == Id);
        }

        public List<ReleaseDate> GetAll()
        {
            return connection.Table<ReleaseDate>().ToList();
        }

        public void DeleteItem(int Id)
        {
            ReleaseDate release = GetById(Id);
            connection.Delete(release);
        }
    }
}
