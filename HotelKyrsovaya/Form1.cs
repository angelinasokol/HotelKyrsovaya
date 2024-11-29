using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelKyrsovaya
{
    public partial class Form1 : Form
    {
        DataBase database = new DataBase();
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Btn_room_Click(object sender, EventArgs e)
        {
            Room rmfrm = new Room();
            this.Hide();
            rmfrm.ShowDialog();
            Application.Exit();
        }

        private void Btn_visitor_Click(object sender, EventArgs e)
        {
            Visitor vstfrm = new Visitor();
            this.Hide();
            vstfrm.ShowDialog();
            Application.Exit();
        }

        private void btn_bron_Click(object sender, EventArgs e)
        {
            Bron brnfrm = new Bron();
            this.Hide();
            brnfrm.ShowDialog();
            Application.Exit();
        }
    }
}
