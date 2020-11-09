using System;
using Xamarin.Forms;
using static SQLAccess.SQLTable;

namespace SQLAccess
{
    public partial class App : Application
    {

        static ItemDatabaseBasic repository;
        public static ItemDatabaseBasic Repository {
            get {
                if (repository == null) {
                    repository = new ItemDatabaseBasic();
                }
                return repository;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
