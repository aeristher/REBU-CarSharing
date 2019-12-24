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
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace REBU_carSharing_System
{
    public partial class Form4 : Form
    {
       
          
        public Form4()
        {
            InitializeComponent();
           
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.Clear();
            textBox6.PasswordChar = '*';
        }

        private void textBox8_Click(object sender, EventArgs e)
        {
            textBox8.Clear();
            textBox8.PasswordChar = '*';
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strEmail = textBox1.Text;
            string strUser = textBox5.Text;



            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("your_email_address_here");
            mail.To.Add(new MailAddress(strEmail));
            mail.Subject = "Welcome to REBU";
            mail.Body = "Congratulations, " + strUser + "!!!" + "\n" +

                 "\n"
                +

                "You are one step closer to getting from one place to another in a breeze!" +
                "\n" + "Please select a time in the main menu once you log in.  "
                + "\n"
                + "\n"
                + "Sincerely," + "\n" + "REBU :)"



                ;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("your_email_here", "your_password_here");

            try
            {
                smtp.Send(mail);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            button3.Enabled = false;

            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=YEN\YEN;Initial Catalog=REBUDB;Integrated Security=True";

            string query = "Select * from users where username='" + textBox2.Text + "'";

            SqlDataAdapter sda = new SqlDataAdapter(query, scn);

            DataTable dtbl = new DataTable();

            sda.Fill(dtbl);

            if (dtbl.Rows.Count > 0)
            {
                MessageBox.Show("Please choose a different username");

                return;
            }

            else if (textBox5.Text == "" || textBox7.Text == "" || textBox2.Text == "" || textBox1.Text == "" || textBox6.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("Please do not leave any fields blank.");

                return;
            }
            else if (textBox5.Text == "First Name" || textBox7.Text == "Last Name" || textBox2.Text == "Username" || textBox1.Text == "E-mail" || textBox6.Text == "Password" || textBox8.Text == "Re-type Password")
            {
                MessageBox.Show("Please enter values for the required fields");
                return;
            }

            else if (textBox8.Text != textBox6.Text)
            {
                MessageBox.Show("Passwords do not match.");

                return;
            }

            else
            {
             
            }

            this.Hide();
            Form3 form3 = new Form3();
            form3.ShowDialog();
            this.Close();
        }
        //public static void AddUser(string username, string password, string firstname, string lastname, string emailaddress)
        //{

        //    using (SqlConnection openCon = new SqlConnection(ConfigurationManager.ConnectionStrings["@Data Source=DELPHI\\SQLEXPRESS;Initial Catalog=BRMCHospital;Integrated Security=True"].ConnectionString))
        //    {


        //        SqlCommand querySaveStaff = new SqlCommand("INSERT into users (Username,Password,FirstName,LastName,EmailAddress) VALUES (@Username,HASHBYTES('SHA1', CONVERT(nvarchar(4000),@Password)),@FirstName,@LastName,@EmailAddress)", openCon);
        //        querySaveStaff.Parameters.Add("@Username", SqlDbType.VarChar);
        //        querySaveStaff.Parameters["@Username"].Value = username;
        //        querySaveStaff.Parameters.Add("@Password", SqlDbType.VarChar);
        //        querySaveStaff.Parameters["@Password"].Value = password;
        //        querySaveStaff.Parameters.Add("@FirstName", SqlDbType.VarChar);
        //        querySaveStaff.Parameters["@FirstName"].Value = firstname;
        //        querySaveStaff.Parameters.Add("@LastName", SqlDbType.VarChar);
        //        querySaveStaff.Parameters["@LastName"].Value = lastname;
        //        querySaveStaff.Parameters.Add("@EmailAddress", SqlDbType.VarChar);
        //        querySaveStaff.Parameters["@EmailAddress"].Value = emailaddress;


        //        //   querySaveStaff.Connection = openCon;
        //        //   querySaveStaff.Parameters.Add("@staffName", SqlDbType.VarChar, 30).Value = name;

        //        openCon.Open();
        //        querySaveStaff.ExecuteNonQuery();
        //        openCon.Close();
        //        querySaveStaff.Dispose();

        //    }

        }

        //public static SqlDataReader GetAListOfUsers()
        //{

        //    using (SqlConnection openCon = new SqlConnection())
        //    {


        //        using (SqlCommand querySaveStaff = new SqlCommand("select * from users"))
        //        {
        //            querySaveStaff.Connection = openCon;

        //            openCon.Open();
        //            SqlDataReader results = querySaveStaff.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        //            return results;
        //        }
        //    }

        //}
    } 

            //  Utility.AddUser(textBox2.Text, textBox6.Text, textBox5.Text, textBox7.Text, textBox1.Text);
            
       

  
   
