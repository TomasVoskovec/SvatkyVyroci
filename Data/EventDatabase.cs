using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvatkyVyroci.Data
{
    class EventDatabase
    {
        static object locker = new object();

        SQLiteConnection database;

        public EventDatabase()
        {
            database = SQLiteWindows.GetConnection();
            database.CreateTable<Event>();
        }

        public List<Event> GetAllEvents()
        {
            lock (locker)
            {
                if (database.Table<Event>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<Event>().ToList();
                }
            }
        }

        public int SaveEvent(Event savedEvent)
        {
            lock (locker)
            {
                if (savedEvent.Id != 0)
                {
                    database.Update(savedEvent);
                    return savedEvent.Id;
                }
                else
                {
                    return database.Insert(savedEvent);
                }
            }
        }
    }
}
