using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace REBU_carSharing_System
{
    public partial class UserControl7 : UserControl
    {
        string connectionString = "Data Source=YEN\\YEN;Initial Catalog=REBUDB;Integrated Security=True";

        public UserControl7()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from vehicle", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                dgv1.DataSource = dtbl;
            }
        }

        private void UserControl7_Load(object sender, EventArgs e)
        {

        }
    }
}
