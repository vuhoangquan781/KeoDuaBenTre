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
    public partial class FormNapTuSQL : Form
    {
        string table = "";
        //SqlConnection conn;
        DataSet ds = new DataSet();
        SqlDataAdapter da_temp = new SqlDataAdapter();
        SqlConnection cnn = new SqlConnection("Data Source=localhost;Initial Catalog = QLKEODUA; Integrated Security=True");
        private SqlConnection conn;
        private SqlCommand command;
        private SqlDataReader reader;
        string sql = "";
        string connectionString = "";
        public FormNapTuSQL()
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            InitializeComponent();
        }

        public void KetNoi()
        {
            //conn = new SqlConnection("Data Source=" + comboBox1.Text + ";Initial Catalog=" + comboBox2.Text + "; Integrated Security=True");  
            connectionString = "Data Source = " + comboBox1.Text + "; Integrated Security=True";
            conn = new SqlConnection(connectionString);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            KetNoi();
            try
            {
                conn.Open();
                sql = "EXEC sp_databases";
                command = new SqlCommand(sql, conn);
                reader = command.ExecuteReader();
                comboBox2.Items.Clear();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader[0].ToString());
                }
                reader.Dispose();
                //conn.Open();
                MessageBox.Show("Kết nối thành công !!");

                //string alltable = "use " + comboBox2.Text + " select object_id,name from sys.tables";
                //DataTable dt1 = new DataTable();
                //SqlDataAdapter da_AllTable = new SqlDataAdapter(alltable, conn);
                //da_AllTable.Fill(dt1);


                //cbo_TableSQL.DisplayMember = "name";
                //cbo_TableSQL.ValueMember = "name";
                //cbo_TableSQL.DataSource = dt1;

                conn.Close();
                comboBox2.Enabled = true;
                cbo_TableSQL.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Kết nối không thành công, kiểm tra lại Server Name và Database Name");
            }

        }

        private void cbo_TableSQL_SelectedIndexChanged(object sender, EventArgs e)
        {
            KetNoi();

            grid_SQL.DataSource = null;

            try
            {
                conn.Open();

                string cboText = cbo_TableSQL.SelectedValue.ToString();
                string sql = "use " + comboBox2.Text + " select * from " + cboText + "";
                table = cboText;
                SqlDataAdapter da_temp1 = new SqlDataAdapter(sql, conn);
                DataTable dt1 = new DataTable();

                dt1 = new DataTable();
                da_temp1.Fill(dt1);

                grid_SQL.DataSource = dt1;
                table = cbo_TableSQL.SelectedValue.ToString();
                try
                {
                    ds.Tables.Remove("temp");
                }
                catch
                {
                }
                string sqlsv = "select * from " + table;
                da_temp = new SqlDataAdapter(sqlsv, cnn);
                da_temp.Fill(ds, "temp");
                conn.Close();

            }
            catch
            {

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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grid_SQL.RowCount; i++)
                {
                    DataRow drThem = ds.Tables["temp"].NewRow();
                    DataGridViewRow row = grid_SQL.Rows[i];
                    if (ktra(row.Cells[0].Value.ToString()) == false)
                    {
                        for (int j = 0; j < grid_SQL.ColumnCount; j++)
                        {
                            drThem[j] = row.Cells[j].Value.ToString();
                        }
                        ds.Tables["temp"].Rows.Add(drThem);
                    }
                }
                SqlCommandBuilder buil = new SqlCommandBuilder(da_temp);
                da_temp.Update(ds, "temp");
                SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=QLKEODUA;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("update " + cbo_TableSQL.Text + " set NGAYNAP= CAST( GETDATE() AS Date ) where NGAYNAP IS NULL", con);
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
            server.Connect("Data source=localhost;Timeout=7200000;Integrated Security=SSPI");
            Microsoft.AnalysisServices.Database database = server.Databases.FindByName("SSAS");

            database.Process(ProcessType.ProcessFull);
            MessageBox.Show("Cap nhat Olap thanh cong");
        }

        private void FormNapTuSQL_Load(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || comboBox2.Text=="")
                simpleButton2.Enabled = false;
            comboBox2.Enabled = false;
            cbo_TableSQL.Enabled = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            KetNoi();
            conn.Open();
            string alltable = "use " + comboBox2.Text + " select object_id,name from sys.tables";
            DataTable dt1 = new DataTable();
            SqlDataAdapter da_AllTable = new SqlDataAdapter(alltable, conn);
            da_AllTable.Fill(dt1);


            cbo_TableSQL.DisplayMember = "name";
            cbo_TableSQL.ValueMember = "name";
            cbo_TableSQL.DataSource = dt1;

            if (comboBox2.Text != "")
                simpleButton2.Enabled = true;
            else
                simpleButton2.Enabled = false;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            FormXemDuLieu xm = new FormXemDuLieu();
            xm.ShowDialog();
        }
    }
}
