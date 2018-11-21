using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;


namespace amTechnology
{
    public partial class LoginFrm : Form
    {
        string scon = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=H:\DATA\amTechnology\amTechnology\bin\Debug\BD_Food.accdb;Persist Security Info=True";
        OleDbConnection con;
        OleDbCommand cmd = new OleDbCommand();
        
        public LoginFrm()
        {
            InitializeComponent();
        }

        private void btnExit_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
                          
            string selectq = "";
            selectq = "select role from Employees where userName='"+txtID.Text+"' and Password='"+txtPas.Text+"'";
            con = new OleDbConnection(scon);
            OleDbDataAdapter da = new OleDbDataAdapter(selectq, con);
            DataTable dt = new System.Data.DataTable();
            da.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                this.Hide();
                MainF fm = new MainF(dt.Rows[0][0].ToString());
                fm.Show();

            }
            else 
            {
                MessageBox.Show("Incorrect ID & Password Try again");
            }

                       

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        

       
    }
}
