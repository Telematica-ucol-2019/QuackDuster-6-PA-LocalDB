using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using LibraryDB.Models;
using System.Diagnostics;
using SQLiteNetExtensions.Extensions;
using System.Linq;

namespace LibraryDB.Repositories
{
    public class BookRepository
    {
        SQLiteConnection connection;
        public BookRepository()
        {
            connection = new SQLiteConnection(Constants.Constants.DatabasePath, Constants.Constants.Flags);
            connection.CreateTable<Book>();

        }

        public void Init()
        {
            connection.CreateTable<ReleaseDate>();
        }

        public void InsertOrUpdate(Book book)
        {
            if (book.Id == 0)
            {
                Debug.WriteLine($"Id before register {book.Id}");
                connection.InsertWithChildren(book);
                Debug.WriteLine($"Id after register {book.Id}");
            }
            else
            {
                Debug.WriteLine($"Id before updating {book.Id}");
                connection.Update(book);
                App.ReleaseDateDB.InsertOrUpdate(book.ReleaseDate);
                Debug.WriteLine($"Id after updating {book.Id}");
            }
        }

        public Book GetById(int Id)
        {
            return connection.Table<Book>().FirstOrDefault(item => item.Id == Id);
        }

        public List<Book> GetAll()
        {
            return connection.GetAllWithChildren<Book>().ToList();
        }

        public void DeleteItem(int Id)
        {
            Book book = GetById(Id);
            connection.Delete(book);
        }
    }
}
