using BloomAssignment.LocalDB;
using BloomAssignment.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("CeraProBlack.otf", Alias = "CeraProBlack")]
namespace BloomAssignment
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Home();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }
        static BloomDatabase database;
        public static BloomDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new BloomDatabase();
                }
                return database;
            }
        }
    }
}
