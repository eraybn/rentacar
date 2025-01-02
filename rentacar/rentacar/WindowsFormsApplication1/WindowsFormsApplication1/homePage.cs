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
    public partial class homePage : Form
    {
        public homePage()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //frmMüşteriEkleme arc = new frmMüşteriEkleme();
            //arc.Show();
            //this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listCustomer arc = new listCustomer();
            arc.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            registerVehicle arc = new registerVehicle();
            arc.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listVehicle arc = new listVehicle();
            arc.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            customerContract arc = new customerContract();
            arc.Show();
            this.Hide();
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {

        }
    }
}
