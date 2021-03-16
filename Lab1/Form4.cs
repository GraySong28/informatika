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
    public partial class search : Form
    {
        public search()
        {
            InitializeComponent();
        }
        public string getSearchText
        {
            get
            {
                return textSearch.Text;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(textSearch.Text != "")
            {
                Close();
            }
            else
            {
                MessageBox.Show("Введите строку для поиска");
            }
        }
    }
}
