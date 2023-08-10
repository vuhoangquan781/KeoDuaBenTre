using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLKeoDua.BUS;
using QLKeoDua.DTO;

namespace QL_KeoDua_UngDung.GUI
{
    public partial class FormSanPham : DevExpress.XtraEditors.XtraForm
    {
        SANPHAMBUS spbus = new SANPHAMBUS();
        connect cn = new connect();
        public FormSanPham()
        {
            InitializeComponent();
        }

        private void FormSanPham_Load(object sender, EventArgs e)
        {
            dvSP.DataSource = spbus.getdata();
            string sql = "SELECT MALOAISP FROM LOAISP";
            DataTable dt = cn.taobang(sql);
            cbMalsp.DataSource = dt;
            cbMalsp.ValueMember = "MALOAISP";
            cbMalsp.Text = "";
        }

        private void dvSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dvSP.Rows[e.RowIndex];
                txtMasp.Text = row.Cells[0].Value.ToString();
                txtTensp.Text = row.Cells[1].Value.ToString();
                cbMalsp.Text = row.Cells[2].Value.ToString();
                txtTL.Text = row.Cells[3].Value.ToString();
                txtQuycach.Text = row.Cells[4].Value.ToString();
                txtKM.Text = row.Cells[5].Value.ToString();
                txtGiaBan.Text = row.Cells[6].Value.ToString();

                txtMasp.Enabled = false;
                txtTensp.Enabled = false;
                cbMalsp.Enabled = false;
                txtTL.Enabled = false;
                txtQuycach.Enabled = false;
                txtKM.Enabled = false;
                txtGiaBan.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SANPHAM sp = new SANPHAM();
                sp.MASP1 = txtMasp.Text.ToString();
                sp.TENSP1 = txtTensp.Text.ToString();
                sp.MALOAISP1 = cbMalsp.Text.ToString();
                sp.TRONGLUONG1 = txtTL.Text.ToString();
                sp.QUYCACH1 = txtQuycach.Text.ToString();
                sp.KHUYENMAI1 = txtKM.Text.ToString();
                sp.GIABAN1 = txtGiaBan.Text.ToString();
                spbus.InsertSP(sp);
                MessageBox.Show("Thêm Thành Công!");
                dvSP.DataSource = spbus.getdata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu Thất Bại!");
            }
            txtMasp.Clear();
            txtTensp.Clear();
            cbMalsp.Text = "";
            txtTL.Clear();
            txtQuycach.Clear();
            txtKM.Clear();
            txtGiaBan.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMasp.Text.ToString() != "")
            {
                try
                {
                    SANPHAM sp = new SANPHAM();
                    sp.MASP1 = txtMasp.Text.ToString();

                    spbus.DeleteSP(sp.MASP1);

                    MessageBox.Show("Xoá Thành Công!");
                    dvSP.DataSource = spbus.getdata();
                }
                catch (Exception ex) { MessageBox.Show("Xoá Thất Bại!"); }
            }
            txtMasp.Clear();
            txtTensp.Clear();
            cbMalsp.Text = "";
            txtTL.Clear();
            txtQuycach.Clear();
            txtKM.Clear();
            txtGiaBan.Clear();
            txtMasp.Enabled = true;
            txtTensp.Enabled = true;
            cbMalsp.Enabled = true;
            txtTL.Enabled = true;
            txtQuycach.Enabled = true;
            txtKM.Enabled = true;
            txtGiaBan.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMasp.Enabled = false;
            txtTensp.Enabled = true;
            cbMalsp.Enabled = true;
            txtTL.Enabled = true;
            txtQuycach.Enabled = true;
            txtKM.Enabled = true;
            txtGiaBan.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SANPHAM sp = new SANPHAM();
                sp.MASP1 = txtMasp.Text.ToString();
                sp.TENSP1 = txtTensp.Text.ToString();
                sp.MALOAISP1 = cbMalsp.Text.ToString();
                sp.TRONGLUONG1 = txtTL.Text.ToString();
                sp.QUYCACH1 = txtQuycach.Text.ToString();
                sp.KHUYENMAI1 = txtKM.Text.ToString();
                sp.GIABAN1 = txtGiaBan.Text.ToString();
                spbus.UpdateSP(sp, sp.MASP1);
                MessageBox.Show("Lưu Thành Công!");
                dvSP.DataSource = spbus.getdata();
            }
            catch (Exception ex) { MessageBox.Show("Lưu Thất Bại!"); }
            txtMasp.Clear();
            txtTensp.Clear();
            cbMalsp.Text = "";
            txtTL.Clear();
            txtKM.Clear();
            txtGiaBan.Clear();
            txtQuycach.Clear();
            txtMasp.Enabled = true;
            txtTensp.Enabled = true;
            cbMalsp.Enabled = true;
            txtTL.Enabled = true;
            txtQuycach.Enabled = true;
            txtKM.Enabled = true;
            txtGiaBan.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMasp.Clear();
            txtTensp.Clear();
            cbMalsp.Text = "";
            txtTL.Clear();
            txtKM.Clear();
            txtGiaBan.Clear();
            txtQuycach.Clear();
            txtMasp.Enabled = true;
            txtTensp.Enabled = true;
            cbMalsp.Enabled = true;
            txtTL.Enabled = true;
            txtQuycach.Enabled = true;
            txtKM.Enabled = true;
            txtGiaBan.Enabled = true;
        }
    }
}