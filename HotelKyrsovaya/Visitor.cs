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
    enum RowStating
    {
        Existed,
        Now,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class Visitor : Form
    {
        DataBase database = new DataBase();
        int selectedRow;
        public Visitor()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id_visitor", "Счетчик посетителя");
            dataGridView1.Columns.Add("lastname", "Фамилия");
            dataGridView1.Columns.Add("naming", "Имя");
            dataGridView1.Columns.Add("otchestvo", "Отчество");
            dataGridView1.Columns.Add("ceria", "Серия паспорта");
            dataGridView1.Columns.Add("number", "Номер паспорта");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetInt32(4), record.GetInt32(5), RowState.ModifiedNew);
        }
        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select * from visitor";
            SqlCommand command = new SqlCommand(queryString, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }
        private void Visitor_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);

        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            Add_Visitor addvis = new Add_Visitor();
            addvis.ShowDialog();

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"select * from visitor where concat(id_visitor, lastname, naming, otchestvo, ceria, number) like '%" + txt_poisk.Text + "%'";
            SqlCommand com = new SqlCommand(searchString, database.getConnection());
            database.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow(dgw, read);
            }

            read.Close();
        }
        private void txt_poisk_TextChanged_1(object sender, EventArgs e)
        {
            Search(dataGridView1);
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
                    var deleteQuery = $"delete from visitor where id_visitor = {id}";
                    var command = new SqlCommand(deleteQuery, database.getConnection());
                    command.ExecuteNonQuery();
                }
                if (rowState == RowState.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var fam = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var nam = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var otec = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var ceria = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    var nomer = dataGridView1.Rows[index].Cells[5].Value.ToString();


                    var changeQuary = $"update visitor set lastname = '{fam}', naming  = '{nam}', otchestvo  = '{otec}', ceria = '{ceria}', number = '{nomer}' where id_visitor = '{id}'";
                    var command = new SqlCommand(changeQuary, database.getConnection());
                    command.ExecuteNonQuery();
                }
            }
        }
            private void btn_save_Click(object sender, EventArgs e)
            {
                Updating();
            }
        private void Change()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var schetpos  = txt_schetpos.Text;
            var fam = txt_fam.Text;
            var name = txt_name.Text;
            var otec = txt_otec.Text;
            var seria = txt_seria.Text;
            var number = txt_number.Text;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {

                dataGridView1.Rows[selectedRowIndex].SetValues(schetpos, fam, name, otec, seria, number);
                dataGridView1.Rows[selectedRowIndex].Cells[6].Value = RowState.Modified;
            }
        }
        private void btn_update_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                txt_schetpos.Text = row.Cells[0].Value.ToString();
                txt_fam.Text = row.Cells[1].Value.ToString();
                txt_name.Text = row.Cells[2].Value.ToString();
                txt_otec.Text = row.Cells[3].Value.ToString();
                txt_seria.Text = row.Cells[4].Value.ToString();
                txt_number.Text = row.Cells[5].Value.ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.ShowDialog();

            Application.Exit();
        }

        private void txt_seria_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < '0' || l > '9') && l != '\b' && l != ' ')
            {
                e.Handled = true;
            }
        }

        private void txt_number_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < '0' || l > '9') && l != '\b' && l != ' ')
            {
                e.Handled = true;
            }
        }
    }
}
