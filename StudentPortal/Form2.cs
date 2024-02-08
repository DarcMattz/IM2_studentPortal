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

namespace StudentPortal
{
    public partial class Form2 : Form
    {

        MySqlConnection c;
        MySqlCommand cmd;
        MySqlDataReader reader;


        public Form2()
        {
            InitializeComponent();
        }

        public static string username = "";
        public static string password = "";
        public static string name = "";
        public static string sex = "";

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                string cs = "host=localhost;user=root;password=;database=regform";
                c = new MySqlConnection(cs);
                c.Open();
            }catch (Exception ex)
            {
                MessageBox.Show("can't connect to the database");
            }

            /*string query = "SELECT * FROM reginfos";
            cmd = new MySqlCommand(query, c);
            reader = cmd.ExecuteReader();*/

            c.Close();    
            }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string name = textBox3.Text;
            string sex ="";

            if (radioButton1.Checked)
            {
                sex = radioButton1.Text;
            }else if (radioButton2.Checked) {
                sex = radioButton2.Text;
            }
            try { 
            c.Open();
            string input = "INSERT  INTO reginfos( Username, Password, Name, Sex) VALUES('"+username+"','"+password+"','"+name+"','"+sex+"')";
            cmd = new MySqlCommand(input, c);
            reader = cmd.ExecuteReader();
            MessageBox.Show("Register Successfull!");
            }catch (MySqlException ex) {
            MessageBox.Show("Failed!");
            }
            c.Close();
            Form1 form1 = new Form1();
            this.Close();
            form1.Show();
        }
    }
}
