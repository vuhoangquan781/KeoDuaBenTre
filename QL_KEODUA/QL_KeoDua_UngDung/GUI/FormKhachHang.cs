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
    public partial class FormKhachHang : DevExpress.XtraEditors.XtraForm
    {
        KHACHHANGBUS khachbus = new KHACHHANGBUS();
        connect cn = new connect();
        public FormKhachHang()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                KHACHHANG khachh = new KHACHHANG();
                khachh.makhach = txtMaKH.Text.ToString();
                khachh.tenkhach = txtTenKH.Text.ToString();
                khachh.gioitinh = cbGT.Text.ToString();
                khachh.ngaysinh = dtKH.Text.ToString();
                khachh.nghenghiep = txtNgheNghiep.Text.ToString();
                khachh.sdt = txtSDT.Text.ToString();
                khachbus.InsertKHACHHANG(khachh);
                MessageBox.Show("Thêm Thành Công!");
                dvKhach.DataSource = khachbus.getdata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm Thất Bại!");
            }
            txtMaKH.Clear();
            txtTenKH.Clear();
            cbGT.Text = "";
            dtKH.Text="";
            txtNgheNghiep.Clear();
            txtSDT.Clear();
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            dvKhach.DataSource = khachbus.getdata();
            cbGT.Items.Add("Nam");
            cbGT.Items.Add("Nữ");
        }

        private void dvKhach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dvKhach.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells[0].Value.ToString();
                txtTenKH.Text = row.Cells[1].Value.ToString();
                cbGT.Text = row.Cells[2].Value.ToString();
                dtKH.Text = row.Cells[3].Value.ToString();
                txtNgheNghiep.Text = row.Cells[4].Value.ToString();
                txtSDT.Text = row.Cells[5].Value.ToString();

                txtMaKH.Enabled = false;
                txtTenKH.Enabled = false;
                cbGT.Enabled = false;
                dtKH.Enabled = false;
                txtNgheNghiep.Enabled = false;
                txtSDT.Enabled = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text.ToString() != "")
            {
                try
                {
                    KHACHHANG khachh = new KHACHHANG();
                    khachh.makhach = txtMaKH.Text.ToString();

                    khachbus.DeleteKHACHHANG(khachh.makhach);

                    MessageBox.Show("Xoá Thành Công!");
                    dvKhach.DataSource = khachbus.getdata();
                }
                catch (Exception ex) { MessageBox.Show("Xóa Thất Bại!"); }
            }
            txtMaKH.Clear();
            txtTenKH.Clear();
            cbGT.Text = "";
            dtKH.Text="";
            txtNgheNghiep.Clear();
            txtSDT.Clear();

            txtMaKH.Enabled = true;
            txtTenKH.Enabled = true;
            txtNgheNghiep.Enabled = true;
            dtKH.Enabled = true;
            txtSDT.Enabled = true;
            cbGT.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaKH.Enabled = false;
            txtTenKH.Enabled = true;
            cbGT.Enabled = true;
            dtKH.Enabled = true;
            txtNgheNghiep.Enabled = true;
            txtSDT.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtNgheNghiep.Clear();
            dtKH.Text="";
            txtSDT.Clear();
            cbGT.Text = "";

            txtMaKH.Enabled = true;
            txtTenKH.Enabled = true;
            txtNgheNghiep.Enabled = true;
            dtKH.Enabled = true;
            txtSDT.Enabled = true;
            cbGT.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                KHACHHANG khachh = new KHACHHANG();
                khachh.makhach = txtMaKH.Text.ToString();
                khachh.tenkhach = txtTenKH.Text.ToString();
                khachh.gioitinh = cbGT.Text.ToString();
                khachh.ngaysinh = dtKH.Text.ToString();
                khachh.nghenghiep = txtNgheNghiep.Text.ToString();
                khachh.sdt = txtSDT.Text.ToString();
                khachbus.UpdateKHACHHANG(khachh, khachh.makhach);
                MessageBox.Show("Lưu Thành Công!");
                dvKhach.DataSource = khachbus.getdata();
            }
            catch (Exception ex) { MessageBox.Show("Lưu thất bại!"); }
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtNgheNghiep.Clear();
            dtKH.Text="";
            txtSDT.Clear();
            cbGT.Text = "";
            txtMaKH.Enabled = true;
        }

    }
}