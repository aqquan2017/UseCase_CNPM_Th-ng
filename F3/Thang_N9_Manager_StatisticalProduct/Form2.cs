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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2J4GSB2;Initial Catalog=Product;Integrated Security=True");
        void editProduct() {           
            if (textBox1.Text == "")
            {
                label7.Text = "Vui lòng nhập tên sản phẩm";
                return;
            }
            else if (textBox2.Text == "")
            {
                label7.Text = "Vui lòng nhập mã sản phẩm";
                return;
            }
            else if (textBox3.Text == "")
            {
                label7.Text = "Vui lòng nhập số lượng sản phẩm";
                return;
            }
            else if (textBox5.Text == "")
            {
                label7.Text = "Vui lòng nhập đơn vị sản phẩm";
                return;
            }

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
                string sqlAdd = "UPDATE Stuff SET Day=@Day, Name=@Name, Quantity=@Quantity,Unit=@Unit WHERE Name=@Name ";
                SqlCommand cmd = new SqlCommand(sqlAdd, con);
                cmd.Parameters.AddWithValue("Name", textBox1.Text);
                cmd.Parameters.AddWithValue("Day", textBox2.Text);
                cmd.Parameters.AddWithValue("Quantity", int.Parse(textBox3.Text));              
                cmd.Parameters.AddWithValue("Unit", textBox5.Text);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException s)
            {
                Console.WriteLine(s.Message);
                label7.Text = "Sản phẩm đã tồn tại !";
                return;
            }

            label7.Text = "Sản phẩm sửa thành công !";

        }

        //Xử lý sự kiện nhân nút
        private void button1_Click(object sender, EventArgs e)
        {
            //sửa
            editProduct();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.instance.connect();
            
            this.DestroyHandle();
        }

        
    }
}
