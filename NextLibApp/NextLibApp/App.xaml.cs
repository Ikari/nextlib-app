using NextLibApp.Database;
using Xamarin.Forms;

namespace NextLibApp
{
    public partial class App : Application
    {
        static NextDatabase database;

        public App()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.iOS)
                MainPage = new MainPage();
            else
                MainPage = new NavigationPage(new MainPage());
        }

        public static NextDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new NextDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("NextSQLite.db3"));
                }
                return database;
            }
        }
    }
}