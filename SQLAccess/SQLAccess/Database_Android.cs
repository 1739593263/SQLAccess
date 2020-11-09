
using SQLite;
using static SQLAccess.SQLTable;
using System.IO;
using System.Runtime.CompilerServices;
using SQLAccess;

[assembly: Xamarin.Forms.Dependency(typeof(Database_Android))]
namespace SQLAccess
{
    public class Database_Android: IDatabase
    {
        public Database_Android() {
            
        }
        public SQLiteConnection DBConnect() {
            var filename = "ItemsSQLite.db3";
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(folder, filename);
            SQLiteConnection connection = new SQLiteConnection(path);
            return connection;
        }

    }

}
