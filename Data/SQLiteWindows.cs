using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SvatkyVyroci.Data
{
    public class SQLiteWindows
    {
        public static SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFileName = "Events.db3";
            string dirToAppData = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/AppData";
            var path = Path.Combine(dirToAppData, sqliteFileName);

            var connection = new SQLite.SQLiteConnection(path);

            return connection;
        }
    }
}
