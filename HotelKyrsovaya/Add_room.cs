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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelKyrsovaya
{
    public partial class Add_room : Form
    {
        DataBase database = new DataBase();
        public Add_room()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            database.openConnection();

            var laguna  = txt_laguna.Text;
            var label = txt_label.Text;
            int mesta;
            int price;
            var style = txt_style.Text;
            if (int.TryParse(txt_mesta.Text, out mesta) & (int.TryParse(txt_price.Text, out price)))
            {
                var addQuery = $"insert into room (kind_room, name_room, count_room, money_room, style_room) values ('{laguna}', '{label}', '{mesta}', '{price}','{style}')";
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
