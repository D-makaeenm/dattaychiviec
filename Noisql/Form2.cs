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
using Microsoft.Data.SqlClient;

namespace Noisql
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string chuoiketnoi = @"Data Source=DuyVPro;Initial Catalog=BTL;Integrated Security=True;Trust Server Certificate=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        DataTable dt;
        String ma;


        private void button2_Click(object sender, EventArgs e)
        {
            string makh = textBox1.Text;
            string tenkh = textBox2.Text;
            string masp = textBox3.Text;
            string diachi = textBox4.Text;
            string dienthoai = textBox5.Text;
            string tennguoiban = textBox6.Text;
            string mst = textBox7.Text;
            string stk = textBox8.Text;
            string slban = textBox9.Text;
            string ngayban = textBox10.Text;
            string vitri = textBox11.Text;
            ketnoi.Open();
            sql = @"update HDX
	        SET
            [Mã khách hàng] = N'" + makh + "' ,[Tên khách hàng]=  N'" + tenkh + "' ,[Mã sản phẩm]= N'" + masp + "'  ,[Địa chỉ]= N'" + diachi + "'  ,[Điện thoại]=N'" + dienthoai + "' ,[Tên người bán] = N'" + tennguoiban + "', [Mã số thuế]= N'" + mst + "', [Số tài khoản] = N'" + stk + "', [Số lượng bán] = N'" + slban + "', [Ngày bán] = N'" + ngayban + "'" + $" where [Mã khách hàng] = N'" + vitri + " '";
            MessageBox.Show(sql);
            textBox11.Clear();
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();

            ketnoi.Open();
            sql = "select* from HDX";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string makh = textBox1.Text;
            string tenkh = textBox2.Text;
            string masp = textBox3.Text;
            string diachi = textBox4.Text;
            string dienthoai = textBox5.Text;
            string tennguoiban = textBox6.Text;
            string mst = textBox7.Text;
            string stk = textBox8.Text;
            string slban = textBox9.Text;
            string ngayban = textBox10.Text;
            ketnoi.Open();
            sql = @"insert into HDX
	        values
            (N'" + makh + "', N'" + tenkh + "', N'" + masp + "', N'" + diachi + "',N'" + dienthoai + "',N'" + tennguoiban + "',N'" + mst + "',N'" + stk + "', N'" + slban + "',N'" + ngayban + "')";
            MessageBox.Show("THÊM THÀNH CÔNG!!");
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();
            ketnoi.Open();
            sql = "select* from HDX";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }


        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string lenhxoa = "delete HDX where [Mã khách hàng] ='" + ma + "'";

            thuchien = new SqlCommand(lenhxoa, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();

            ketnoi.Open();
            sql = "select* from HDX";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
        }
        public void hienthi()
        {
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            dt = new DataTable();
            dt.Load(docdulieu);
        }
        public void xoa()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();

        }
        private void button5_Click(object sender, EventArgs e)
        {
            xoa();
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = "select* from HDX";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            ma = row.Cells[0].Value.ToString();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
