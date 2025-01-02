using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class loginPanel : Form
    {
        public loginPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String kullaniciadi = textBox1.Text;
            string sifre = textBox2.Text;

            if (kullaniciadi == "admin" && sifre == "1234")

            {
                MessageBox.Show("Welcome.. \n You are being redirected to the redirect page"); 

                homePage arc = new homePage();    
                arc.Show();
                this.Hide();                           


            }
            else if (kullaniciadi == "" || sifre == "")
            {
                MessageBox.Show("Username or password cannot be left blank");
            }

            else
            {
                MessageBox.Show("Username or password is incorrect..\n Please try again..");
                textBox1.Text= "";
                textBox2.Text = "";
                textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();
        }
    }
}
