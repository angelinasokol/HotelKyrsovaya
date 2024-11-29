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
    public partial class Bron : Form
    {
        DataBase database = new DataBase();
        public Bron()
        {
            InitializeComponent();
        }
        private string stringCon()
        {
            return @"Data Source=DESKTOP-CAQK9OI;Initial Catalog=hotel;Integrated Security=True";
        }

        private void btn_zagrom_Click(object sender, EventArgs e)
        {

            var queryListCodeRequest = "SELECT * FROM room";
            loadElementToComboBox(queryListCodeRequest, "id", box_room);
        }
        public void loadElementToComboBox(string stringQuery, string column, ComboBox myBox)
        {
            List<string> columnValues = GetColumnValues(stringQuery, column);
            myBox.Items.AddRange(columnValues.ToArray());
        }
        public List<string> GetColumnValues(string query, string columnName)
        {
            List<string> columnValues = new List<string>();

            SqlConnection myCon = new SqlConnection(stringCon());
            myCon.Open();
            using (SqlCommand command = new SqlCommand(query, myCon))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    object columnValueObject = reader.GetValue(reader.GetOrdinal(columnName));
                    string columnValue = columnValueObject != DBNull.Value ? columnValueObject.ToString() : "";
                    columnValues.Add(columnValue);
                }
            }
            return columnValues;
        }

        private void btn_zagvis_Click(object sender, EventArgs e)
        {
            var queryListCode = "SELECT * FROM visitor";
            loadElementToCombo(queryListCode, "id_visitor", box_visitor);
        }
        public void loadElementToCombo(string stringQuery, string column, ComboBox boxi)
        {
            List<string> columnValues = GetColumnValues(stringQuery, column);
            boxi.Items.AddRange(columnValues.ToArray());
        }
        public List<string> GetColumnValue(string query, string columnName)
        {
            List<string> columnValues1 = new List<string>();

            SqlConnection myCon = new SqlConnection(stringCon());
            myCon.Open();
            using (SqlCommand com = new SqlCommand(query, myCon))
            {
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    object columnValueObj = reader.GetValue(reader.GetOrdinal(columnName));
                    string columnVal = columnValueObj != DBNull.Value ? columnValueObj.ToString() : "";
                    columnValues1.Add(columnVal);
                }
            }
            return columnValues1;
        }

        private void CreateColumns3()
        {
            dataGridView3.Columns.Add("id", "Счетчик номера");
            dataGridView3.Columns.Add("kind_room", "Тип номера");
            dataGridView3.Columns.Add("name_room", "Название номера");
            dataGridView3.Columns.Add("count_room", "Количество мест");
            dataGridView3.Columns.Add("money_room", "Цена");
            dataGridView3.Columns.Add("style_room", "Стиль номера");
            dataGridView3.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRow3(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetInt32(3), record.GetInt32(4), record.GetString(5), RowState.ModifiedNew);
        }
        private void RefreshDataGrid3(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select * from room";
            SqlCommand command = new SqlCommand(queryString, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow3(dgw, reader);
            }
            reader.Close();
        }
        private void CreateColumns2()
        {
            dataGridView2.Columns.Add("id_visitor", "Счетчик посетителя");
            dataGridView2.Columns.Add("lastname", "Фамилия");
            dataGridView2.Columns.Add("naming", "Имя");
            dataGridView2.Columns.Add("otchestvo", "Отчество");
            dataGridView2.Columns.Add("ceria", "Серия паспорта");
            dataGridView2.Columns.Add("number", "Номер паспорта");
            dataGridView2.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRow2(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetInt32(4), record.GetInt32(5), RowState.ModifiedNew);
        }
        private void RefreshDataGrid2(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select * from visitor";
            SqlCommand command = new SqlCommand(queryString, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow2(dgw, reader);
            }
            reader.Close();
        }
        private void CreateColumns1()
        {
            dataGridView1.Columns.Add("id_bron", "Счетчик брони");
            dataGridView1.Columns.Add("id", "Счетчик номера");
            dataGridView1.Columns.Add("id_visitor", "Счетчик посетителя");
            dataGridView1.Columns.Add("datazaezd", "Дата заезда");
            dataGridView1.Columns.Add("dataexit", "Дата выезда");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRow1(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetInt32(2), record.GetDateTime(3), record.GetDateTime(4), RowState.ModifiedNew);
        }
        private void RefreshDataGrid1(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select * from bron";
            SqlCommand command = new SqlCommand(queryString, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow1(dgw, reader);
            }
            reader.Close();
        }

        private void Bron_Load(object sender, EventArgs e)
        {
            CreateColumns1();
            RefreshDataGrid1(dataGridView1);
            CreateColumns2();
            RefreshDataGrid2(dataGridView2);
            CreateColumns3();
            RefreshDataGrid3(dataGridView3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.ShowDialog();

            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshDataGrid1(dataGridView1);
        }
        private void deleteRow()
                    {
                        int index = dataGridView1.CurrentCell.RowIndex;
                        dataGridView1.Rows[index].Visible = false;
                        if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;
                    }
        private void button4_Click(object sender, EventArgs e)
        {
            deleteRow();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                database.openConnection();

                var id = box_room.Text;
                var id_visitor = box_visitor.Text;
                var datazaezd = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                var dataexit = dateTimePicker2.Value.ToString("yyyy-MM-dd");

                // Проверка наличия брони на указанные даты
                var checkQuery = $"select * from bron where id = '{id}' and ((datazaezd <= '{datazaezd}' and dataexit >= '{datazaezd}') or (datazaezd <= '{dataexit}' and dataexit >= '{dataexit}'))";
                var checkCommand = new SqlCommand(checkQuery, database.getConnection());
                var reader = checkCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("Номер уже забронирован на указанные даты!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reader.Close();
                    database.closeConnection();
                    return;
                }
                reader.Close();

                // Добавление новой брони
                var addQuery = $"insert into bron (id, id_visitor, datazaezd, dataexit) values ('{id}', '{id_visitor}', '{datazaezd}', '{dataexit}')";
                var addCommand = new SqlCommand(addQuery, database.getConnection());
                addCommand.ExecuteNonQuery();

                MessageBox.Show("Запись успешно создана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                database.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }
        private void Updating()
        {
            database.openConnection();
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[5].Value;
                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from bron where id_bron = {id}";
                    var command = new SqlCommand(deleteQuery, database.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            database.closeConnection();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Updating();
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
                ReadSingleRow2(dgw, read);
            }

            read.Close();
        }

        private void txt_poisk_TextChanged_1(object sender, EventArgs e)
        {
            Search(dataGridView2);
        }
    }
}
