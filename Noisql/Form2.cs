using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Noisql
{
    public partial class Form2 : Form
    {
        string makhdangchon;
        private string stringconection = @"Data Source=DuyVPro;Initial Catalog=BTL;Persist Security Info=True;User ID=sa";
        public Form2()
        {
            InitializeComponent();
        }
        //
        thuvien dungthuvien;
        HDX dungHDX;
        //
        private void Form2_load(object sender, EventArgs e)
        {
            dungthuvien = new thuvien();
            try
            {
                dataGridView1.DataSource = dungthuvien.getallData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message, "lỗi", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count < 0)
            {
                MessageBox.Show("ban can chon doi tuong muon xoa", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string makh =  textBox1.Text;
            string tenkh =  textBox2.Text;
            string masp =  textBox3.Text;
            string diachi =  textBox4.Text;
            string dienthoai =  textBox5.Text;
            string tennguoiban =  textBox6.Text;
            string masothue =  textBox7.Text;
            string sotk =  textBox8.Text;
            string slban =  textBox9.Text;
            string ngayban =  textBox10.Text;
            string truyvan = $"UPDATE [dbo].[HDX] SET [Mã khách hàng] = '{makh}', [Tên khách hàng] = N'{tenkh}', [Mã sản phẩm] = '{masp}', [Địa chỉ] = N'{diachi}', [Điện thoại] = '{dienthoai}', [Số tài khoản]= '{sotk}', [Tên người bán] = N'{tennguoiban}', [Mã số thuế] = '{masothue}', [Số lượng bán] = '{slban}', [Ngày bán] = '{ngayban}'" + $" WHERE [Mã khách hàng] = '{makh}'";
            SqlConnection conn = new SqlConnection(stringconection);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = truyvan;
                int ketqua = cmd.ExecuteNonQuery();
                if (ketqua > 0)
                {
                    MessageBox.Show("da sua thanh cong", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form2_load(sender, e);
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string makh = textBox1.Text;
            string tenkh = textBox2.Text;
            string masp =  textBox3.Text;
            string diachi = textBox4.Text;
            string dienthoai = textBox5.Text;
            string tennguoiban =  textBox6.Text;
            string masothue =  textBox7.Text;
            string sotk =  textBox8.Text;
            string slban =  textBox9.Text;
            string ngayban =  textBox10.Text;

            SqlConnection conn = new SqlConnection(stringconection);
            try
            {
                conn.Open();
                string query = $"insert into [dbo].[HDX]" + $"([Mã khách hàng], [Tên khách hàng], [Mã sản phẩm], [Địa chỉ], [Điện thoại], [Số tài khoản], [Tên người bán], [Mã số thuế], [Số lượng bán], [Ngày bán])"
                    + $"values" + $"(N'{makh}', N'{tenkh}', N'{masp}', N'{diachi}', N'{dienthoai}', N'{sotk}', N'{tennguoiban}', N'{masothue}', N'{slban}', N'{ngayban}')";
                SqlCommand cmd = new SqlCommand(query, conn);
                int kq = cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Đã thêm thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form2_load(sender, e);
                    xoathongtin();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("hehe","thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void xoathongtin()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                makhdangchon = (string)dataGridView1.SelectedRows[0].Cells[0].Value;
                string makh = (string)dataGridView1.SelectedRows[0].Cells[0].Value;
                string tenkh = (string)dataGridView1.SelectedRows[0].Cells[1].Value;
                string masp = (string)dataGridView1.SelectedRows[0].Cells[2].Value;
                string diachi = (string)dataGridView1.SelectedRows[0].Cells[3].Value;
                string dienthoai = (string)dataGridView1.SelectedRows[0].Cells[4].Value;
                string tennguoiban = (string)dataGridView1.SelectedRows[0].Cells[5].Value;
                string masothue = (string)dataGridView1.SelectedRows[0].Cells[6].Value;
                string sotk = (string)dataGridView1.SelectedRows[0].Cells[7].Value;
                string slban = (string)dataGridView1.SelectedRows[0].Cells[8].Value;
                string ngayban = (string)dataGridView1.SelectedRows[0].Cells[9].Value;

                textBox1.Text = makh;
                textBox2.Text = tenkh;
                textBox3.Text = masp;
                textBox4.Text = diachi;
                textBox5.Text = dienthoai;
                textBox6.Text = tennguoiban;
                textBox7.Text = masothue;
                textBox8.Text = sotk;
                textBox9.Text = slban;
                textBox10.Text = ngayban;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 0)
            {
                MessageBox.Show("ban can chon doi tuong muon xoa", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string makh = (string)dataGridView1.SelectedRows[0].Cells[0].Value;
            string truyvan = $"delete from HDX where makh = '{makh}'";
            SqlConnection conn = new SqlConnection(stringconection);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = truyvan;
                int ketqua = cmd.ExecuteNonQuery();
                if (ketqua > 0)
                {
                    MessageBox.Show("Da xoa thanh cong", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form2_load(sender, e);
                    return;
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            xoathongtin();
        }
    }
}
