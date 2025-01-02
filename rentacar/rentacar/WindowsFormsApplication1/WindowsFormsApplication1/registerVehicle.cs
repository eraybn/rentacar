using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
//using System.Data.SqlClient;
namespace WindowsFormsApplication1
{
    public partial class registerVehicle : Form
    {
        string durum;
        public registerVehicle()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            homePage arc = new homePage();
            arc.Show();
            this.Hide();
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox2.Items.Clear();
                if (comboBox1.SelectedIndex == 0)
                {
                    comboBox2.Items.Add("218i");
                    comboBox2.Items.Add("320d");
                    comboBox2.Items.Add("428i");
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    comboBox2.Items.Add("c180");
                    comboBox2.Items.Add("e250");
                    comboBox2.Items.Add("s400");
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    comboBox2.Items.Add("a5");
                    comboBox2.Items.Add("rs7");
                    comboBox2.Items.Add("r8");
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    comboBox2.Items.Add("egea");
                    comboBox2.Items.Add("doblo");
                    comboBox2.Items.Add("linea");
                }
                else if (comboBox1.SelectedIndex == 4)
                {
                    comboBox2.Items.Add("focus");
                    comboBox2.Items.Add("mondeo");
                    comboBox2.Items.Add("kuga");
                }
                else if (comboBox1.SelectedIndex == 5)
                {
                    comboBox2.Items.Add("talisman");
                    comboBox2.Items.Add("fluence");
                    comboBox2.Items.Add("symbol");
                }
            }
            catch
            {
                ;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox5.Text == ""))
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
                komut.CommandText = "insert into arackayit(a_plaka,a_marka,a_seri,a_model,a_renk,a_km,a_yakit,a_ucret,a_durum) values(@k1,@k2,@k3,@k4,@k5,@k6,@k7,@k8,@k9)";
                komut.Parameters.AddWithValue("@k1", textBox1.Text);
                komut.Parameters.AddWithValue("@k2", comboBox1.Text);
                komut.Parameters.AddWithValue("@k3", comboBox2.Text);
                komut.Parameters.AddWithValue("@k4", textBox2.Text);
                komut.Parameters.AddWithValue("@k5", textBox3.Text);
                komut.Parameters.AddWithValue("@k6", textBox4.Text);
                komut.Parameters.AddWithValue("@k7", comboBox3.Text);
                komut.Parameters.AddWithValue("@k8", textBox5.Text);
                komut.Parameters.AddWithValue("@k9", durum);
                komut.Connection = baglan;
                object sonuc = null;
                sonuc = komut.ExecuteNonQuery();
                if (sonuc != null)
                {
                    MessageBox.Show("Vehicle added..");
                    textBox1.Text = "";
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    comboBox3.Text = "";
                    textBox5.Text = "";
            
                }
                else
                    MessageBox.Show("Could not add vehicle..", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            durum = "Boş";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            durum = "Dolu";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            durum = "Bakımda";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox3.Text = "";
            textBox5.Text = "";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

