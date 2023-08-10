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
    public partial class FormTinh : DevExpress.XtraEditors.XtraForm
    {
        TINHBUS tinhbus = new TINHBUS();
        connect cn = new connect();
        public FormTinh()
        {
            InitializeComponent();
        }

        private void FormTinh_Load(object sender, EventArgs e)
        {
            dvTinh.DataSource = tinhbus.getdata();
            string sql = "SELECT MAKV FROM KHUVUC";
            DataTable dt = cn.taobang(sql);
            cbMakv.DataSource = dt;
            cbMakv.ValueMember = "MAKV";
        }

        private void dvTinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dvTinh.Rows[e.RowIndex];
                txtMakvc.Text = row.Cells[0].Value.ToString();
                txtTenkvc.Text = row.Cells[1].Value.ToString();
                cbMakv.Text = row.Cells[2].Value.ToString();

                txtMakvc.Enabled = false;
                txtTenkvc.Enabled = false;
                cbMakv.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                TINH t = new TINH();
                t.makvc = txtMakvc.Text.ToString();
                t.tenkvc = txtTenkvc.Text.ToString();
                t.makv = cbMakv.Text.ToString();
                tinhbus.InsertTINH(t);
                MessageBox.Show("Thêm Thành Công!");
                dvTinh.DataSource = tinhbus.getdata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm Thất Bại!");
            }
            txtMakvc.Clear();
            txtTenkvc.Clear();
            cbMakv.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMakvc.Text.ToString() != "")
            {
                try
                {
                    TINH t = new TINH();
                    t.makvc = txtMakvc.Text.ToString();

                    tinhbus.DeleteTINH(t.makvc);

                    MessageBox.Show("Xoá Thành Công!");
                    dvTinh.DataSource = tinhbus.getdata();
                }
                catch (Exception ex) { MessageBox.Show("Xoá Thất Bại!"); }
                txtMakvc.Clear();
                txtTenkvc.Clear();
                cbMakv.Text = "";
                txtMakvc.Enabled = true;
                txtTenkvc.Enabled = true;
                cbMakv.Enabled = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMakvc.Enabled = false;
            txtTenkvc.Enabled = true;
            cbMakv.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMakvc.Clear();
            txtTenkvc.Clear();
            cbMakv.Text = "";
            txtMakvc.Enabled = true;
            txtTenkvc.Enabled = true;
            cbMakv.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                TINH t = new TINH();
                t.makvc = txtMakvc.Text.ToString();
                t.tenkvc = txtTenkvc.Text.ToString();
                t.makv = cbMakv.Text.ToString();
                tinhbus.UpdateTINH(t, t.makvc);
                MessageBox.Show("Lưu Thành Công!");
                dvTinh.DataSource = tinhbus.getdata();
            }
            catch (Exception ex) { MessageBox.Show("Lưu Thất Bại!"); }
            txtMakvc.Clear();
            txtTenkvc.Clear();
            cbMakv.Text = "";
            txtMakvc.Enabled = true;
            txtTenkvc.Enabled = true;
            cbMakv.Enabled = true;
        }
    }
}