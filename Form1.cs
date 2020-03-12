using SvatkyVyroci.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SvatkyVyroci
{
    public partial class Form1 : Form
    {
        JsonController jsonController = new JsonController();
        List<Event> loadedEvents = new List<Event>();

        public Form1()
        {
            InitializeComponent();
            init();
        }

        void init()
        {
            loadedEvents = jsonController.LoadEvents();
            dateOnCalendarChanged();

            switchPanels(true);

            // Calendar
            monthCalendar1.MaxSelectionCount = 1;

            // Event type selection
            eventType.DropDownStyle = ComboBoxStyle.DropDownList;
            eventType.Items.Add("Svátek"); // EventTypes.Holiday
            eventType.Items.Add("Výročí"); // EventTypes.Anniversary
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            dateTimePicker.Value = monthCalendar1.SelectionRange.Start;
            dateOnCalendarChanged();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            monthCalendar1.SetDate(dateTimePicker.Value);
            dateOnCalendarChanged();
        }

        private void eventName_Enter(object sender, EventArgs e)
        {
            if(eventName.Text == "Název události")
            {
                eventName.Text = "";
                eventName.ForeColor = Color.Black;
            }
        }

        private void eventType_Enter(object sender, EventArgs e)
        {
            eventType.Text = "";
            eventType.ForeColor = Color.Black;
        }

        private void newEvent_Click(object sender, EventArgs e)
        {
            switchPanels();
            eventDate.Value = dateTimePicker.Value;
        }

        void switchPanels(bool isInitializing = false)
        {
            if (!newEventPanel.Visible && !isInitializing)
            {
                newEventPanel.Show();
                calendarPanel.Hide();
            }
            else
            {
                newEventPanel.Hide();
                calendarPanel.Show();
            }
        }

        private void addEvent_Click(object sender, EventArgs e)
        {
            if (eventName.Text != null && eventName.Text != "" && eventName.Text != "Název události")
            {
                if (eventType.SelectedIndex != -1)
                {
                    Event newEvent = new Event(eventName.Text, (EventTypes)Enum.Parse(typeof(EventTypes), eventType.SelectedIndex.ToString()), eventDate.Value);
                    if (eventInfo.Text != null && eventInfo.Text != "")
                    {
                        newEvent.Info = eventInfo.Text;
                    }

                    List<Event> events = jsonController.LoadEvents();
                    if(events == null)
                    {
                        events = new List<Event>();
                    }
                    events.Add(newEvent);
                    jsonController.SaveEvents(events);

                    loadedEvents = events;

                    eventName.Text = "Název události";
                    eventName.ForeColor = Color.FromArgb(191, 205, 219);
                    eventInfo.Text = "";

                    monthCalendar1.SetDate(newEvent.Date);
                    dateTimePicker.Value = newEvent.Date;
                    dateOnCalendarChanged();
                    switchPanels();
                }
                else
                {
                    MessageBox.Show("Musíte vybrat typ události", "Chyba", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Musíte vyplnit název události", "Chyba", MessageBoxButtons.OK);
            }
        }

        void dateOnCalendarChanged()
        {
            listEvents.Items.Clear();

            if (loadedEvents != null && loadedEvents.Count != 0)
            {
                foreach (Event loadedEvent in loadedEvents)
                {
                    if (loadedEvent.Date.Date == dateTimePicker.Value.Date)
                    {
                        string info = "";
                        string eventTypeText = "";
                        if (loadedEvent.Info != null && loadedEvent.Info != "")
                        {
                            info = ": " + loadedEvent.Info;
                        }
                        if (loadedEvent.EventType == EventTypes.Anniversary)
                        {
                            eventTypeText = loadedEvent.EventType.ToString() + "\t";
                        }
                        else if (loadedEvent.EventType == EventTypes.Holiday)
                        {
                            eventTypeText = loadedEvent.EventType.ToString() + "\t\t";
                        }

                        listEvents.Items.Add(eventTypeText + loadedEvent.Name + info);
                    }
                }
            }
        }
    }
}
