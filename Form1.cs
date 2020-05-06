using SvatkyVyroci.Data;
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
        EventDatabase eventDatabase = new EventDatabase();
        List<Event> loadedEvents;

        public Form1()
        {
            InitializeComponent();
            init();
        }

        // Funkce načtená při startu stránky
        void init()
        {
            // Načtení všech událostí z databáze
            loadedEvents = eventDatabase.GetAllEvents();
            if (loadedEvents == null)
            {
                loadedEvents = new List<Event>();
            }

            dateOnCalendarChanged();

            switchPanels(true);

            // Nastavení kalendáře
            monthCalendar1.MaxSelectionCount = 1;

            // Nastavení dropdown menu (typy událostí)
            eventType.DropDownStyle = ComboBoxStyle.DropDownList;
            eventType.Items.Add("Svátek"); // EventTypes.Holiday
            eventType.Items.Add("Výročí"); // EventTypes.Anniversary
        }

        // Akce vyvolaná při změně data v kalendáři
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            dateTimePicker.Value = monthCalendar1.SelectionRange.Start;
            dateOnCalendarChanged();
        }

        // Akce vyvolaná při změně data v poli pro datum
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            monthCalendar1.SetDate(dateTimePicker.Value);
            dateOnCalendarChanged();
        }

        // Place holder pro název eventu
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

        // Funkce vyvolaná po kliknutí na tlačítko "Nová událost"
        private void newEvent_Click(object sender, EventArgs e)
        {
            switchPanels();
            eventDate.Value = dateTimePicker.Value;
        }

        // Změna z jedné stránky na druhou
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

        // Funkce vyvolaná při kliknutí na tlačítko "Přidat událost"
        private void addEvent_Click(object sender, EventArgs e)
        {
            // Kontrola pole s názvem události (jestli pole není prázdné)
            if (eventName.Text != null && eventName.Text != "" && eventName.Text != "Název události")
            {
                // Kontrola dropdown menu pro výběr typu události (jestli je typ vybraný)
                if (eventType.SelectedIndex != -1)
                {
                    // Vytvoření instance nové události z vyplněného formuláře
                    Event newEvent = new Event(eventName.Text, (EventTypes)Enum.Parse(typeof(EventTypes), eventType.SelectedIndex.ToString()), eventDate.Value);
                    if (eventInfo.Text != null && eventInfo.Text != "")
                    {
                        newEvent.Info = eventInfo.Text;
                    }

                    // Uložení události do lokální databáze
                    eventDatabase.SaveEvent(newEvent);

                    // Přidání nové instace do listu načtených událostí
                    loadedEvents.Add(newEvent);

                    // Vymazání dat z formuláře nové události
                    eventName.Text = "Název události";
                    eventName.ForeColor = Color.FromArgb(191, 205, 219);
                    eventInfo.Text = "";

                    // Nastavení data kalendáře na datum zadané ve formuláři nové události a změna stránek
                    monthCalendar1.SetDate(newEvent.Date);
                    dateTimePicker.Value = newEvent.Date;
                    dateOnCalendarChanged();
                    switchPanels();
                }
                else
                {
                    // Zpráva pro uživatele při chybně vyplněném formuláři
                    MessageBox.Show("Musíte vybrat typ události", "Chyba", MessageBoxButtons.OK);
                }
            }
            else
            {
                // Zpráva pro uživatele při chybně vyplněném formuláři
                MessageBox.Show("Musíte vyplnit název události", "Chyba", MessageBoxButtons.OK);
            }
        }

        // Funkce vyvolaná při změnění data v kalendáři
        void dateOnCalendarChanged()
        {
            // Vymazání předchozího seznamu událostí
            listEvents.Items.Clear();

            // Výpis všech dálostí
            if (loadedEvents != null && loadedEvents.Count != 0)
            {
                foreach (Event loadedEvent in loadedEvents)
                {
                    if (loadedEvent.Date.Date == dateTimePicker.Value.Date)
                    {
                        string info = "";
                        string eventTypeText = "";
                        // Přidání ": " za název události pokud má daná událost popis
                        if (loadedEvent.Info != null && loadedEvent.Info != "")
                        {
                            info = ": " + loadedEvent.Info;
                        }
                        // Vytvoření odstupu (dle typu události)
                        if (loadedEvent.EventType == EventTypes.Anniversary)
                        {
                            eventTypeText = loadedEvent.EventType.ToString() + "\t";
                        }
                        else if (loadedEvent.EventType == EventTypes.Holiday)
                        {
                            eventTypeText = loadedEvent.EventType.ToString() + "\t\t";
                        }
                        // Přidání události do seznamu
                        listEvents.Items.Add(eventTypeText + loadedEvent.Name + info);
                    }
                }
            }
        }
    }
}
