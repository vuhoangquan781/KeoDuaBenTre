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
    public partial class FormNhaPP : DevExpress.XtraEditors.XtraForm
    {
        NHAPPBUS nhappbus = new NHAPPBUS();
        connect cn = new connect();
        public FormNhaPP()
        {
            InitializeComponent();
        }

        private void FormNhaPP_Load(object sender, EventArgs e)
        {
            dvNhaPP.DataSource = nhappbus.getdata();
            string sql = "SELECT MAKVC FROM TINH";
            DataTable dt = cn.taobang(sql);
            cbMakvc.DataSource = dt;
            cbMakvc.ValueMember = "MAKVC";
        }

        private void dvNhaPP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dvNhaPP.Rows[e.RowIndex];
                txtManpp.Text = row.Cells[0].Value.ToString();
                txtTennpp.Text = row.Cells[1].Value.ToString();
                cbMakvc.Text = row.Cells[2].Value.ToString();

                txtManpp.Enabled = false;
                txtTennpp.Enabled = false;
                cbMakvc.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                NHAPP npp = new NHAPP();
                npp.manpp = txtManpp.Text.ToString();
                npp.tennpp = txtTennpp.Text.ToString();
                npp.makvc = cbMakvc.Text.ToString();
                nhappbus.InsertNHAPP(npp);
                MessageBox.Show("Thêm Thành Công!");
                dvNhaPP.DataSource = nhappbus.getdata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Trùng mã nhà phân phối!");
            }
            txtManpp.Clear();
            txtTennpp.Clear();
            cbMakvc.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtManpp.Text.ToString() != "")
            {
                try
                {
                    NHAPP npp = new NHAPP();
                    npp.manpp = txtManpp.Text.ToString();

                    nhappbus.DeleteNHAPP(npp.manpp);

                    MessageBox.Show("Xoá Thành Công!");
                    dvNhaPP.DataSource = nhappbus.getdata();
                }
                catch (Exception ex) { MessageBox.Show("Xoá Thất Bại!"); }
            }
            txtManpp.Clear();
            txtTennpp.Clear();
            cbMakvc.Text = "";
            txtManpp.Enabled = true;
            txtTennpp.Enabled = true;
            cbMakvc.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtTennpp.Enabled = true;
            cbMakvc.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtManpp.Clear();
            txtTennpp.Clear();
            cbMakvc.Text = "";
            txtManpp.Enabled = true;
            txtTennpp.Enabled = true;
            cbMakvc.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                NHAPP npp = new NHAPP();
                npp.manpp = txtManpp.Text.ToString();
                npp.tennpp = txtTennpp.Text.ToString();
                npp.makvc = cbMakvc.Text.ToString();
                nhappbus.UpdateNHAPP(npp, npp.manpp);
                MessageBox.Show("Lưu Thành Công!");
                dvNhaPP.DataSource = nhappbus.getdata();
            }
            catch (Exception ex) { MessageBox.Show("Lưu Thất Bại!"); }
            txtManpp.Clear();
            txtTennpp.Clear();
            cbMakvc.Text = "";
            txtManpp.Enabled = true;
        }
    }
}