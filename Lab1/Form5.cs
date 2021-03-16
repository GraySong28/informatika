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
    public partial class chacgeEvent : Form
    {
        public string dateTimeEventChange_F5;
        public chacgeEvent()
        {
            InitializeComponent();
            eventTypeChange.SelectedIndex = 0;
        }
        public string getDateChacge
        {
            get
            {
                return dateTimeEventChange.Text;
            }
        }
        public string getTimeChacge
        {
            get
            {
                return timeOfEventChange.Text;
            }
        }
        public string getEventTypeChacge
        {
            get
            {
                return eventTypeChange.Text;
            }
        }
        public string getTextChacge
        {
            get
            {
                return eventTextChange.Text;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (timeOfEventChange.MaskCompleted & eventTextChange.Text != "")
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
