using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using LibraryDB.Models;
using System.Diagnostics;

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

        public void InsertOrUpdate(Book book)
        {
            if (book.Id == 0)
            {
                Debug.WriteLine($"Id before register {book.Id}");
                connection.Insert(book);
                Debug.WriteLine($"Id after register {book.Id}");
            }
            else
            {
                Debug.WriteLine($"Id before updating {book.Id}");
                connection.Update(book);
                Debug.WriteLine($"Id after updating {book.Id}");
            }
        }

        public Book GetById(int Id)
        {
            return connection.Table<Book>().FirstOrDefault(item => item.Id == Id);
        }

        public List<Book> GetAll()
        {
            return connection.Table<Book>().ToList();
        }
    }
}
