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

namespace Thang_N9_Manager_StatisticalProduct
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        public Form1()
        {
            if(instance == null)
            {
                instance = this;
            }
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2J4GSB2;Initial Catalog=Product;Integrated Security=True");
        //kết nối csdl
        public void connect()
        {
            con.Open();

            string sql = "Select * from Stuff ";

            SqlCommand comm = new SqlCommand(sql, con);
            comm.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();

            da.Fill(dt);

            con.Close();
            dataGridView1.ClearSelection();
            dataGridView1.DataSource = dt;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            connect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            this.Show();
        }
    }
}
