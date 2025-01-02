using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class listCustomer : Form
    {
        string cinsiyet;
        public listCustomer()
        {
            InitializeComponent();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            homePage arc = new homePage();
            arc.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox1.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox7.Text = "";
            textBox5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection baglan = new MySqlConnection();
            baglan.ConnectionString = "Server=localhost;Database=kiralama;Uid=root;Pwd=''";
            MySqlCommand komut = new MySqlCommand();
            MySqlDataAdapter adapter;
            DataTable dt;
            dt = new DataTable();
            baglan.Open();
            adapter = new MySqlDataAdapter("select * from musteri_ekleme", baglan);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string cins = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            if (cins=="K")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlConnection baglan = new MySqlConnection();
            baglan.ConnectionString = "Server=localhost;Database=kiralama;Uid=root;Pwd=''";
            MySqlCommand komut = new MySqlCommand();
            MySqlDataAdapter adapter;
            DataTable dt;
            dt = new DataTable();
            baglan.Open();
            string sql = "delete from musteri_ekleme where m_tc=@tc";
            komut = new MySqlCommand(sql, baglan);
            komut.Parameters.AddWithValue("@tc", textBox1.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Record Deleted..");
            adapter = new MySqlDataAdapter("select * from musteri_ekleme", baglan);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {   
            MySqlConnection baglan = new MySqlConnection();
            baglan.ConnectionString = "Server=localhost;Database=kiralama;Uid=root;Pwd=''";
            MySqlCommand komut = new MySqlCommand();
            MySqlDataAdapter adapter;
            DataTable dt;
            dt = new DataTable();
            baglan.Open();
            string sorgu = "UPDATE musteri_ekleme SET m_ad_soyad=@as,m_cinsiyet=@c,m_telefon=@t,m_adres=@a,m_ehliyet_no=@ehlno,m_ehl_yer=@ehlyer,m_mail=@m WHERE m_tc=@tc";
            komut = new MySqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@tc", textBox1.Text);
            komut.Parameters.AddWithValue("@as", textBox2.Text);
            komut.Parameters.AddWithValue("@c", cinsiyet);
            komut.Parameters.AddWithValue("@t", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@a", textBox4.Text);
            komut.Parameters.AddWithValue("@ehlno", textBox3.Text);
            komut.Parameters.AddWithValue("@ehlyer", textBox7.Text);
            komut.Parameters.AddWithValue("@m", textBox5.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Record Updated..");
            adapter = new MySqlDataAdapter("select * from musteri_ekleme", baglan);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cinsiyet = "K";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cinsiyet = "E";
        }

        private void frmMüsteriListeleme_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox2.Text == "") || (maskedTextBox1.Text == "") || (textBox4.Text == "") || (textBox5.Text == ""))
            {
                MessageBox.Show("Fill in all the information..");
                return;
            }

            try
            {
                MySqlConnection baglan = new MySqlConnection();
                baglan.ConnectionString = "Server=localhost;Database=kiralama;Uid=root;Pwd=''";
                baglan.Open();
                MySqlCommand komut = new MySqlCommand();
                MySqlDataAdapter adapter;
                DataTable dt;
                dt = new DataTable();
                komut.CommandText = "insert into musteri_ekleme(m_tc,m_ad_soyad,m_cinsiyet,m_telefon,m_adres,m_ehliyet_no,m_ehl_yer,m_mail) values(@tc,@as,@c,@t,@a,@ehlno,@ehlyer,@m)";
                komut.Parameters.AddWithValue("@tc", textBox1.Text);
                komut.Parameters.AddWithValue("@as", textBox2.Text);
                komut.Parameters.AddWithValue("@c", cinsiyet);
                komut.Parameters.AddWithValue("@t", maskedTextBox1.Text);
                komut.Parameters.AddWithValue("@a", textBox4.Text);
                komut.Parameters.AddWithValue("@ehlno", textBox3.Text);
                komut.Parameters.AddWithValue("@ehlyer", textBox7.Text);
                komut.Parameters.AddWithValue("@m", textBox5.Text);
                komut.Connection = baglan;
                object sonuc = null;
                sonuc = komut.ExecuteNonQuery();
                if (sonuc != null)
                {
                    MessageBox.Show("Customer Added..");
                    adapter = new MySqlDataAdapter("select * from musteri_ekleme", baglan);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    maskedTextBox1.Text = "";
                    textBox4.Text = "";
                    textBox3.Text = "";
                    textBox7.Text = "";
                    textBox5.Text = "";
                }
                else
                    MessageBox.Show("Customer could not be added..", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                komut.Dispose();
                baglan.Close();
            }
            catch (Exception Hatayakala)
            {
                MessageBox.Show("Hata: " + Hatayakala.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

  

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch)) e.KeyChar = '\0';
            if (ch == Convert.ToChar(8)) e.KeyChar = ch;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection baglan = new MySqlConnection();
            baglan.ConnectionString = "Server=localhost;Database=kiralama;Uid=root;Pwd=''";
            MySqlCommand komut = new MySqlCommand();
            MySqlDataAdapter adapter;
            DataTable dt;
            dt = new DataTable();
            baglan.Open();
            adapter = new MySqlDataAdapter("select * from musteri_ekleme", baglan);
            adapter.Fill(dt);
            DataView dv = dt.DefaultView;
            dv.RowFilter = "m_ad_soyad like '" + textBox6.Text + "%'";
            dataGridView1.DataSource = dv;
            baglan.Close();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
    }
