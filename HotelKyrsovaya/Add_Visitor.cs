using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelKyrsovaya
{
    public partial class Add_Visitor : Form
    {
        DataBase database = new DataBase();
        public Add_Visitor()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            database.openConnection();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_add_Click_1(object sender, EventArgs e)
        {
            database.openConnection();
            var fam = txt_fam.Text;
            var nam = txt_nam.Text;
            var otec = txt_otec.Text;
            int ceria;
            int nomer;
            if (int.TryParse(txt_ceria.Text, out ceria) && (int.TryParse(txt_nomer.Text, out nomer)))
            {
                var addQuery = $"insert into visitor (lastname, naming, otchestvo, ceria, number) values ('{fam}', '{nam}', '{otec}', '{ceria}','{nomer}')";
                var command = new SqlCommand(addQuery, database.getConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно создана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Никаких букв, только цифры", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            database.closeConnection();

        }
    }
}
