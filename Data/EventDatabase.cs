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
        // Objekt do kterého se uzamkne výsledek z databáze (pro bezpečnější přístup k datům)
        static object locker = new object();

        // Vytvoření instance SQLite databáze
        SQLiteConnection database;

        // Konstruktor databáze
        public EventDatabase()
        {
            database = SQLiteWindows.GetConnection();
            database.CreateTable<Event>();
        }

        // Výpis všech událostí uložených v databázi 
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

        // Uložení události do databáze
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
