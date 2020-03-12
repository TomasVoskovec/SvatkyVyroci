using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SvatkyVyroci.Model
{
    public class JsonController
    {
        static string dirToApp = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        static string dirToAppData = dirToApp + "/AppData";
        static string jsonFilePath = dirToAppData + "/events.json";

        public JsonController()
        {
            if(!Directory.Exists(dirToAppData))
            {
                Directory.CreateDirectory(dirToAppData);
            }
        }

        public void SaveEvents(List<Event> events)
        {
            string jsonEvents = JsonConvert.SerializeObject(events);
            File.WriteAllText(jsonFilePath, jsonEvents);
        }

        public List<Event> LoadEvents()
        {
            if(File.Exists(jsonFilePath))
            {
                List<Event> events = JsonConvert.DeserializeObject<List<Event>>(File.ReadAllText(jsonFilePath));
                return events;
            }
            return null;
        }
    }
}
