using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab1
{
    public partial class organizerForm : Form
    {
        public string dateOfEvent, timeOfEvent, typeOfEvent, textOfEvent, searchText, getDateListView_F2;
        public string getDateListView
        {
            get
            {
                return getDateListView_F2;
            }
        }
        public organizerForm()
        {
            InitializeComponent();
            eventTypeF2.SelectedIndex = 0;
            eventTypeF2.Enabled = false;
            this.KeyPreview = true;
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            //base.OnKeyDown(e);
            if (e.KeyCode == Keys.Delete)
            {
                DialogResult result;
                result = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    viewOrganizer.Items.RemoveAt(viewOrganizer.SelectedIndices[0]);
                }
            }
            if (e.KeyData == (Keys.Control | Keys.S))
            {
                //MessageBox.Show("Ctrl + s");
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.DefaultExt = ".txt";
                saveFile.Filter = "Text|*.txt";
                if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile.FileName.Length > 0)
                {
                    using(StreamWriter sw = new StreamWriter(saveFile.FileName, true))
                    {
                        foreach (ListViewItem item in viewOrganizer.Items)
                        {
                            sw.WriteLine(item.SubItems[0].Text + "/" + item.SubItems[1].Text + "/" +
                                         item.SubItems[2].Text + "/" + item.SubItems[3].Text);
                        }
                        sw.Close();
                    }
                }
            }
            if (e.KeyData == (Keys.Control | Keys.O))
            {
                //MessageBox.Show("Ctrl + O");
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.DefaultExt = ".txt";
                if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFile.FileName.Length > 0)
                {
                    using (StreamReader sw = new StreamReader(openFile.FileName, true))
                    {
                        viewOrganizer.Items.Clear();
                        while (!sw.EndOfStream)
                        {
                            string s = sw.ReadLine();
                            string[] arr = s.Split('/');
                            ListViewItem item = new ListViewItem(arr[0]);
                            item.SubItems.Add(arr[1]);
                            item.SubItems.Add(arr[2]);
                            item.SubItems.Add(arr[3]);
                            viewOrganizer.Items.AddRange(new ListViewItem[] { item });
                        }
                        sw.Close();
                    }
                }
            }
        }

        private void searchEvent_Click(object sender, EventArgs e)
        {
            search searchEvent = new search();
            searchEvent.ShowDialog();
            this.searchText = searchEvent.getSearchText;
            foreach (ListViewItem item in viewOrganizer.Items)
            {
                if(item.SubItems[3].Text.Contains(searchText))
                {
                    item.BackColor = Color.FromArgb(0, 200, 0);
                }
                else
                {
                    item.BackColor = Color.FromArgb(0, 0, 0);
                }
            }
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            eventTypeF2.Enabled = true;
            foreach (ListViewItem item in viewOrganizer.Items)
            {
                if (item.SubItems[2].Text == eventTypeF2.Text)
                {
                    item.BackColor = Color.FromArgb(200, 0, 0);
                }
            }
        }
       
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            eventTypeF2.Enabled = false;
            foreach (ListViewItem item in viewOrganizer.Items)
            {
                item.BackColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void eventTypeF2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in viewOrganizer.Items)
            {
                if (item.SubItems[2].Text == eventTypeF2.Text)
                {
                    item.BackColor = Color.FromArgb(200, 0, 0);
                }
                else
                {
                    item.BackColor = Color.FromArgb(0, 0, 0);
                }
            }
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chacgeEvent openchacgeEvent = new chacgeEvent();
            openchacgeEvent.ShowDialog();
            this.dateOfEvent = openchacgeEvent.getDateChacge;
            this.timeOfEvent = openchacgeEvent.getTimeChacge;
            this.typeOfEvent = openchacgeEvent.getEventTypeChacge;
            this.textOfEvent = openchacgeEvent.getTextChacge;
            viewOrganizer.FocusedItem.SubItems[0].Text = dateOfEvent;
            viewOrganizer.FocusedItem.SubItems[1].Text = timeOfEvent;
            viewOrganizer.FocusedItem.SubItems[2].Text = typeOfEvent;
            viewOrganizer.FocusedItem.SubItems[3].Text = textOfEvent;
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                viewOrganizer.Items.RemoveAt(viewOrganizer.SelectedIndices[0]);
            }            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addEvent openAddEvent = new addEvent();
            openAddEvent.ShowDialog();
            this.dateOfEvent = openAddEvent.getDate;
            this.timeOfEvent = openAddEvent.getTime;
            this.typeOfEvent = openAddEvent.getEventType;
            this.textOfEvent = openAddEvent.getText;
            ListViewItem item = new ListViewItem(dateOfEvent);
            item.SubItems.Add(timeOfEvent);
            item.SubItems.Add(typeOfEvent);
            item.SubItems.Add(textOfEvent);
            viewOrganizer.Items.AddRange(new ListViewItem[] {item});
        }
    }
}
