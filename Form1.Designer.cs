namespace SvatkyVyroci
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.listEvents = new System.Windows.Forms.ListBox();
            this.newEvent = new System.Windows.Forms.Button();
            this.calendarPanel = new System.Windows.Forms.Panel();
            this.newEventPanel = new System.Windows.Forms.Panel();
            this.addEvent = new System.Windows.Forms.Button();
            this.eventInfo = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.eventDate = new System.Windows.Forms.DateTimePicker();
            this.eventType = new System.Windows.Forms.ComboBox();
            this.eventName = new System.Windows.Forms.TextBox();
            this.calendarPanel.SuspendLayout();
            this.newEventPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(3, 3);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(304, 20);
            this.dateTimePicker.TabIndex = 0;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(2, 2);
            this.monthCalendar1.Location = new System.Drawing.Point(3, 35);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // listEvents
            // 
            this.listEvents.FormattingEnabled = true;
            this.listEvents.Location = new System.Drawing.Point(319, 3);
            this.listEvents.Name = "listEvents";
            this.listEvents.Size = new System.Drawing.Size(304, 277);
            this.listEvents.TabIndex = 2;
            // 
            // newEvent
            // 
            this.newEvent.Location = new System.Drawing.Point(319, 287);
            this.newEvent.Name = "newEvent";
            this.newEvent.Size = new System.Drawing.Size(304, 59);
            this.newEvent.TabIndex = 3;
            this.newEvent.Text = "Nová událost";
            this.newEvent.UseVisualStyleBackColor = true;
            this.newEvent.Click += new System.EventHandler(this.newEvent_Click);
            // 
            // calendarPanel
            // 
            this.calendarPanel.Controls.Add(this.dateTimePicker);
            this.calendarPanel.Controls.Add(this.listEvents);
            this.calendarPanel.Controls.Add(this.newEvent);
            this.calendarPanel.Controls.Add(this.monthCalendar1);
            this.calendarPanel.Location = new System.Drawing.Point(12, 12);
            this.calendarPanel.Name = "calendarPanel";
            this.calendarPanel.Size = new System.Drawing.Size(626, 354);
            this.calendarPanel.TabIndex = 4;
            // 
            // newEventPanel
            // 
            this.newEventPanel.Controls.Add(this.addEvent);
            this.newEventPanel.Controls.Add(this.eventInfo);
            this.newEventPanel.Controls.Add(this.label1);
            this.newEventPanel.Controls.Add(this.eventDate);
            this.newEventPanel.Controls.Add(this.eventType);
            this.newEventPanel.Controls.Add(this.eventName);
            this.newEventPanel.Location = new System.Drawing.Point(12, 12);
            this.newEventPanel.Name = "newEventPanel";
            this.newEventPanel.Size = new System.Drawing.Size(626, 354);
            this.newEventPanel.TabIndex = 5;
            // 
            // addEvent
            // 
            this.addEvent.Location = new System.Drawing.Point(6, 287);
            this.addEvent.Name = "addEvent";
            this.addEvent.Size = new System.Drawing.Size(617, 59);
            this.addEvent.TabIndex = 5;
            this.addEvent.Text = "Přidat událost";
            this.addEvent.UseVisualStyleBackColor = true;
            this.addEvent.Click += new System.EventHandler(this.addEvent_Click);
            // 
            // eventInfo
            // 
            this.eventInfo.Location = new System.Drawing.Point(6, 95);
            this.eventInfo.Name = "eventInfo";
            this.eventInfo.Size = new System.Drawing.Size(617, 185);
            this.eventInfo.TabIndex = 4;
            this.eventInfo.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Popis události";
            // 
            // eventDate
            // 
            this.eventDate.Location = new System.Drawing.Point(3, 56);
            this.eventDate.Name = "eventDate";
            this.eventDate.Size = new System.Drawing.Size(620, 20);
            this.eventDate.TabIndex = 2;
            // 
            // eventType
            // 
            this.eventType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.eventType.FormattingEnabled = true;
            this.eventType.Location = new System.Drawing.Point(3, 29);
            this.eventType.Name = "eventType";
            this.eventType.Size = new System.Drawing.Size(620, 21);
            this.eventType.TabIndex = 1;
            this.eventType.Text = "Typ Události";
            // 
            // eventName
            // 
            this.eventName.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.eventName.Location = new System.Drawing.Point(3, 3);
            this.eventName.Name = "eventName";
            this.eventName.Size = new System.Drawing.Size(620, 20);
            this.eventName.TabIndex = 0;
            this.eventName.Text = "Název události";
            this.eventName.Enter += new System.EventHandler(this.eventName_Enter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 392);
            this.Controls.Add(this.newEventPanel);
            this.Controls.Add(this.calendarPanel);
            this.Name = "Form1";
            this.Text = "Svátky a výročí";
            this.calendarPanel.ResumeLayout(false);
            this.newEventPanel.ResumeLayout(false);
            this.newEventPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.ListBox listEvents;
        private System.Windows.Forms.Button newEvent;
        private System.Windows.Forms.Panel calendarPanel;
        private System.Windows.Forms.Panel newEventPanel;
        private System.Windows.Forms.TextBox eventName;
        private System.Windows.Forms.ComboBox eventType;
        private System.Windows.Forms.DateTimePicker eventDate;
        private System.Windows.Forms.RichTextBox eventInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addEvent;
    }
}

