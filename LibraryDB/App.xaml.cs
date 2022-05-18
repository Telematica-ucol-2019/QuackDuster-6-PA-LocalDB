﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LibraryDB.Views;

namespace LibraryDB
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

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
