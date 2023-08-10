using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace DXApplication2
{
    public partial class FormBackupAndRestore : Form
    {
        private SqlConnection conn;
        private SqlCommand command;
        private SqlDataReader reader;
        string sql = "";
        string connectionString = "";
        public FormBackupAndRestore()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            simpleButton2.Enabled = false;
            cmbDatabase.Enabled = false;
            txtBackup.Enabled = false;
            txtRestore.Enabled = false;
            simpleButton3.Enabled = false;
            simpleButton4.Enabled = false;
            simpleButton5.Enabled = false;
            simpleButton6.Enabled = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                connectionString = "Data Source=localhost;Integrated Security=True";
                conn = new SqlConnection(connectionString);
                conn.Open();
                sql = "EXEC sp_databases";
                command = new SqlCommand(sql, conn);
                reader = command.ExecuteReader();
                cmbDatabase.Items.Clear();
                while (reader.Read())
                {
                    cmbDatabase.Items.Add(reader[0].ToString());
                }
                reader.Dispose();
                conn.Close();
                conn.Dispose();
                //txtDataSoure.Enabled = false;
                //txtID.Enabled = false;
                //txtPassword.Enabled = false;
                simpleButton1.Enabled = false;
                simpleButton2.Enabled = true;
                simpleButton3.Enabled = false;
                simpleButton4.Enabled = false;
                simpleButton5.Enabled = false;
                simpleButton6.Enabled = false;
                cmbDatabase.Enabled = true;
                txtBackup.Enabled = false;
                txtRestore.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            cmbDatabase.Text = string.Empty;
            cmbDatabase.Items.Clear();
            //txtDataSoure.Enabled = true;
            //txtID.Enabled = true;
            //txtPassword.Enabled = true;
            cmbDatabase.Enabled = false;
            txtBackup.Enabled = false;
            txtRestore.Enabled = false;
            simpleButton1.Enabled = true;
            simpleButton2.Enabled = false;
            simpleButton3.Enabled = false;
            simpleButton4.Enabled = false;
            simpleButton5.Enabled = false;
            simpleButton6.Enabled = false;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtBackup.Text = dlg.SelectedPath;
            }
            simpleButton4.Enabled = true;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDatabase.Text.CompareTo("") == 0)
                {
                    MessageBox.Show("Chọn Database.");
                    return;
                }
                conn = new SqlConnection(connectionString);
                conn.Open();
                sql = "BACKUP DATABASE " + cmbDatabase.Text + " TO DISK = '" + txtBackup.Text.Trim() + "\\" + cmbDatabase.Text + "-" + DateTime.Now.Ticks.ToString() + ".bak'";
                command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
                MessageBox.Show("Thành Công Backup Dữ Liệu");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Backup Files(*.bak)|*.bak|ALL Files(*.*)|*.*";
            dlg.FilterIndex = 0;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtRestore.Text = dlg.FileName;
            }
            simpleButton6.Enabled = true;
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDatabase.Text.CompareTo("") == 0)
                {
                    MessageBox.Show("Chọn Database.");
                    return;
                }
                conn = new SqlConnection(connectionString);
                conn.Open();
                sql = " ALTER DATABASE " + cmbDatabase.Text + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                sql += " RESTORE DATABASE " + cmbDatabase.Text + " FROM DISK = '" + txtRestore.Text.Trim() + "' WITH REPLACE;";
                command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
                MessageBox.Show("Thành Công Restore Dữ Liệu");
                FormLOGIN frm = new FormLOGIN();
                this.Hide();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            simpleButton3.Enabled = true;
            simpleButton4.Enabled = false;
            simpleButton5.Enabled = true;
            simpleButton6.Enabled = false;
            txtBackup.Enabled = true;
            txtRestore.Enabled = true;
        }

        private void btnQL_Click(object sender, EventArgs e)
        {
            FormMain frm = new FormMain();
            this.Hide();
            frm.ShowDialog();
        }
    }
}
