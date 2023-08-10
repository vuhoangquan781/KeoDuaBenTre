using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WindowsFormsApp1.BUS;
using QLKeoDua.DTO;

namespace QL_KeoDua_UngDung.GUI
{
    public partial class FormCapQuyen : DevExpress.XtraEditors.XtraUserControl
    {
        CAPQUYENBUS cvbus = new CAPQUYENBUS();
        connect cn = new connect();
        public FormCapQuyen()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                comboBox1.Text = row.Cells[5].Value.ToString();
                comboBox2.Text = row.Cells[6].Value.ToString();
                textBox1.Enabled = false;
            }
        }

        private void FormCapQuyen_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cvbus.getdata();
            string sql = "SELECT DISTINCT ChucVu FROM ACCOUNT";
            DataTable dt = cn.taobang(sql);
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "ChucVu";
            dataGridView1.DataSource = cvbus.getdata();
            string sql1 = "SELECT DISTINCT Quyen FROM ACCOUNT";
            DataTable dt1 = cn.taobang(sql1);
            comboBox2.DataSource = dt1;
            comboBox2.ValueMember = "Quyen";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                CAPQUYEN cq = new CAPQUYEN();
                cq.TenDangNhap1 = textBox1.Text.ToString();
                cq.MatKhau1 = textBox2.Text.ToString();
                cq.TenNV1 = textBox3.Text.ToString();
                cq.SDT1 = textBox4.Text.ToString();
                cq.Email1 = textBox5.Text.ToString();
                cq.ChucVu1 = comboBox1.Text.ToString();
                cq.Quyen1 = Convert.ToInt32(comboBox2.Text.ToString());
                cvbus.InsertCQ(cq);
                MessageBox.Show("Thêm Thành Công!");
                dataGridView1.DataSource = cvbus.getdata();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                comboBox1.Text = "";
                comboBox2.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm Thất Bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString() != "")
            {
                try
                {
                    CAPQUYEN cq = new CAPQUYEN();
                    cq.TenDangNhap1 = textBox1.Text.ToString();

                    cvbus.DeleteCQ(cq.TenDangNhap1);

                    MessageBox.Show("Xoá Thành Công!");
                    dataGridView1.DataSource = cvbus.getdata();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                }
                catch (Exception ex) { MessageBox.Show("Xoá Thất Bại!"); }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                CAPQUYEN cq = new CAPQUYEN();
                cq.TenDangNhap1 = textBox1.Text.ToString();
                cq.MatKhau1 = textBox2.Text.ToString();
                cq.TenNV1 = textBox3.Text.ToString();
                cq.SDT1 = textBox4.Text.ToString();
                cq.Email1 = textBox5.Text.ToString();
                cq.ChucVu1 = comboBox1.Text.ToString();
                cq.Quyen1 = Convert.ToInt32(comboBox2.Text.ToString());
                cvbus.UpdateCQ(cq, cq.TenDangNhap1);
                MessageBox.Show("Sửa Thành Công!");
                dataGridView1.DataSource = cvbus.getdata();
            }
            catch (Exception ex) { MessageBox.Show("Sửa Thất Bại!"); }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            FormGiaoDien frmMain = new FormGiaoDien();
            this.Hide();
            frmMain.Refresh();
        }
    }
}
