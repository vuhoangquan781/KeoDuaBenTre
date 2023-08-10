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
using WindowsFormsApp1.BUS;
using QLKeoDua.DTO;

namespace QL_KeoDua_UngDung.GUI
{
    public partial class FormDDH : DevExpress.XtraEditors.XtraForm
    {
        DONDATHANGBUS ddhbus = new DONDATHANGBUS();
        connect cn = new connect();
        public FormDDH()
        {
            InitializeComponent();
        }

        private void dvDDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dvDDH.Rows[e.RowIndex];
                txtMaDDH.Text = row.Cells[0].Value.ToString();
                cbbmaKhach.Text = row.Cells[1].Value.ToString();
                cbNPP.Text = row.Cells[2].Value.ToString();
                dtNgay.Text = row.Cells[3].Value.ToString();
                txtSTHD.Text = row.Cells[4].Value.ToString();
                txtGiamGia.Text = row.Cells[5].Value.ToString();
                txtTT.Text = row.Cells[6].Value.ToString();

                txtMaDDH.Enabled = false;
                cbbmaKhach.Enabled = false;
                cbNPP.Enabled = false;
                dtNgay.Enabled = false;
                txtSTHD.Enabled = false;
                txtGiamGia.Enabled = false;
                txtTT.Enabled = false;
            }
        }

        private void FormDDH_Load(object sender, EventArgs e)
        {
            dvDDH.DataSource = ddhbus.getdata();
            string sql = "SELECT MAKHACH FROM KHACHHANG";
            DataTable dt = cn.taobang(sql);
            cbbmaKhach.DataSource = dt;
            cbbmaKhach.ValueMember = "MAKHACH";
            string sql1 = "SELECT MANPP FROM NHAPP";
            DataTable dt1 = cn.taobang(sql1);
            cbNPP.DataSource = dt1;
            cbNPP.ValueMember = "MANPP";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                DONDATHANG ddh = new DONDATHANG();
                ddh.MADDH1 = txtMaDDH.Text.ToString();
                ddh.MAKHACH1 = cbbmaKhach.Text.ToString();
                ddh.MANPP1 = cbNPP.Text.ToString();
                ddh.NGAY1 = Convert.ToDateTime(dtNgay.Value.ToString("yyyy/MM/dd"));
                ddh.SOTIENHD1 = (float)Convert.ToDouble(txtSTHD.Text.ToString());
                ddh.NPP6PT1 = (float)Convert.ToDouble(txtGiamGia.Text.ToString());
                ddh.SOTHANHTOAN1 = (float)Convert.ToDouble(txtTT.Text.ToString());
                ddhbus.InsertDDH(ddh);
                MessageBox.Show("Thêm Thành Công!");
                dvDDH.DataSource = ddhbus.getdata();
                txtMaDDH.Clear();
                cbbmaKhach.Text = "";
                cbNPP.Text = "";
                dtNgay.Text = "";
                txtSTHD.Clear();
                txtGiamGia.Clear();
                txtTT.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm Thất Bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaDDH.Text.ToString() != "")
            {
                try
                {
                    DONDATHANG ddh = new DONDATHANG();
                    ddh.MADDH1 = txtMaDDH.Text.ToString();

                    ddhbus.DeleteDDH(ddh.MADDH1);

                    MessageBox.Show("Xoá Thành Công!");
                    dvDDH.DataSource = ddhbus.getdata();
                }
                catch (Exception ex) { MessageBox.Show("Xoá Thất Bại!"); }
            }
            txtMaDDH.Clear();
            cbbmaKhach.Text = "";
            cbNPP.Text = "";
            dtNgay.Text = "";
            txtGiamGia.Clear();
            txtSTHD.Clear();
            txtTT.Clear();

            txtMaDDH.Enabled = true;
            cbbmaKhach.Enabled = true;
            cbNPP.Enabled = true;
            dtNgay.Enabled = true;
            txtGiamGia.Enabled = true;
            txtSTHD.Enabled = true;
            txtTT.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaDDH.Enabled = false;
            cbbmaKhach.Enabled = true;
            cbNPP.Enabled = true;
            dtNgay.Enabled = true;
            txtGiamGia.Enabled = true;
            txtSTHD.Enabled = true;
            txtTT.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaDDH.Clear();
            cbbmaKhach.Text = "";
            cbNPP.Text = "";
            dtNgay.Text = "";
            txtGiamGia.Clear();
            txtSTHD.Clear();
            txtTT.Clear();

            txtMaDDH.Enabled = true;
            cbbmaKhach.Enabled = true;
            cbNPP.Enabled = true;
            dtNgay.Enabled = true;
            txtGiamGia.Enabled = true;
            txtSTHD.Enabled = true;
            txtTT.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DONDATHANG ddh = new DONDATHANG();
                ddh.MADDH1 = txtMaDDH.Text.ToString();
                ddh.MAKHACH1 = cbbmaKhach.Text.ToString();
                ddh.MANPP1 = cbNPP.Text.ToString();
                ddh.NGAY1 = Convert.ToDateTime(dtNgay.Value.ToString("yyyy/MM/dd"));
                ddh.SOTIENHD1 = (float)Convert.ToDouble(txtSTHD.Text.ToString());
                ddh.NPP6PT1 = (float)Convert.ToDouble(txtGiamGia.Text.ToString());
                ddh.SOTHANHTOAN1 = (float)Convert.ToDouble(txtTT.Text.ToString());
                ddhbus.UpdateDDH(ddh, ddh.MADDH1);
                MessageBox.Show("Lưu Thành Công!");
                dvDDH.DataSource = ddhbus.getdata();
                txtMaDDH.Clear();
                cbbmaKhach.Text = "";
                cbNPP.Text = "";
                dtNgay.Text = "";
                txtGiamGia.Clear();
                txtSTHD.Clear();
                txtTT.Clear();

                txtMaDDH.Enabled = true;
                cbbmaKhach.Enabled = true;
                cbNPP.Enabled = true;
                dtNgay.Enabled = true;
                txtGiamGia.Enabled = true;
                txtSTHD.Enabled = true;
                txtTT.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show("Lưu Thất Bại!"); }
        }
    }
}