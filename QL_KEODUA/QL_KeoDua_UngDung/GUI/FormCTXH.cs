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
    public partial class FormCTXH : DevExpress.XtraEditors.XtraForm
    {
        CTXUATHANGBUS ddhbus = new CTXUATHANGBUS();
        connect cn = new connect();
        public FormCTXH()
        {
            InitializeComponent();
        }

        private void FormCTXH_Load(object sender, EventArgs e)
        {
            dvCTXH.DataSource = ddhbus.getdata();
            string sql = "SELECT MAXH FROM XUATHANG";
            DataTable dt = cn.taobang(sql);
            cbbmaxh.DataSource = dt;
            cbbmaxh.ValueMember = "MAXH";
            dvCTXH.DataSource = ddhbus.getdata();
            string sql1 = "SELECT MASP FROM SANPHAM";
            DataTable dt1 = cn.taobang(sql1);
            cbbMaSP.DataSource = dt1;
            cbbMaSP.ValueMember = "MASP";
        }

        private void dvCTXH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dvCTXH.Rows[e.RowIndex];
                cbbmaxh.Text = row.Cells[0].Value.ToString();
                cbbMaSP.Text = row.Cells[1].Value.ToString();
                txtSL.Text = row.Cells[2].Value.ToString();
                txtTL.Text = row.Cells[3].Value.ToString();
                txtGiaBan.Text = row.Cells[4].Value.ToString();

                cbbmaxh.Enabled = false;
                cbbMaSP.Enabled = false;
                txtSL.Enabled = false;
                txtTL.Enabled = false;
                txtGiaBan.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                CTXUATHANG ctxh = new CTXUATHANG();
                ctxh.MAXH1 = cbbmaxh.Text.ToString();
                ctxh.MASP1 = cbbMaSP.Text.ToString();
                ctxh.SOLUONG1 = Convert.ToInt32(txtSL.Text.ToString());
                ctxh.TRONGLUONG1 = Convert.ToInt32(txtTL.Text.ToString());
                ctxh.GIABAN1 = Convert.ToInt32(txtGiaBan.Text.ToString());
                ddhbus.InsertCTXUATHANG(ctxh);
                MessageBox.Show("Thêm Thành Công!");
                dvCTXH.DataSource = ddhbus.getdata();
                cbbmaxh.Text = "";
                cbbMaSP.Text = "";
                txtSL.Clear();
                txtTL.Clear();
                txtGiaBan.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm Thất Bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (cbbmaxh.Text.ToString() != "" && cbbMaSP.Text.ToString() != "")
            {
                try
                {
                    CTXUATHANG ctxh = new CTXUATHANG();
                    ctxh.MAXH1 = cbbmaxh.Text.ToString();
                    ctxh.MASP1 = cbbMaSP.Text.ToString();
                    ddhbus.DeleteCTXUATHANG(ctxh.MAXH1, ctxh.MASP1);

                    MessageBox.Show("Xoá Thành Công!");
                    dvCTXH.DataSource = ddhbus.getdata();
                }
                catch (Exception ex) { MessageBox.Show("Xoá Thất Bại!"); }
            }
            cbbmaxh.Text = "";
            cbbMaSP.Text = "";
            txtSL.Clear();
            txtGiaBan.Clear();
            txtTL.Clear();
            cbbmaxh.Enabled = true;
            cbbMaSP.Enabled = true;
            txtSL.Enabled = true;
            txtGiaBan.Enabled = true;
            txtTL.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cbbmaxh.Enabled = false;
            cbbMaSP.Enabled = true;
            txtSL.Enabled = true;
            txtGiaBan.Enabled = true;
            txtTL.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cbbmaxh.Text = "";
            cbbMaSP.Text = "";
            txtSL.Clear();
            txtGiaBan.Clear();
            txtTL.Clear();

            cbbmaxh.Enabled = true;
            cbbMaSP.Enabled = true;
            txtSL.Enabled = true;
            txtGiaBan.Enabled = true;
            txtTL.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CTXUATHANG ctxh = new CTXUATHANG();
                ctxh.MAXH1 = cbbmaxh.Text.ToString();
                ctxh.MASP1 = cbbMaSP.Text.ToString();
                ctxh.SOLUONG1 = Convert.ToInt32(txtSL.Text.ToString());
                ctxh.GIABAN1 = Convert.ToInt32(txtGiaBan.Text.ToString());
                ctxh.TRONGLUONG1 = Convert.ToInt32(txtTL.Text.ToString());
                ddhbus.UpdateCTXUATHANG(ctxh, ctxh.MAXH1, ctxh.MASP1);
                MessageBox.Show("Sửa Thành Công!");
                dvCTXH.DataSource = ddhbus.getdata();
                cbbmaxh.Text = "";
                cbbMaSP.Text = "";
                txtSL.Clear();
                txtGiaBan.Clear();
                txtTL.Clear();

                cbbmaxh.Enabled = true;
                cbbMaSP.Enabled = true;
                txtSL.Enabled = true;
                txtGiaBan.Enabled = true;
                txtTL.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show("Sửa Thất Bại!"); }
        }
    }
}