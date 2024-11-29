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
    enum RowState
    {
        Existed,
        Now,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class Room : Form
    {
        DataBase database = new DataBase();
        int selectedRow;
        public Room()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id", "Счетчик номера");
            dataGridView1.Columns.Add("kind_room", "Тип номера");
            dataGridView1.Columns.Add("name_room", "Название номера");
            dataGridView1.Columns.Add("count_room", "Количество мест");
            dataGridView1.Columns.Add("money_room", "Цена");
            dataGridView1.Columns.Add("style_room", "Стиль номера");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetInt32(3), record.GetInt32(4), record.GetString(5), RowState.ModifiedNew);
        }
        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select * from room";
            SqlCommand command = new SqlCommand(queryString, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Add_room addfrm = new Add_room();
            addfrm.ShowDialog();
        }
        private void Change()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var schet = txt_schet.Text;
            var laguna = txt_laguna.Text;
            var label = txt_label.Text;
            var mesta = txt_mesta.Text;
            var price = txt_price.Text;
            var style = txt_style.Text;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {

                dataGridView1.Rows[selectedRowIndex].SetValues(schet, laguna, label, mesta, price, style);
                dataGridView1.Rows[selectedRowIndex].Cells[6].Value = RowState.Modified;
            } 
        }
        private void btn_uptade_Click(object sender, EventArgs e)
        {
            Change();
        }

        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[index].Visible = false;
            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[6].Value = RowState.Deleted;
                return;
            }
            dataGridView1.Rows[index].Cells[6].Value = RowState.Deleted;
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            deleteRow();
            
        }
        
        private void btn_search_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);

        }
        private void Updating()
        {
            database.openConnection();
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[6].Value;
                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from room where id = {id}";
                    var command = new SqlCommand(deleteQuery, database.getConnection());
                    command.ExecuteNonQuery();
                }
                if (rowState == RowState.Modified)
                {   
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var kind = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var name = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var count = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var money = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    var style = dataGridView1.Rows[index].Cells[5].Value.ToString();
                  

                    var changeQuary = $"update room set kind_room = '{kind}', name_room  = '{name}', count_room  = '{count}', money_room = '{money}', style_room = '{style}' where id = '{id}'";
                    var command = new SqlCommand(changeQuary, database.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            database.closeConnection();
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            Updating();
        }
        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"select * from room where concat(id, kind_room, name_room, count_room, money_room, style_room) like '%" + txt_poisk.Text + "%'";
            SqlCommand com = new SqlCommand(searchString, database.getConnection());
            database.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow(dgw, read);
            }

            read.Close();
        }
        private void txt_poisk_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                txt_schet.Text = row.Cells[0].Value.ToString();
                txt_laguna.Text = row.Cells[1].Value.ToString();
                txt_label.Text = row.Cells[2].Value.ToString();
                txt_mesta.Text = row.Cells[3].Value.ToString();
                txt_price.Text = row.Cells[4].Value.ToString();
                txt_style.Text = row.Cells[5].Value.ToString();

            }
        }

        private void txt_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if( (l < '0' || l > '9') && l != '\b' && l != ' ')
            {
                e.Handled = true;
            }
        }

        private void txt_mesta_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < '0' || l > '9') && l != '\b' && l != ' ')
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.ShowDialog();
 
            Application.Exit();
        }
    }
}
