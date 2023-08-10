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
    public partial class FormCTDDH : DevExpress.XtraEditors.XtraForm
    {
        CTDONDATHANGBUS ddhbus = new CTDONDATHANGBUS();
        connect cn = new connect();
        public FormCTDDH()
        {
            InitializeComponent();
        }

        private void dvCTDDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dvCTDDH.Rows[e.RowIndex];
                cbbmaddh.Text = row.Cells[0].Value.ToString();
                cbbMaSP.Text = row.Cells[1].Value.ToString();
                txtSL.Text = row.Cells[2].Value.ToString();

                cbbmaddh.Enabled = false;
                cbbMaSP.Enabled = false;
                txtSL.Enabled = false;
            }
        }

        private void FormCTDDH_Load(object sender, EventArgs e)
        {
            dvCTDDH.DataSource = ddhbus.getdata();
            string sql = "SELECT MADDH FROM DONDATHANG";
            DataTable dt = cn.taobang(sql);
            cbbmaddh.DataSource = dt;
            cbbmaddh.ValueMember = "MADDH";
            dvCTDDH.DataSource = ddhbus.getdata();
            string sql1 = "SELECT MASP FROM SANPHAM";
            DataTable dt1 = cn.taobang(sql1);
            cbbMaSP.DataSource = dt1;
            cbbMaSP.ValueMember = "MASP";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                CTDONDATHANG ctddh = new CTDONDATHANG();
                ctddh.MADDH1 = cbbmaddh.Text.ToString();
                ctddh.MASP1 = cbbMaSP.Text.ToString();
                ctddh.SOLUONG1 = Convert.ToInt32(txtSL.Text.ToString());
                ddhbus.InsertCTDDH(ctddh);
                MessageBox.Show("Thêm Thành Công!");
                dvCTDDH.DataSource = ddhbus.getdata();
                cbbmaddh.Text = "";
                cbbMaSP.Text = "";
                txtSL.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm Thất Bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (cbbmaddh.Text.ToString() != "")
            {
                try
                {
                    DONDATHANG ddh = new DONDATHANG();
                    ddh.MADDH1 = cbbmaddh.Text.ToString();

                    ddhbus.DeleteCTDDH(ddh.MADDH1);

                    MessageBox.Show("Xoá Thành Công!");
                    dvCTDDH.DataSource = ddhbus.getdata();
                }
                catch (Exception ex) { MessageBox.Show("Xoá Thất Bại!"); }
            }
            cbbmaddh.Text = "";
            cbbMaSP.Text = "";
            txtSL.Clear();

            cbbmaddh.Enabled = true;
            cbbMaSP.Enabled = true;
            txtSL.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cbbmaddh.Enabled = false;
            cbbMaSP.Enabled = true;
            txtSL.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cbbmaddh.Text = "";
            cbbMaSP.Text = "";
            txtSL.Clear();

            cbbmaddh.Enabled = true;
            cbbMaSP.Enabled = true;
            txtSL.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CTDONDATHANG ctddh = new CTDONDATHANG();
                ctddh.MADDH1 = cbbmaddh.Text.ToString();
                ctddh.MASP1 = cbbMaSP.Text.ToString();
                ctddh.SOLUONG1 = Convert.ToInt32(txtSL.Text.ToString());
                ddhbus.UpdateCTDDH(ctddh, ctddh.MADDH1);
                MessageBox.Show("Lưu Thành Công!");
                dvCTDDH.DataSource = ddhbus.getdata();
                cbbmaddh.Text = "";
                cbbMaSP.Text = "";
                txtSL.Clear();

                cbbmaddh.Enabled = true;
                cbbMaSP.Enabled = true;
                txtSL.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show("Lưu Thất Bại!"); }
        }
    }
}