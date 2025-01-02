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
    public partial class customerContract : Form
    {
        public string[] a_km = new string[1000];
        public string[] a_kira = new string[1000];
        public string[] m_tc = new string[1000];
        public string[] m_tel = new string[1000];
        public string[] m_ehl = new string[1000];
        public string[] m_ehlyer = new string[1000];
        string odeme;
        public customerContract()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            homePage arc = new homePage();
            arc.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            textBox2.Text = "";
            maskedTextBox1.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            textBox5.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((comboBox2.Text == "") || (textBox2.Text == "") || (maskedTextBox1.Text == "") || (textBox4.Text == "") || (textBox3.Text == "") || (comboBox1.Text == "") || (textBox5.Text == "") || (textBox11.Text == "") || (textBox12.Text == "") || (textBox13.Text == ""))
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
                komut.Connection = baglan;
                MySqlDataAdapter adapter;
                DataTable dt;
                dt = new DataTable();
                komut.CommandText = "insert into sozlesme(m_tc,m_ad_soyad,m_telefon,m_ehliyet_no,m_ehl_yer,a_plaka,a_km,a_odeme_tur,a_kira_ucret,a_gun,a_tutar,a_cikis_tarih,a_donus_tarih) values(@k1,@k2,@k3,@k4,@k5,@k6,@k7,@k8,@k9,@k10,@k11,@k12,@k13)";
                komut.Parameters.AddWithValue("@k1", comboBox2.Text);
                komut.Parameters.AddWithValue("@k2", textBox2.Text);
                komut.Parameters.AddWithValue("@k3", maskedTextBox1.Text);
                komut.Parameters.AddWithValue("@k4", textBox4.Text);
                komut.Parameters.AddWithValue("@k5", textBox3.Text);
                komut.Parameters.AddWithValue("@k6", comboBox1.Text);
                komut.Parameters.AddWithValue("@k7", textBox5.Text);
                komut.Parameters.AddWithValue("@k8", odeme);
                komut.Parameters.AddWithValue("@k9", textBox11.Text);
                komut.Parameters.AddWithValue("@k10", textBox12.Text);
                komut.Parameters.AddWithValue("@k11", textBox13.Text);
                komut.Parameters.AddWithValue("@k12", DateTime.Parse(dateTimePicker1.Text));
                komut.Parameters.AddWithValue("@k13", DateTime.Parse(dateTimePicker2.Text));
                //komut.CommandText = ("update arackayit set a_durum='Dolu' where a_plaka='" + comboBox1.Text + "'");
                object sonuc = null;
                sonuc = komut.ExecuteNonQuery();
                if (sonuc != null)
                {
                    MessageBox.Show("Contract added..");
                    adapter = new MySqlDataAdapter("select * from sozlesme", baglan);
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    comboBox2.Text = "";
                    textBox2.Text = "";
                    maskedTextBox1.Text = "";
                    textBox4.Text = "";
                    textBox3.Text = "";
                    comboBox1.Text = "";
                    textBox5.Text = "";
                    textBox11.Text = "";
                    textBox12.Text = "";
                    textBox13.Text = "";
                    dateTimePicker1.Text = "";
                    dateTimePicker2.Text = "";
                   

                }
                else
                    MessageBox.Show("Contract could not be added..", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                komut.Dispose();
                baglan.Close();
            }
            catch (Exception Hatayakala)
            {
                MessageBox.Show("Hata: " + Hatayakala.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            odeme = "Nakit";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            odeme = "Kredi Kartı";
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            comboBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            string odemee = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            if (odemee == "Nakit")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            textBox11.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox12.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox13.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MySqlConnection baglan = new MySqlConnection();
            baglan.ConnectionString = "Server=localhost;Database=kiralama;Uid=root;Pwd=''";
            MySqlCommand komut = new MySqlCommand();
            MySqlDataAdapter adapter;
            DataTable dt;
            dt = new DataTable();
            baglan.Open();
            adapter = new MySqlDataAdapter("select * from sozlesme", baglan);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
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
            string sorgu = "UPDATE sozlesme SET m_ad_soyad=@k2,m_telefon=@k3,m_ehliyet_no=@k4,m_ehl_yer=@k5,a_plaka=@k6,a_km=@k7,a_odeme_tur=@k8,a_kira_ucret=@k9,a_gun=@k10,a_tutar=@k11,a_cikis_tarih=@k12,a_donus_tarih=@k13 WHERE m_tc=@k1";
            komut = new MySqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@k2", textBox2.Text);
            komut.Parameters.AddWithValue("@k3", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@k4", textBox4.Text);
            komut.Parameters.AddWithValue("@k5", textBox3.Text);
            komut.Parameters.AddWithValue("@k6", comboBox1.Text);
            komut.Parameters.AddWithValue("@k7", textBox5.Text);
            komut.Parameters.AddWithValue("@k8", odeme);
            komut.Parameters.AddWithValue("@k9", textBox11.Text);
            komut.Parameters.AddWithValue("@k10", textBox12.Text);
            komut.Parameters.AddWithValue("@k11", textBox13.Text);
            komut.Parameters.AddWithValue("@k12", DateTime.Parse(dateTimePicker1.Text));
            komut.Parameters.AddWithValue("@k13", DateTime.Parse(dateTimePicker2.Text));
            komut.Parameters.AddWithValue("@k1", comboBox2.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Contract updated..");
            adapter = new MySqlDataAdapter("select * from sozlesme", baglan);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
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
            string sql = "delete from sozlesme where m_tc=@k1";
            komut = new MySqlCommand(sql, baglan);
            komut.Parameters.AddWithValue("@k1", comboBox2.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Contract deleted..");
            adapter = new MySqlDataAdapter("select * from sozlesme", baglan);
            //komut.CommandText = ("update arackayit set a_durum='Boş' where a_plaka='" + comboBox1.Text + "'");
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch)) e.KeyChar = '\0';
            if (ch == Convert.ToChar(8)) e.KeyChar = ch;
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection baglan = new MySqlConnection();
            baglan.ConnectionString = "Server=localhost;Database=kiralama;Uid=root;Pwd=''";
            MySqlCommand komut = new MySqlCommand();
            MySqlDataAdapter adapter;
            DataTable dt;
            dt = new DataTable();
            baglan.Open();
            adapter = new MySqlDataAdapter("select * from sozlesme", baglan);
            adapter.Fill(dt);
            DataView dv = dt.DefaultView;
            dv.RowFilter = "m_ad_soyad like '" + textBox15.Text + "%'";
            dataGridView1.DataSource = dv;
            baglan.Close();
        }

      

        private void button7_Click(object sender, EventArgs e)
        {
            int a, b,c;
            a = Convert.ToInt16(textBox11.Text);
            b = Convert.ToInt16(textBox12.Text);
            c = a * b;
            textBox13.Text = Convert.ToString(c);
            
        }

        private void frmMusteriSozlesme_Load(object sender, EventArgs e)
        {
            int i = 0;
            MySqlConnection baglan = new MySqlConnection();
            baglan.ConnectionString = "Server=localhost;Database=kiralama;Uid=root;Pwd=''";
            MySqlCommand komut = new MySqlCommand();
            komut.Connection = baglan;
            baglan.Open();
            komut.CommandText = "select * from arackayit";
            MySqlDataReader oku;
            oku = komut.ExecuteReader();
            comboBox1.Items.Clear();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["a_plaka"]);
                a_km[i] = Convert.ToString(oku["a_km"]);
                a_kira[i] = Convert.ToString(oku["a_ucret"]);
                i++;
            }
            oku.Close();
            int ii = 0;
            komut.CommandText = "select * from musteri_ekleme";
            MySqlDataReader oku2;
            oku2 = komut.ExecuteReader();
            comboBox2.Items.Clear();
            while (oku2.Read())
            {
                comboBox2.Items.Add(oku2["m_ad_soyad"]);
                m_tc[ii] = Convert.ToString(oku2["m_tc"]);
                m_tel[ii] = Convert.ToString(oku2["m_telefon"]);
                m_ehl[ii] = Convert.ToString(oku2["m_ehliyet_no"]);
                m_ehlyer[ii] = Convert.ToString(oku2["m_ehl_yer"]);
                ii++;
            }
            oku2.Close();
            baglan.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch)) e.KeyChar = '\0';
            if (ch == Convert.ToChar(8)) e.KeyChar = ch;
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch)) e.KeyChar = '\0';
            if (ch == Convert.ToChar(8)) e.KeyChar = ch;
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch)) e.KeyChar = '\0';
            if (ch == Convert.ToChar(8)) e.KeyChar = ch;
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch)) e.KeyChar = '\0';
            if (ch == Convert.ToChar(8)) e.KeyChar = ch;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex>=0)
            {
                textBox5.Text = Convert.ToString(a_km[comboBox1.SelectedIndex]);
                textBox11.Text = Convert.ToString(a_kira[comboBox1.SelectedIndex]);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex>=0)
            {
                textBox2.Text = Convert.ToString(m_tc[comboBox2.SelectedIndex]);
                maskedTextBox1.Text = Convert.ToString(m_tel[comboBox2.SelectedIndex]);
                textBox4.Text = Convert.ToString(m_ehl[comboBox2.SelectedIndex]);
                textBox3.Text = Convert.ToString(m_ehlyer[comboBox2.SelectedIndex]);
            }
            
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
    }

