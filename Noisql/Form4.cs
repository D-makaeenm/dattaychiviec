using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Noisql
{
    public partial class Form4 : Form
    {
        public Form4()
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
        private void button1_Click(object sender, EventArgs e)
        {
            string mancc = textBox1.Text;
            string tenncc = textBox2.Text;
            string diachi = textBox3.Text;
            string dienthoai = textBox4.Text;
            ketnoi.Open();
            sql = @"insert into NCC values
            (N'" + mancc + "', N'" + tenncc + "', N'" + diachi + "', N'" + dienthoai + "')";
            MessageBox.Show("Thêm thành công!!!");
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();
            ketnoi.Open();
            sql = "select* from NCC";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mancc = textBox1.Text;
            string tenncc = textBox2.Text;
            string diachi = textBox3.Text;
            string dienthoai = textBox4.Text;
            string vitri = textBox11.Text;
            ketnoi.Open();
            sql = @"update NCC
            set 
            [Mã NCC] = N'" + mancc + "' ,[Tên NCC] =  N'" + tenncc + "' ,[Địa chỉ]= N'" + diachi + "'  ,[Điện thoại]= N'" + dienthoai + "'" + $" where [Mã NCC] = N'" + vitri + " '";
            MessageBox.Show("Đã sửa thành công !!");
            textBox11.Clear();
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();
            ketnoi.Open();
            sql = "select* from NCC";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string lenhxoa = "delete NCC where [Mã NCC] ='" + ma + "'";

            thuchien = new SqlCommand(lenhxoa, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();

            ketnoi.Open();
            sql = "select* from NCC";
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
        }

        private void button5_Click(object sender, EventArgs e)
        {
            xoa();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = "select* from NCC";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            ma = row.Cells[0].Value.ToString();
        }
    }
}
