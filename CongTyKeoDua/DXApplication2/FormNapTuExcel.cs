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
using ExcelDataReader;
using Z.Dapper.Plus;
using System.IO;

namespace DXApplication2
{
    public partial class FormNapTuExcel : Form
    {
        string table = "";
        DataSet ds = new DataSet();
        SqlDataAdapter da_temp = new SqlDataAdapter();
        SqlConnection cnn = new SqlConnection("Data Source=ADMIN;Initial Catalog = QLKEODUA; Integrated Security=True");
        DataTableCollection TableCollection;
        public FormNapTuExcel()
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //OpenFileDialog opn = new OpenFileDialog();
            //opn.Filter = "XLS files (*.xls)|*.xls|XLT files (*.xlt)|*.xlt|XLSX files (*.xlsx)|*.xlsx|XLSM files (*.xlsm)|*.xlsm";
            //opn.FilterIndex = 3;

            //if (opn.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    this.textBox1.Text = opn.FileName;
            //}
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Files|*.xls;*.xlsx" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = ofd.FileName;
                    using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            });
                            TableCollection = result.Tables;
                            comboBox1.Items.Clear();
                            foreach (DataTable table in TableCollection)
                                comboBox1.Items.Add(table.TableName);
                        }
                    }
                }
                comboBox1.Enabled = true;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox1.Text + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1'";
                OleDbConnection conn = new OleDbConnection(path);
                OleDbDataAdapter da = new OleDbDataAdapter("select * from [" + comboBox1.Text + "$]", conn);
                table = comboBox1.Text;
                DataTable dt = new DataTable();
                da.Fill(dt);

                grid_Excel.DataSource = dt;
                try
                {
                    ds.Tables.Remove("temp");
                }
                catch
                {
                }
                string sql = "select * from " + table;
                da_temp = new SqlDataAdapter(sql, cnn);
                da_temp.Fill(ds, "temp");
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

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grid_Excel.RowCount; i++)
                {
                    DataRow drThem = ds.Tables["temp"].NewRow();
                    DataGridViewRow row = grid_Excel.Rows[i];
                    if (ktra(row.Cells[0].Value.ToString()) == false)
                    {
                        for (int j = 0; j < grid_Excel.ColumnCount; j++)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                simpleButton2.Enabled = true;
            else
                simpleButton2.Enabled = false;
        }

        private void FormNapTuExel_Load(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                simpleButton2.Enabled = false;
                comboBox1.Enabled = false;
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

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = TableCollection[comboBox1.SelectedItem.ToString()];
            grid_Excel.DataSource = dt;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            FormXemDuLieu xm = new FormXemDuLieu();
            xm.ShowDialog();
        }
    }
}
