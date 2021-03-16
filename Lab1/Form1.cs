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
    public partial class authorizationForm : Form
    {
        public authorizationForm()
        {
            InitializeComponent();
        }

        private void showPasswordCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (showPasswordCheck.Checked) passwordText.PasswordChar = (char)0;
            else passwordText.PasswordChar = '*';
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if((loginText.Text == "Vitaliy Oshitkov") & (passwordText.Text == "Password1"))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
