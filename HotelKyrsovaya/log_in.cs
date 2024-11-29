using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelKyrsovaya
{
    public partial class log_in : Form
    {
        DataBase database = new DataBase();
        public log_in()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Log_in_Load(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = '•';
            txt_log.MaxLength = 50;
            textBox_password.MaxLength = 50;
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            var loginUser = txt_log.Text;
            var passUser = textBox_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();  
            DataTable table = new DataTable();

            string querystring = $"select id_user, login_user,password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";
            SqlCommand  command = new SqlCommand(querystring, database.getConnection());
            
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count == 1) 
            {
                MessageBox.Show("Добро пожаловать!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Form1 frm1 = new Form1();
                this.Hide();
                frm1.ShowDialog();
                Application.Exit();

            }
            else
                MessageBox.Show("Такого аккаунта не существует", "Аккаунта не существует", MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void log_in_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
