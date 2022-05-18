using Bogus;
using LibraryDB.Models;
using LibraryDB.Repositories;
using LibraryDB.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LibraryDB.ViewModel
{
    public class IndexViewModel : BaseViewModel
    {
        private BookRepository BookDB = new BookRepository();
        public ObservableCollection<Book> Books { get; set; }

        public ICommand cmdAddBook { get; set; }

        public ICommand cmdModifyBook { get; set; }

        public IndexViewModel()
        {
            Books = new ObservableCollection<Book>();
            cmdAddBook = new Command(() => cmdAddBookMethod());
            cmdModifyBook = new Command<Book>((item) => cmdModifyBookMethod(item));
        }

        private void cmdModifyBookMethod(Book book)
        {
            App.Current.MainPage.Navigation.PushAsync(new MattoBook(book));
        }

        private void cmdAddBookMethod()
        {
            Book book = new Faker<Book>()
                .RuleFor(c => c.Title, f => f.Name.FirstName())
                .RuleFor(c => c.Editorial, f => f.Name.JobArea())
                .RuleFor(c => c.Description, f => f.Name.FirstName())
                .RuleFor(c => c.Autor, f => f.Name.FullName());

            App.Current.MainPage.Navigation.PushAsync(new MattoBook(book));
        }

        public void GetAll()
        {
            if(Books != null)
            {
                Books.Clear();
                BookDB.GetAll().ForEach(item => Books.Add(item));
            }
            else
            {
                Books = new ObservableCollection<Book>(BookDB.GetAll());
            }
            OnPropertyChanged();
        }
    }
}
