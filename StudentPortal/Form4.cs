using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace StudentPortal
{
    public partial class Form4 : Form

    {
        MySqlConnection c;
        MySqlCommand cmd;
        MySqlDataReader reader;
      

        public Form4()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string username = Form1.username;
            string cs = "host=localhost;user=root;password=;database=regform;";
            c = new MySqlConnection(cs);
            c.Open();
            string select = "SELECT * FROM reginfos WHERE Username = '" + username + "'";
            cmd = new MySqlCommand(select, c);
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
            }
            dataGridView1.Refresh();

        }
    }
}
