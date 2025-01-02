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
    public partial class listVehicle : Form
    {
        string durum2;
        public listVehicle()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            homePage arc = new homePage();
            arc.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlConnection baglan = new MySqlConnection();
            baglan.ConnectionString = "Server=localhost;Database=kiralama;Port=3306;Uid=root;Pwd=''";
            MySqlCommand komut = new MySqlCommand();
            MySqlDataAdapter adapter;
            DataTable dt;
            dt = new DataTable();
            baglan.Open();
            adapter = new MySqlDataAdapter("select * from arackayit", baglan);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            string durumm = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            if (durumm == "Boş")
            {
                radioButton1.Checked = true;
            }
            else if(durumm=="Dolu")
            {
                radioButton2.Checked = true;
            }
            else if(durumm=="Bakımda")
            {
                radioButton3.Checked = true;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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
            string sorgu = "UPDATE arackayit SET a_marka=@k2,a_seri=@k3,a_model=@k4,a_renk=@k5,a_km=@k6,a_yakit=@k7,a_ucret=@k8,a_durum=@k9 WHERE a_plaka=@k1";
            komut = new MySqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@k1", textBox1.Text);
            komut.Parameters.AddWithValue("@k2", comboBox4.Text);
            komut.Parameters.AddWithValue("@k3", comboBox2.Text);
            komut.Parameters.AddWithValue("@k4", textBox2.Text);
            komut.Parameters.AddWithValue("@k5", textBox3.Text);
            komut.Parameters.AddWithValue("@k6", textBox4.Text);
            komut.Parameters.AddWithValue("@k7", comboBox3.Text);
            komut.Parameters.AddWithValue("@k8", textBox5.Text);
            komut.Parameters.AddWithValue("@k9", durum2);
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Record updated..");
            adapter = new MySqlDataAdapter("select * from arackayit", baglan);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            durum2 = "Boş";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            durum2 = "Dolu";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            durum2 = "Bakımda";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection baglan = new MySqlConnection();
            baglan.ConnectionString = "Server=localhost;Database=kiralama;Uid=root;Pwd=''";
            MySqlCommand komut = new MySqlCommand();
            MySqlDataAdapter adapter;
            DataTable dt;
            dt = new DataTable();
            baglan.Open();
            string sql = "delete from arackayit where m_tc=@k1";
            komut = new MySqlCommand(sql, baglan);
            komut.Parameters.AddWithValue("@k1", textBox1.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Vehicle deleted..");
            adapter = new MySqlDataAdapter("select * from arackayit", baglan);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
       
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection baglan = new MySqlConnection();
            baglan.ConnectionString = "Server=localhost;Database=kiralama;Uid=root;Pwd=''";
            MySqlCommand komut = new MySqlCommand();
            MySqlDataAdapter adapter;
            DataTable dt;
            dt = new DataTable();
            baglan.Open();
            adapter = new MySqlDataAdapter("select * from arackayit", baglan);
            adapter.Fill(dt);
            DataView dv = dt.DefaultView;
            dv.RowFilter = "a_plaka like '" + textBox7.Text + "%'";
            dataGridView1.DataSource = dv;
            baglan.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection baglan = new MySqlConnection();
            baglan.ConnectionString = "Server=localhost;Database=kiralama;Uid=root;Pwd=''";
            MySqlCommand komut = new MySqlCommand();
            MySqlDataAdapter adapter;
            DataTable dt;
            dt = new DataTable();
            baglan.Open();
            adapter = new MySqlDataAdapter("select * from arackayit", baglan);
            adapter.Fill(dt);
            DataView dv = dt.DefaultView;
            dv.RowFilter = "a_durum like '" + textBox8.Text + "%'";
            dataGridView1.DataSource = dv;
            baglan.Close();
        }

        private void listVehicle_Load(object sender, EventArgs e)
        {

        }
    }
}
