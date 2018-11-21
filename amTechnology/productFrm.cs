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
    public partial class productFrm : Form
    {
        string scon = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=H:\DATA\amTechnology\amTechnology\bin\Debug\BD_Food.accdb;Persist Security Info=True";
        OleDbConnection con;
        OleDbCommand cmd = new OleDbCommand();
        int r;
        string ff_code;
              

        public productFrm()
        {
            InitializeComponent();
        }

        private void productFrm_Load(object sender, EventArgs e)
        {
            datashow();
            viewadjust();
            
            // TODO: This line of code loads data into the 'bD_FoodDataSet.Suppliers' table. You can move, or remove it, as needed.
            this.suppliersTableAdapter.Fill(this.bD_FoodDataSet.Suppliers);
           
            
            
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();

        }

        private void viewadjust()
        {

            dgv.Columns[0].Width = 0;
            dgv.Columns[0].HeaderText = "ID";
           // dgv.Columns[1].HeaderText = "SupplierIDs";
            dgv.Columns[2].HeaderText = "ProductCode";
            dgv.Columns[3].HeaderText = "ProductName";
            dgv.Columns[4].HeaderText = "Description";
            dgv.Columns[5].HeaderText = "StandardCost";
            dgv.Columns[6].HeaderText = "ListPrice";
            dgv.Columns[7].HeaderText = "MinimumReorderQuantity";
            dgv.Columns[8].HeaderText = "Discontinued";
            dgv.Columns[9].HeaderText = "Category";

            
        }
        private void datashow()
        {
            string selectq = "";
            selectq = "select ID,ProductCode,ProductName,Description,StandardCost,ListPrice,MinimumReorderQuantity,Discontinued,Category from Products";
            con = new OleDbConnection(scon);
            OleDbDataAdapter da = new OleDbDataAdapter(selectq, con);
            //OleDbDataAdapter sort = new OleDbDataAdapter("Select * from Products order by where ID", con);
            DataSet ds1 = new DataSet();
            da.Fill(ds1);
            dgv.DataSource = ds1.Tables[0];
            viewadjust();
            totshow();
            showSup();
            dgv.Refresh();
            

        }
        private void totshow()
        {
            int counting;
            int no1 = 0;
            counting = dgv.Rows.Count;
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
                if (btnSave.Text == "&Update")
                {
                    string update = "update Products set ProductCode='" + txtBarcode.Text + "',ProductName'" + txtName.Text+ "',Description='" + txtDescr.Text + "',StandardCost='" + txtCost.Text+ "',ListPrice='" + txtPrice.Text + "',MinimumReorderQuantity='" + txtOrderLevel.Text + "',Category='" + txtCategory.Text + "'where ID=" + txtID.Text + "";
                    con = new OleDbConnection(scon);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = update;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    btnSave.Text = "&Save";
                    cleartext();
                    txtBarcode.Focus();
                    datashow();
                }
                else
                {

                    string str = "insert into Products(ProductCode,ProductName,Description,StandardCost,ListPrice,MinimumReorderQuantity,Category)values('" + txtBarcode.Text + "','" + txtName.Text + "','" + txtDescr.Text + "','" + txtCost.Text + "','" + txtPrice.Text + "','" + txtOrderLevel.Text + "','" + txtCategory.Text + "')";
                    con = new OleDbConnection(scon);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = str;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    cleartext();
                    txtBarcode.Focus();
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
            txtBarcode.Text = "";
            txtCategory.Text = "";
            txtCost.Text = "";
            txtDescr.Text = "";
            txtName.Text = "";
            txtOrderLevel.Text = "";
            txtPrice.Text = "";
            txtSupID.Text = "";
            txtBarcode.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleting();
        }
        private void deleting()
        {
            try
            {
                int v1 = int.Parse(dgv.Rows[r].Cells[0].Value.ToString());
                string na = dgv.Rows[r].Cells[2].Value.ToString();
                string delq = "delete from Products where ID =" + v1 + "";
                con = new OleDbConnection(scon);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = delq;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted ( " + na.ToUpper() + " )");

                cleartext();
                datashow();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            r = e.RowIndex;
        }

        private void showSup()
        {
            txtSupID.Items.Clear();
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Company FROM Suppliers ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                txtSupID.Items.Add(dr["Company"].ToString());

            }
            con.Close();
            


        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ff_code = dgv.Rows[r].Cells[0].Value.ToString();
            txtID.Text = dgv.Rows[r].Cells[1].Value.ToString();
            txtBarcode.Text = dgv.Rows[r].Cells[2].Value.ToString();
            txtName.Text = dgv.Rows[r].Cells[3].Value.ToString();
            txtDescr.Text = dgv.Rows[r].Cells[4].Value.ToString();
            txtCost.Text = dgv.Rows[r].Cells[5].Value.ToString();
            txtPrice.Text = dgv.Rows[r].Cells[6].Value.ToString();
            txtOrderLevel.Text = dgv.Rows[r].Cells[7].Value.ToString();
            txtCategory.Text = dgv.Rows[r].Cells[8].Value.ToString();
            

            btnSave.Text = "&Update";
            txtBarcode.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductRptForm prf = new ProductRptForm();
            prf.ShowDialog();

        }


    }
}
