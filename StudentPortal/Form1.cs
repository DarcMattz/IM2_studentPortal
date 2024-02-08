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
using Org.BouncyCastle.Utilities.Encoders;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace StudentPortal
{
    public partial class Form1 : Form
    {

        MySqlConnection c;
        MySqlCommand cmd;
        MySqlDataReader reader;
        public static string username = "";
        public static string password = "";
        


        public Form1()
        {
            InitializeComponent();
        }

        
       

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                string cs = "host=localhost;user=root;password=;database=im_exam";
                c = new MySqlConnection(cs);
                c.Open();
            }
            catch (MySqlException ex){
                MessageBox.Show("can't connect to the database");
            }

            string query = "SELECT * FROM account";
            cmd = new MySqlCommand(query , c);
            reader = cmd.ExecuteReader();

            c.Close();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           bool okay = false;
           username = textBox1.Text;
           string password = textBox2.Text;
            string cs = "host=localhost;user=root;password=;database=im_exam";
            c = new MySqlConnection(cs);
            c.Open();
            string select = "SELECT * FROM account WHERE email = '"+username+ "'";
            cmd = new MySqlCommand(select , c);
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                if (reader.GetString(0) == username && reader.GetString(1) == password)
                {
                    Form3 form3 = new Form3();
                    MessageBox.Show("Login Successful!");
                    okay = true;
                    form3.Show();
                    this.Hide();
                    break;
                }
                if (!okay)
                {
                    MessageBox.Show("Login Failed");
                    textBox1.Text = null;
                    textBox2.Text = null;
                }
            }
        }
    }
}
