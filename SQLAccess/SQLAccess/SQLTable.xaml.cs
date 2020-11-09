using SQLite;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLAccess
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SQLTable : ContentPage
    {
        public class Item
        {
            [PrimaryKey, AutoIncrement]
            public int ID { get; set; }
            [MaxLength(15)]
            public string Name { get; set; }
            [MaxLength(50)]
            public string Description { get; set; }
        }
        public interface IDatabase
        {
            SQLiteConnection DBConnect();
        }
        public class ItemDatabaseBasic
        {
            protected static object locker = new object();
            protected SQLiteConnection database;
            
            public ItemDatabaseBasic()
            {
                database = DependencyService.Get<IDatabase>().DBConnect();
                database.CreateTable<Item>();
            }
            public IEnumerable<Item> GetItems()
            {
                lock (locker)
                {
                    return (from i in database.Table<Item>() select i).ToList();
                }
            }
            public IEnumerable<Item> GetFirstItem()
            {
                lock (locker)
                {
                    return database.Query<Item>("SELECT * FROM Item WHERE Name = 'First'");
                }
            }
            public Item GetItem(int id)
            {
                lock (locker)
                {
                     return database.Table<Item>().FirstOrDefault(x => x.ID == id);
                }
            }
            public int SaveItem(Item item)
            {
                lock (locker)
                {
                    if (item.ID != 0)
                    {
                        database.Update(item);
                        return item.ID;
                    }
                    else
                    {
                        return database.Insert(item);
                    }
                }
            }
            public int DeleteItem(int id)
            {
                lock (locker)
                {
                    return database.Delete<Item>(id);
                }
            }
        }
        public SQLTable()
        {
            InitializeComponent();

        }
    }
}