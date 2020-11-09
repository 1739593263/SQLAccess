using System.Linq;
using Xamarin.Forms;
using static SQLAccess.SQLTable;

namespace SQLAccess
{
   
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Label label = new Label {
                Text = "Database Created Using SQLite.NET\n"
            };

            var item = new Item { Name = "First", Description = "This is the first item" };
            App.Repository.SaveItem(item);
            var item1 = new Item { Name = "Second", Description = "This is the second item" };
            App.Repository.SaveItem(item1);


            var firstItem = App.Repository.GetFirstItem();
            var items = App.Repository.GetItems();
            foreach (var i in items)
            {
                // label.Text += firstItem.First<Item>().Name + " " + firstItem.First<Item>().Description + " ";
                label.Text += i.Name + " : " + i.Description + "\n";

            }

            Content = new StackLayout
            {
                Children = { label}
            };
        }
    }
}
