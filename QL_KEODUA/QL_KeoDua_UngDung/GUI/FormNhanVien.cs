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
    public partial class FormNhanVien : DevExpress.XtraEditors.XtraForm
    {
        NHANVIENBUS nvbus = new NHANVIENBUS();
        connect cn = new connect();
        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            dvNV.DataSource = nvbus.getdata();
            string sql2 = "SELECT MACN FROM CHINHANH";
            DataTable dt2 = cn.taobang(sql2);
            cbbmaCN.DataSource = dt2;
            cbbmaCN.ValueMember = "MACN";

            dvNV.DataSource = nvbus.getdata();
            cbbGioiTinh.Items.Add("Nam");
            cbbGioiTinh.Items.Add("Nữ");
        }

        private void dvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dvNV.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells[0].Value.ToString();
                txtTenNV.Text = row.Cells[1].Value.ToString();
                cbbGioiTinh.Text = row.Cells[2].Value.ToString();
                txtDiaChi.Text = row.Cells[3].Value.ToString();
                cbbmaCN.Text = row.Cells[4].Value.ToString();

                txtMaNV.Enabled = false;
                txtTenNV.Enabled = false;
                txtDiaChi.Enabled = false;
                cbbGioiTinh.Enabled = false;
                cbbmaCN.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                NHANVIEN nv = new NHANVIEN();
                nv.MANV1 = txtMaNV.Text.ToString();
                nv.MACN1 = cbbmaCN.Text.ToString();
                nv.TENV1 = txtTenNV.Text.ToString();
                nv.GIOITINH1 = cbbGioiTinh.Text.ToString();
                nv.DIACHI1 = txtDiaChi.Text.ToString();

                nvbus.InsertNV(nv);
                MessageBox.Show("Thêm Thành Công!");
                dvNV.DataSource = nvbus.getdata();

                cbbmaCN.Text = "";
                cbbGioiTinh.Text = "";
                txtDiaChi.Clear();
                txtMaNV.Clear();
                txtTenNV.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm Thất Bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.ToString() != "")
            {
                try
                {
                    NHANVIEN nv = new NHANVIEN();
                    nv.MANV1 = txtMaNV.Text.ToString();

                    nvbus.DeleteNV(nv.MANV1);

                    MessageBox.Show("Xoá Thành Công!");
                    dvNV.DataSource = nvbus.getdata();
                }
                catch (Exception ex) { MessageBox.Show("Xoá Thất Bại!"); }
            }
            cbbmaCN.Text = "";
            cbbGioiTinh.Text = "";
            txtDiaChi.Clear();
            txtMaNV.Clear();
            txtTenNV.Clear();

            cbbmaCN.Enabled = true;
            cbbGioiTinh.Enabled = true;
            txtDiaChi.Enabled = true;
            txtMaNV.Enabled = true;
            txtTenNV.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cbbmaCN.Enabled = true;
            cbbGioiTinh.Enabled = true;
            txtDiaChi.Enabled = true;
            txtMaNV.Enabled = false;
            txtTenNV.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cbbmaCN.Text = "";
            cbbGioiTinh.Text = "";
            txtDiaChi.Clear();
            txtMaNV.Clear();
            txtTenNV.Clear();

            cbbmaCN.Enabled = true;
            cbbGioiTinh.Enabled = true;
            txtDiaChi.Enabled = true;
            txtMaNV.Enabled = true;
            txtTenNV.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                NHANVIEN nv = new NHANVIEN();
                nv.MANV1 = txtMaNV.Text.ToString();
                nv.MACN1 = cbbmaCN.Text.ToString();
                nv.GIOITINH1 = cbbGioiTinh.Text.ToString();
                nv.TENV1 = txtTenNV.Text.ToString();
                nv.DIACHI1 = txtDiaChi.Text.ToString();
                nvbus.UpdateNV(nv, nv.MANV1);
                MessageBox.Show("Lưu Thành Công!");
                dvNV.DataSource = nvbus.getdata();
                cbbmaCN.Text = "";
                cbbGioiTinh.Text = "";
                txtDiaChi.Clear();
                txtMaNV.Clear();
                txtTenNV.Clear();

                cbbmaCN.Enabled = true;
                cbbGioiTinh.Enabled = true;
                txtDiaChi.Enabled = true;
                txtMaNV.Enabled = true;
                txtTenNV.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show("Lưu Thất Bại!"); }
        }
    }
}