using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Noisql
{
    public partial class Form6 : Form
    {
        public Form6()
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
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string masp = textBox1.Text;
            string tensp = textBox2.Text;
            string dvt = textBox3.Text;
            ketnoi.Open();
            sql = @"insert into DMSP values
            (N'" + masp + "', N'" + tensp + "', N'" + dvt + "')";
            MessageBox.Show("Thêm thành công!!!");
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();
            ketnoi.Open();
            sql = "select* from DMSP";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string masp = textBox1.Text;
            string tensp = textBox2.Text;
            string dvt = textBox3.Text;
            string vitri = textBox11.Text;
            ketnoi.Open();
            sql = @"update DMSP
            set 
            [Mã SP] = N'" + masp + "' ,[Tên SP] =  N'" + tensp + "' ,[Đơn vị tính]= N'" + dvt + "'" + $" where [Mã SP] = N'" + vitri + " '";
            MessageBox.Show("Đã sửa thành công !!");
            textBox11.Clear();
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();
            ketnoi.Open();
            sql = "select* from DMSP";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string lenhxoa = "delete DMSP where [Mã SP] ='" + ma + "'";

            thuchien = new SqlCommand(lenhxoa, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();

            ketnoi.Open();
            sql = "select* from DMSP";
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
        }

        private void button5_Click(object sender, EventArgs e)
        {
            xoa();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = "select* from DMSP";
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
