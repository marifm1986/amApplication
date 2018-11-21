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
    public partial class EmployeesFrm : Form
    {
        string scon = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=H:\DATA\amTechnology\amTechnology\bin\Debug\BD_Food.accdb;Persist Security Info=True";
        OleDbConnection con;
        OleDbCommand cmd = new OleDbCommand();

        int r;
        string ff_Code;

        public EmployeesFrm()
        {
            InitializeComponent();
        }

        private void EmployeesFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bD_FoodDataSet1.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.bD_FoodDataSet1.Employees);
            datashow();
            viewadjust();
            

        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void viewadjust()
        {

            dgvE.Columns[0].Width = 20;
            dgvE.Columns[0].HeaderText = "ID";
            dgvE.Columns[1].HeaderText = "User Name";
            dgvE.Columns[2].HeaderText = "Password";
            dgvE.Columns[3].HeaderText = "Role";
            dgvE.Columns[4].HeaderText = "Last Name";
            dgvE.Columns[5].HeaderText = "First Name";
            dgvE.Columns[6].HeaderText = "Email";
            dgvE.Columns[7].HeaderText = "Job Title";
            dgvE.Columns[8].HeaderText = "Mobile";
            dgvE.Columns[9].HeaderText = "Address";


        }
        private void datashow()
        {
            string selectq = "";
            selectq = "select * from Employees";
            con = new OleDbConnection(scon);
            OleDbDataAdapter da = new OleDbDataAdapter(selectq, con);
            //OleDbDataAdapter sort = new OleDbDataAdapter("Select * from Products order by where ID", con);
            DataSet ds1 = new DataSet();
            da.Fill(ds1);
            dgvE.DataSource = ds1.Tables[0];
            viewadjust();

            totshow();




        }
        private void totshow()
        {
            int counting;
            int no1 = 0;
            counting = dgvE.Rows.Count;
            for (int k = 0; k < counting; k++)
            {
                no1 = no1 + 1;
            }
            recordLb.Text = no1.ToString();
        }
        private void SaveData()
        {

            try
            {
                if (btnSavE.Text == "&Update")
                    {
                        string update = "update Employees set userName='" + txtUserID.Text+ "',Password='" + txtPassword.Text + "',role='" + txtRole.Text + "',LastName='" + txtLname.Text + "',FirstName='" + txtFname.Text + "',Email='" + txtEmail.Text + "',MobilePhone='" + txtMobile.Text + "',Address='" + txtAddress.Text + "',Note='" + txtNote.Text + "'where ID=" + txtID.Text + "";
                        con = new OleDbConnection(scon);
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = update;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        btnSavE.Text = "&Save";
                        cleartext();
                        txtFname.Focus();
                        datashow();
                    }
                    else
                    {

                        string str = "insert into Employees(userName,Password,role,LastName,FirstName,Email,JobTitle,MobilePHone,Address,Note)values('" + txtUserID.Text + "','" + txtPassword.Text + "','" + txtRole.Text + "','" + txtLname.Text + "','" + txtFname.Text + "','" + txtEmail.Text + "','" + txtJTitle.Text + "','" + txtMobile.Text + "','" + txtAddress.Text + "''" + txtNote.Text + "')";
                        con = new OleDbConnection(scon);
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = str;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        cleartext();
                        txtFname.Focus();
                        datashow();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            

        }

        private void cleartext()
        {
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtFname.Text = "";
            txtJTitle.Text = "";
            txtLname.Text = "";
            txtMobile.Text = "";
            txtNote.Text = "";
            txtID.Text = "";
            txtPassword.Text = "";
            txtUserID.Text = "";
            txtRole.Text = "";
            txtFname.Focus();
        }


        private void deleting()
        {
            try
            {
                int v1 = int.Parse(dgvE.Rows[r].Cells[0].Value.ToString());
                string na = dgvE.Rows[r].Cells[0].Value.ToString();
                string delq = "delete from Employees where ID =" + v1 + "";
                con = new OleDbConnection(scon);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = delq;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted ( " + na.ToUpper() + " )");
                datashow();
                cleartext();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void dgvE_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            r = e.RowIndex;
        }

        private void txtFname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            deleting();
        }

        private void btnSavE_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            ff_Code = dgvE.Rows[r].Cells[0].Value.ToString();
            txtID.Text = dgvE.Rows[r].Cells[0].Value.ToString();
            txtUserID.Text = dgvE.Rows[r].Cells[1].Value.ToString();
            txtPassword.Text = dgvE.Rows[r].Cells[2].Value.ToString();
            txtRole.Text = dgvE.Rows[r].Cells[3].Value.ToString();
            txtLname.Text = dgvE.Rows[r].Cells[4].Value.ToString();
            txtFname.Text = dgvE.Rows[r].Cells[5].Value.ToString();
            txtEmail.Text = dgvE.Rows[r].Cells[6].Value.ToString();
            txtJTitle.Text = dgvE.Rows[r].Cells[7].Value.ToString();
            txtMobile.Text = dgvE.Rows[r].Cells[8].Value.ToString();
            txtAddress.Text = dgvE.Rows[r].Cells[9].Value.ToString();
            txtNote.Text = dgvE.Rows[r].Cells[9].Value.ToString();

            btnSavE.Text = "&Update";
            txtFname.Focus();


        }

        private void dgvE_DoubleClick(object sender, EventArgs e)
        {
            ff_Code = dgvE.Rows[r].Cells[0].Value.ToString();
            txtID.Text = dgvE.Rows[r].Cells[0].Value.ToString();
            txtUserID.Text = dgvE.Rows[r].Cells[1].Value.ToString();
            txtPassword.Text = dgvE.Rows[r].Cells[2].Value.ToString();
            txtRole.Text = dgvE.Rows[r].Cells[3].Value.ToString();
            txtLname.Text = dgvE.Rows[r].Cells[4].Value.ToString();
            txtFname.Text = dgvE.Rows[r].Cells[5].Value.ToString();
            txtEmail.Text = dgvE.Rows[r].Cells[6].Value.ToString();
            txtJTitle.Text = dgvE.Rows[r].Cells[7].Value.ToString();
            txtMobile.Text = dgvE.Rows[r].Cells[8].Value.ToString();
            txtAddress.Text = dgvE.Rows[r].Cells[9].Value.ToString();
            txtNote.Text = dgvE.Rows[r].Cells[9].Value.ToString();

            btnSavE.Text = "&Update";
            txtFname.Focus();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            employeesRFrm erf = new employeesRFrm();
            erf.Show();
        }

    }

    
}
