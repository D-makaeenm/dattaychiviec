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
    public partial class Form3 : Form
    {
        public Form3()
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
            string mahh = textBox1.Text;
            string mans = textBox2.Text;
            string tenns = textBox3.Text;
            string masp = textBox4.Text;
            string ngayhuy = textBox5.Text;
            string tenkho = textBox6.Text;
            string makho = textBox7.Text;
            string slhuy = textBox8.Text;
            string dongiahuy = textBox9.Text;
            ketnoi.Open();
            sql = @"insert into PHHH
	        values
            (N'" + mahh + "', N'" + mans + "', N'" + tenns + "', N'" + masp + "',N'" + ngayhuy + "',N'" + tenkho + "',N'" + makho + "',N'" + slhuy + "', N'" + dongiahuy + "')";
            MessageBox.Show("THÊM THÀNH CÔNG!!");
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();
            ketnoi.Open();
            sql = "select* from PHHH";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mahh = textBox1.Text;
            string mans = textBox2.Text;
            string tenns = textBox3.Text;
            string masp = textBox4.Text;
            string ngayhuy = textBox5.Text;
            string tenkho = textBox6.Text;
            string makho = textBox7.Text;
            string slhuy = textBox8.Text;
            string dongiahuy = textBox9.Text;
            string vitri = textBox11.Text;
            ketnoi.Open();
            sql = @"update PHHH
	        SET
            [Mã hàng hủy] = N'" + mahh + "' ,[Mã nhân sự]=  N'" + mans + "' , [Tên nhân sự]= N'" + tenns + "'  , [Mã sản phẩm]= N'" + masp + "'  ,[Ngày hủy] =N'" + ngayhuy + "' , [Tên kho] = N'" + tenkho + "', [Mã kho] = N'" + makho + "', [Số lượng hủy] = N'" + slhuy + "', [Đơn giá hủy] = N'" + dongiahuy + "'" + $" where [Mã hàng hủy] = N'" + vitri + " '";
            MessageBox.Show("Đã sửa thành công !!!");
            textBox11.Clear();
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();

            ketnoi.Open();
            sql = "select* from PHHH";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string lenhxoa = "delete PHHH where [Mã hàng hủy] ='" + ma + "'";

            thuchien = new SqlCommand(lenhxoa, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();

            ketnoi.Open();
            sql = "select* from PHHH";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            xoa();
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

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = "select* from PHHH";
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
