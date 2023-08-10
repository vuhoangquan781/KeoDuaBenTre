using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using GemBox.Spreadsheet;
using GemBox.Spreadsheet.WinFormsUtilities;
using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.AnalysisServices;
using Microsoft.AnalysisServices.Core;

namespace DXApplication2
{
    public partial class FormNapTuAccess : Form
    {
        string table = "";
        DataSet ds = new DataSet();
        SqlDataAdapter da_temp = new SqlDataAdapter();
        SqlConnection cnn = new SqlConnection("Data Source=ADMIN;Initial Catalog = QLKEODUA; Integrated Security=True");
        public FormNapTuAccess()
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opn = new OpenFileDialog();
            opn.Filter = "Access Databases (*.mdb)|*.accdb";
            opn.FilterIndex = 3;

            if (opn.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.textBox1.Text = opn.FileName;
            }
            comboBox1.Enabled = true;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox1.Text + "";
                OleDbConnection conn = new OleDbConnection(path);
                conn.Open();

                OleDbDataAdapter da_Access = new OleDbDataAdapter("select * from " + comboBox1.Text + "", conn);
                DataTable dt2 = new DataTable();

                //dt2 = new DataTable();
                da_Access.Fill(dt2);
                grid_Access.DataSource = dt2;

                table = comboBox1.Text;
                try
                {
                    ds.Tables.Remove("temp");
                }
                catch
                {
                }
                string sqlac = "select * from " + table;
                da_temp = new SqlDataAdapter(sqlac, cnn);
                da_temp.Fill(ds, "temp");

                conn.Close();
            }
            catch
            {
                MessageBox.Show("Mời Bạn Chọn Bảng");
            }
        }

        public bool KTTrung(string ma, DataSet ds)
        {
            try
            {
                if (ds != null)
                {
                    for (int i = 0; i < ds.Tables["temp"].Rows.Count; i++)
                    {
                        DataRow dr = ds.Tables["temp"].Rows[i];
                        if (dr != null)
                        {
                            if (dr[0].ToString().Equals(ma))
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool ktra(string ma)
        {
            try
            {
                for (int i = 0; i < ds.Tables["temp"].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables["temp"].Rows[i];
                    if (dr[0].ToString().Equals(ma))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                simpleButton2.Enabled = true;
            else
                simpleButton2.Enabled = false;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grid_Access.RowCount; i++)
                {
                    DataRow drThem = ds.Tables["temp"].NewRow();
                    DataGridViewRow row = grid_Access.Rows[i];
                    if (ktra(row.Cells[0].Value.ToString()) == false)
                    {
                        for (int j = 0; j < grid_Access.ColumnCount; j++)
                        {
                            drThem[j] = row.Cells[j].Value.ToString();
                        }
                        ds.Tables["temp"].Rows.Add(drThem);
                    }

                }
                SqlCommandBuilder buil = new SqlCommandBuilder(da_temp);
                da_temp.Update(ds, "temp");
                SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=QLKEODUA;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("update " + comboBox1.Text + " set NGAYNAP= CAST( GETDATE() AS Date ) where NGAYNAP IS NULL", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Nạp thành công");
            }
            catch
            {
                MessageBox.Show("Bảng không mang tính chất hướng chủ đề");
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Microsoft.AnalysisServices.Server server = new Microsoft.AnalysisServices.Server();
            server.Connect("Data source=ADMIN;Timeout=7200000;Integrated Security=SSPI");
            Microsoft.AnalysisServices.Database database = server.Databases.FindByName("SSAS");

            database.Process(ProcessType.ProcessFull);
            MessageBox.Show("Cap nhat Olap thanh cong");
        }

        private void FormNapTuAccess_Load(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                simpleButton2.Enabled = false;
                comboBox1.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string path = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox1.Text + "";
            //OleDbConnection conn = new OleDbConnection(path);
            //grid_Access.DataSource = null;
            //try
            //{

            //conn.Open();

            //string alltable = "select object_id,name from sys.tables";
            //DataTable dt1 = new DataTable();
            //OleDbDataAdapter da_AllTable = new OleDbDataAdapter(alltable, conn);
            //da_AllTable.Fill(dt1);

            //comboBox1.DisplayMember = "name";
            //comboBox1.ValueMember = "name";
            //comboBox1.DataSource = dt1;

            //    string cboText = comboBox1.SelectedValue.ToString();
            //    string sql = "use "+ textBox1.Text +" select * from " + cboText + "";
            //    table = cboText;

            //    //OleDbDataAdapter da_Access = new OleDbDataAdapter("select * from " + textBox2.Text + "", conn);
            //    OleDbDataAdapter da_Access = new OleDbDataAdapter(sql, conn);
            //    DataTable dt2 = new DataTable();

            //    dt2 = new DataTable();
            //    da_Access.Fill(dt2);

            //    grid_Access.DataSource = dt2;
            //    table = comboBox1.SelectedValue.ToString();
            //    try
            //    {
            //        ds.Tables.Remove("temp");
            //    }
            //    catch
            //    {
            //    }
            //    string sqlac = "select * from " + table;
            //    da_temp = new SqlDataAdapter(sqlac, cnn);
            //    da_temp.Fill(ds, "temp");

            //    conn.Close();
            //}
            //catch
            //{
            //    MessageBox.Show("Mời Nhập Đúng Sheet");
            //}
        }

        private void simpleButton5_Click_1(object sender, EventArgs e)
        {
            FormXemDuLieu xm = new FormXemDuLieu();
            xm.ShowDialog();
        }
    }
}
