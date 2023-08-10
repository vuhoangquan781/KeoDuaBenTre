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
    public partial class FormXH : DevExpress.XtraEditors.XtraForm
    {
        XUATHANGBUS xhbus = new XUATHANGBUS();
        connect cn = new connect();
        public FormXH()
        {
            InitializeComponent();
        }

        private void FormXH_Load(object sender, EventArgs e)
        {
            dvXH.DataSource = xhbus.getdata();
            string sql2 = "SELECT MAXH FROM XUATHANG";
            DataTable dt2 = cn.taobang(sql2);
            cbbMAXH.DataSource = dt2;
            cbbMAXH.ValueMember = "MAXH";
            string sql3 = "SELECT MANV FROM NHANVIEN";
            DataTable dt3 = cn.taobang(sql3);
            cbbmaNV.DataSource = dt3;
            cbbmaNV.ValueMember = "MANV";
        }

        private void dvXH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dvXH.Rows[e.RowIndex];
                cbbMAXH.Text = row.Cells[0].Value.ToString();
                cbbmaNV.Text = row.Cells[1].Value.ToString();
                dtNgay.Text = row.Cells[2].Value.ToString();
                txtDoanhThu.Text = row.Cells[3].Value.ToString();

                cbbMAXH.Enabled = false;
                cbbmaNV.Enabled = false;
                dtNgay.Enabled = false;
                txtDoanhThu.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                XUATHANG xh = new XUATHANG();
                xh.MAXH1 = cbbMAXH.Text.ToString();
                xh.MANV1 = cbbmaNV.Text.ToString();
                xh.NGAY1 = Convert.ToDateTime(dtNgay.Value.ToString());
                xh.DOANHTHU1 = (float)Convert.ToDouble(txtDoanhThu.Text.ToString());
                xhbus.InsertXUATHANG(xh);
                MessageBox.Show("Thêm Thành Công!");
                dvXH.DataSource = xhbus.getdata();
                cbbMAXH.Text = "";
                cbbmaNV.Text = "";
                dtNgay.Text = "";
                txtDoanhThu.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm Thất Bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (cbbMAXH.Text.ToString() != "")
            {
                try
                {
                    XUATHANG xh = new XUATHANG();
                    xh.MAXH1 = cbbMAXH.Text.ToString();

                    xhbus.DeleteXUATHANG(xh.MAXH1);

                    MessageBox.Show("Xoá Thành Công!");
                    dvXH.DataSource = xhbus.getdata();
                }
                catch (Exception ex) { MessageBox.Show("Xoá Thất Bại!"); }
            }
            cbbMAXH.Text = "";
            cbbmaNV.Text = "";
            dtNgay.Text = "";
            txtDoanhThu.Clear();

            cbbMAXH.Enabled = true;
            cbbmaNV.Enabled = true;
            dtNgay.Enabled = true;
            txtDoanhThu.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cbbMAXH.Enabled = false;
            cbbmaNV.Enabled = true;
            dtNgay.Enabled = true;
            txtDoanhThu.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                XUATHANG xh = new XUATHANG();
                xh.MAXH1 = cbbMAXH.Text.ToString();
                xh.MANV1 = cbbmaNV.Text.ToString();
                xh.NGAY1 = Convert.ToDateTime(dtNgay.Value.ToString());
                xh.DOANHTHU1 = (float)Convert.ToDouble(txtDoanhThu.Text.ToString());
                xhbus.UpdateXUATHANG(xh, xh.MAXH1);
                MessageBox.Show("Lưu Thành Công!");
                dvXH.DataSource = xhbus.getdata();
                cbbMAXH.Text = "";
                cbbmaNV.Text = "";
                dtNgay.Text = "";
                txtDoanhThu.Clear();

                cbbMAXH.Enabled = true;
                cbbmaNV.Enabled = true;
                dtNgay.Enabled = true;
                txtDoanhThu.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show("Lưu Thất Bại!"); }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cbbMAXH.Text = "";
            cbbmaNV.Text = "";
            dtNgay.Text = "";
            txtDoanhThu.Clear();

            cbbMAXH.Enabled = true;
            cbbmaNV.Enabled = true;
            dtNgay.Enabled = true;
            txtDoanhThu.Enabled = true;
        }
    }
}