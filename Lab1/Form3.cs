using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class addEvent : Form
    {
        public addEvent()
        {
            InitializeComponent();
            eventType.SelectedIndex = 0;
        }
        public string getDate
        {
            get
            {
                return dateTimeEvent.Text;
            }
        }
        public string getTime
        {
            get
            {
                return timeOfEvent.Text;
            }
        }
        public string getEventType
        {
            get
            {
                return eventType.Text;
            }
        }
        public string getText
        {
            get
            {
                return eventText.Text;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (timeOfEvent.MaskCompleted & eventText.Text != "")
            {                
                Close();
            }
            else
            {
                MessageBox.Show("Заполните все данные коректно");
            }
        }
    }
}
