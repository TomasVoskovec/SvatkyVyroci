using SQLite;
using SvatkyVyroci.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvatkyVyroci
{
    public class Event
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public EventTypes EventType { get; set; }
        public DateTime Date { get; set; }
        public string Info { get; set; }

        public Event(){}

        public Event(string name, EventTypes eventType, DateTime date, string info = "")
        {
            this.Name = name;
            this.EventType = eventType;
            this.Date = date;
            this.Info = info;
        }
    }
}
