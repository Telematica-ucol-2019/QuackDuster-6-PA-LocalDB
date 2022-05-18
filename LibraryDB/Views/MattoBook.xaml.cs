using LibraryDB.Models;
using LibraryDB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LibraryDB.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MattoBook : ContentPage
    {
        public MattoBook(Book book)
        {
            InitializeComponent();
            BindingContext = new MattoBookViewModel(book);
        }
    }
}