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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2J4GSB2;Initial Catalog=Product;Integrated Security=True");
        
        void addProduct()
        {
            label1.Text = "THÊM SẢN PHẨM";
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
                string sqlAdd = "INSERT INTO Product VALUES (@name , @cost , @number,@code,@unit)";
                SqlCommand cmd = new SqlCommand(sqlAdd, con);
                cmd.Parameters.AddWithValue("name", textBox1.Text);
                cmd.Parameters.AddWithValue("cost", float.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("number", int.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("code", textBox2.Text);
                cmd.Parameters.AddWithValue("unit", textBox5.Text);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException s)
            {
                //Đặt khóa chính là name nên nếu lưu trùng tên sẽ throw ra lỗi
                label7.Text = "Sản phẩm đã tồn tại !";
                Console.WriteLine(s.Message);
                return;
            }

            label7.Text = "Sản phẩm thêm thành công !";
            Form1.instance.connect();
        }
        void editProduct() {
            label1.Text = "SỬA SẢN PHẨM";
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
                string sqlAdd = "UPDATE Product SET name=@name, cost=@cost, number=@number,code=@code,unit=@unit WHERE name=@name ";
                SqlCommand cmd = new SqlCommand(sqlAdd, con);
                cmd.Parameters.AddWithValue("name", textBox1.Text);
                cmd.Parameters.AddWithValue("cost", float.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("number", int.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("code", textBox2.Text);
                cmd.Parameters.AddWithValue("unit", textBox5.Text);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException s)
            {
                Console.WriteLine(s.Message);
             //   label7.Text = "Sản phẩm đã tồn tại !";
                return;
            }

            label7.Text = "Sản phẩm sửa thành công !";
            Form1.instance.connect();

        }
        void deleteProduct() {
            label1.Text = "XÓA SẢN PHẨM";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
                string sqlAdd = "DELETE FROM Product WHERE name=@name ";
                SqlCommand cmd = new SqlCommand(sqlAdd, con);
                cmd.Parameters.AddWithValue("name", textBox1.Text);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException s)
            {
                Console.WriteLine(s.Message);
                return;
            }

            label7.Text = "Sản phẩm xóa thành công !";
            Form1.instance.connect();
        }

        //Xử lý sự kiện nhân nút
        private void button1_Click(object sender, EventArgs e)
        {
            //thêm
            if (comboBox1.Text == "ADD")
            {
                addProduct();
            }
            //sửa
            else if (comboBox1.Text == "EDIT")
            {
                editProduct();
            }
            //xóa
            else if (comboBox1.Text == "DELETE")
            {
                deleteProduct();
            }
            //yêu cầu user nhập chức năng
            else label7.Text = "Chọn chức năng !!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.instance.Show();
            this.DestroyHandle();
        }

      
    }
}
