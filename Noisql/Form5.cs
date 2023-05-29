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
    public partial class Form5 : Form
    {
        public Form5()
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
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sohdn = textBox1.Text;
            string masp = textBox2.Text;
            string ngaynhap = textBox3.Text;
            string mancc = textBox4.Text;
            string slnhap = textBox6.Text;
            string dongia = textBox7.Text;
            string dvt = textBox8.Text;
            string vitri = textBox11.Text;
            ketnoi.Open();
            sql = @"update HDNhap
            set 
            [Số HĐN] = N'" + sohdn + "' ,[Mã SP] =  N'" + masp + "' ,[Ngày nhập]= N'" + ngaynhap + "'  ,[Địa chỉ]= N'" + mancc + "'  ,[Điện thoại]=N'" + slnhap + "' ,[Tên người bán] = N'" + dongia + "', [Mã số thuế]= N'" + dvt + "'" + $" where [Mã khách hàng] = N'" + vitri + " '";
            MessageBox.Show("Đã sửa thành công !!");
            textBox11.Clear();
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();
            ketnoi.Open();
            sql = "select* from HDNhap";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sohdn = textBox1.Text;
            string masp = textBox2.Text;
            string ngaynhap = textBox3.Text;
            string mancc = textBox4.Text;
            string slnhap = textBox6.Text;
            string dongia = textBox7.Text;
            string dvt = textBox8.Text;
            string vitri = textBox11.Text;
            ketnoi.Open();
            sql = @"insert into HDNhap values
            (N'" + sohdn + "', N'" + masp + "', N'" + ngaynhap + "', N'" + mancc + "',N'" + slnhap + "',N'" + dongia + "',N'" + dvt + "',N'" + vitri + "')";
            MessageBox.Show("Thêm thành công!!!");
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();
            ketnoi.Open();
            sql = "select* from HDNhap";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string lenhxoa = "delete HDNhap where [Số HĐN] ='" + ma + "'";

            thuchien = new SqlCommand(lenhxoa, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();

            ketnoi.Open();
            sql = "select* from HDNhap";
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
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            xoa();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = "select* from HDNhap";
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
