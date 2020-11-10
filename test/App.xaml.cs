using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace test
{
    public partial class App : Application

    {
        public static string FolderPath { get; private set; }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());

           
        }
        


    }
}
