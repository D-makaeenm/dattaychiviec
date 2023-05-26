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
        public Form2()
        {
            InitializeComponent();
        }
        string chuoiketnoi = @"Data Source=DUYVPRO\DUY;Initial Catalog=BTL;Persist Security Info=True;User ID=sa";
        private void Form2_load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM HDX", "server = DUYVPRO\\DUY; database =  BTL; UID = sa; password = makaeenm1");
            DataSet ds = new DataSet();
            da.Fill(ds, "HDX");
            dataGridView1.DataSource = ds.Tables["HDX"].DefaultView;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server = DUYVPRO\\DUY; database =  BTL; UID = sa; password = makaeenm1");
            con.Open();
            string them = "INSERT INTO HDX VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','";
            SqlCommand cmd = new SqlCommand(them, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Insert thanh cong!!");
            String makh = this.textBox1.Text;
            String tenkh = this.textBox2.Text;
            String masp = this.textBox3.Text;
            String diachi = this.textBox4.Text;
            String dienthoai = this.textBox5.Text;
            String tennguoiban = this.textBox6.Text;
            String masothue = this.textBox7.Text;
            String sotk = this.textBox8.Text;
            String slban = this.textBox9.Text;
            String ngayban = this.textBox10.Text;
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

        }
    }
}
