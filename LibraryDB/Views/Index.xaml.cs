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
    public partial class Index : ContentPage
    {
        IndexViewModel vm = new IndexViewModel();
        public Index()
        {
            InitializeComponent();
            BindingContext = vm;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.GetAll();
        }

    }
}