using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace REBU_carSharing_System
{
    public partial class Form1 : Form
    {
        static int attempt = 3;
        public Form1()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            InitializeComponent();
            t.Abort();
        }

        public void StartForm()
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (attempt == 0)
            {
                lbl_Msg.Text = ("        Out of Attempts");
                btnLogin.Enabled = false;
                return;

            }
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=YEN\YEN;Initial Catalog=REBUDB;Integrated Security=True";
            SqlCommand scmd = new SqlCommand("select count (*) as cnt from dbo.Passenger where username=@usr and password=@pwd", scn);
            scmd.Parameters.Clear();
            scmd.Parameters.AddWithValue("@usr", textBox1.Text);
            scmd.Parameters.AddWithValue("@pwd", textBox3.Text);
            scn.Open();

            if (scmd.ExecuteScalar().ToString() == "1")
            {
                  MessageBox.Show("Welcome!");
                this.Hide();
                Form3 form3 = new Form3();
                form3.ShowDialog();
                this.Close();
            }
            else
            {
                 MessageBox.Show("Your login credentials is incorrect. Please try again.");
                lbl_Msg.Text = ("You have" + " " + Convert.ToString(attempt) + " attempts left.");
                --attempt;
                textBox1.Clear();
                textBox3.Clear();


            }
            scn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.ShowDialog();
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox3.PasswordChar = '*';
        }
    }
}
