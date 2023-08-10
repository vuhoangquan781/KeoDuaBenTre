using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication2
{
    public partial class FormXemDuLieu : Form
    {
        public FormXemDuLieu()
        {
            InitializeComponent();
        }
        DataTable dtb = new DataTable();
        DataSet ds = new DataSet();
        SqlDataAdapter da_temp = new SqlDataAdapter();
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog = QLKEODUA; Integrated Security=True");
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            grid_SQL.DataSource = null;
            try
            {
                conn.Open();
                string cboText = comboBox1.SelectedValue.ToString();
                string sql = "use QLKEODUA select * from " + cboText + "";
                string table = cboText;
                SqlDataAdapter da_temp1 = new SqlDataAdapter(sql, conn);
                DataTable dt2 = new DataTable();

                dt2 = new DataTable();
                da_temp1.Fill(dt2);

                grid_SQL.DataSource = dt2;
                table = comboBox1.SelectedValue.ToString();
                try
                {
                    ds.Tables.Remove("temp");
                }
                catch
                {
                }
                string sqlsv = "select * from " + table;
                da_temp = new SqlDataAdapter(sqlsv, conn);
                da_temp.Fill(ds, "temp");
                conn.Close();

            }
            catch
            {

            }
        }

        private void XemDuLieu_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog = QLKEODUA; Integrated Security=True");
            conn.Open();
            string alltable = "use QLKEODUA select object_id,name from sys.tables";
            DataTable dt1 = new DataTable();
            SqlDataAdapter da_AllTable = new SqlDataAdapter(alltable, conn);
            da_AllTable.Fill(dt1);
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "name";
            comboBox1.DataSource = dt1;
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy/MM/dd"));
            grid_SQL.DataSource = null;
            conn.Open();
            //string sql = "select * from " + comboBox1.Text + "";
            //SqlCommand cmd = new SqlCommand(sql, conn);
            //SqlDataAdapter da_temp2 = new SqlDataAdapter();
            //da_temp2.SelectCommand = cmd;
            //da_temp2.Fill(dtb);
            //grid_SQL.DataSource = dtb;
            string cboText = comboBox1.SelectedValue.ToString();
            string sql = "select * from " + cboText + "";
            string table = cboText;
            SqlDataAdapter da_temp1 = new SqlDataAdapter(sql, conn);
            DataTable dt2 = new DataTable();

            dt2 = new DataTable();
            da_temp1.Fill(dt2);

            grid_SQL.DataSource = dt2;
            table = comboBox1.SelectedValue.ToString();
            try
            {
                ds.Tables.Remove("temp");
            }
            catch
            {
            }
            string sqlsv = "select * from " + table;
            da_temp = new SqlDataAdapter(sqlsv, conn);
            da_temp.Fill(ds, "temp");

            DataView DV = new DataView(dt2);
            DV.RowFilter = string.Format("NGAYNAP LIKE '%{0}%'", dateTimePicker1.Text);
            grid_SQL.DataSource = DV;
            conn.Close();
        }
    }
}
