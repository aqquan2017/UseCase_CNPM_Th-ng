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

namespace Thang_CNPM
{
    public partial class Form1 : Form
    {
        //Kỹ thuật design patterm : SingleTon
        public static Form1 instance;
        public Form1()
        {
            instance = this;
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2J4GSB2;Initial Catalog=Product;Integrated Security=True");

        //kết nối csdl
        public void connect()
        {
            con.Open();

            string sql = "Select * from Product ";

            SqlCommand comm = new SqlCommand(sql, con);
            comm.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();

            da.Fill(dt);

            con.Close();

            dataGridView2.DataSource = dt;

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            connect();
        }


        //Chức năng tìm kiếm sản phẩm
        private void button2_Click(object sender, EventArgs e)
        {
        //    con.Open();
            string txt = textBox1.Text;
            if(txt == "")
            {
                label3.Text = "Vui lòng nhập thông tin sản phẩm !";
                return;
            }

            string sql = "Select * from Product where name='"+txt+"' ";

            SqlCommand comm = new SqlCommand(sql, con);
            comm.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();

            da.Fill(dt);

        //    con.Close();

            dataGridView2.ClearSelection();
            dataGridView2.DataSource = dt;

            if (dataGridView2.RowCount == 1)
            {
                label3.Text = "Không có sản phẩm nào";
            }
            else label3.Text = "Tìm thành công";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
         //   this.Close();
        }

        
    }
}
