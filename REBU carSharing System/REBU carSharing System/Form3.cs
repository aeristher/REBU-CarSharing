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

namespace REBU_carSharing_System
{
    public partial class Form3 : Form
    {
        string connectionString = "Data Source=YEN\\YEN;Initial Catalog=REBUDB;Integrated Security=True";


        public Form3()
        {
            InitializeComponent();
            userControl11.BringToFront();
            timer1.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Do you want to log off?", "Log Off", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    break;

                case DialogResult.No: return;
            }
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userControl11.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userControl21.BringToFront();
        }

        private void userControl21_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            userControl31.BringToFront();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string strTime;
            string strDate;

            strTime = DateTime.Now.ToLongDateString();
            strDate = DateTime.Now.ToLongTimeString();

            lblTime.Text = strTime + "   " + strDate;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userControl51.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            userControl61.BringToFront();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            userControl71.BringToFront();
        }
    }
}
