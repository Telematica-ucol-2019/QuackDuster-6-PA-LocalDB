using LibraryDB.Models;
using LibraryDB.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LibraryDB.ViewModel
{
    public class MattoBookViewModel
    {
        public Book Book { get; set; }

        private BookRepository BookDB = new BookRepository();

        public ICommand cmdSaveBook { get; set; }
        public MattoBookViewModel(Book book)
        {
            Book = book;

            cmdSaveBook = new Command<Book>((item) => cmdSaveBookMethod(item));
        }

        private void cmdSaveBookMethod(Book book)
        {
            BookDB.InsertOrUpdate(book);
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
