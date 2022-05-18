using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LibraryDB.Views;
using LibraryDB.Repositories;

namespace LibraryDB
{
    public partial class App : Application
    {
        #region Repository
        private static BookRepository _BookDB;

        public static BookRepository BookDB
        {
            get
            {
                if(_BookDB == null)
                {
                    _BookDB = new BookRepository();
                }
                return _BookDB;
            }
        }

        private static ReleaseDateRepository _ReleaseDateDB;
        public static ReleaseDateRepository ReleaseDateDB
        {
            get
            {
                if(_ReleaseDateDB == null)
                {
                    _ReleaseDateDB = new ReleaseDateRepository();
                }
                return _ReleaseDateDB;
            }
        }

        #endregion

        public App()
        {
            InitializeComponent();

            ReleaseDateDB.Init();
            BookDB.Init();

            MainPage = new NavigationPage(new Index());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
