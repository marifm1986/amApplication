using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace amTechnology
{
    public partial class MainF : Form
    {
        public MainF(string role)
        {
            InitializeComponent();
            userLbl.Text = role;
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
           
            lblDate.Text = DateTime.Now.ToLongDateString();
                 
        }

        private void MainF_Load(object sender, EventArgs e)
        {
           timer1.Start();
            if(userLbl.Text =="SaleDepart")
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button9.Enabled = false;
                
            }
            if (userLbl.Text == "PurchaseDepart")
            {
                
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            productFrm pf = new productFrm();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            CustomerFrm cf = new CustomerFrm();
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            EmployeesFrm ef = new EmployeesFrm();
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox2.Image = global::amTechnology.Properties.Resources.Red_02;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox2.Image = global::amTechnology.Properties.Resources.Red_01;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox3.Image = global::amTechnology.Properties.Resources.Green_02;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox3.Image = global::amTechnology.Properties.Resources.Green_01;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            productFrm pf = new productFrm();
            pf.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CustomerFrm cf = new CustomerFrm();
            cf.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            EmployeesFrm ef = new EmployeesFrm();
            ef.ShowDialog();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            breakFrm bf = new breakFrm();
            bf.ShowDialog();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
          
        }

        private void pictureBox5_Click_2(object sender, EventArgs e)
        {
            LoginFrm lf = new LoginFrm();
            lf.Show();
            
        }
    }
}
