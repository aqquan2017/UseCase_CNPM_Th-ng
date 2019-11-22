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

namespace Thang_N3_Manager_WatchAnalyst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2J4GSB2;Initial Catalog=Product;Integrated Security=True");
        //kết nối csdl
        public void connect(int state)
        {
            con.Open();

            string sql = "";
            if(state == 0)
            {
                sql = "Select * from TransactionX";
            }
            else if(state == 1)
            {
                sql = "Select * from TransactionX where bitState='" + false + "'";
            }
            else if (state == 2)
            {
                sql = "Select * from TransactionX where bitState='" + true + "'";
            }
            else if (state == 3)
            {
                sql = "Select * from TransactionX where Time='" + textBox1.Text + "'";
            }

            SqlCommand comm = new SqlCommand(sql, con);
            comm.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();

            da.Fill(dt);

            con.Close();
            dataGridView1.ClearSelection();
            dataGridView1.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                connect(0);
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                connect(1);
            }
            else if (comboBox1.SelectedIndex == 2)
            {               
                connect(2);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect(3);

            if (dataGridView1.RowCount > 1)
            {
                label3.Text = "Dữ liệu sẵn sàng";
            }
            else label3.Text = "Dữ liệu không tồn tại";
        }

        
    }
}
