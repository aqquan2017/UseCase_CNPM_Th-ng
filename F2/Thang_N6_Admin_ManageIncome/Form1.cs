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

namespace Thang_N6_Admin_ManageIncome
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2J4GSB2;Initial Catalog=Product;Integrated Security=True");
        //kết nối csdl
        public void connect()
        {
            con.Open();

            string sql = "Select * from Income ";

            SqlCommand comm = new SqlCommand(sql, con);
            comm.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();

            da.Fill(dt);

            con.Close();

            dataGridView1.DataSource = dt;

        }

        private void Quan_Click(object sender, EventArgs e)
        {
            connect();
        }
    }
}
