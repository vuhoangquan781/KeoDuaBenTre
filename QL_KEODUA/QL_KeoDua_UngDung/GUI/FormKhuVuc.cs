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
    public partial class FormKhuVuc : DevExpress.XtraEditors.XtraForm
    {
        KHUVUCBUS khuvucbus = new KHUVUCBUS();
        connect cn = new connect();
        public FormKhuVuc()
        {
            InitializeComponent();
        }

        private void dvKhuVuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dvKhuVuc.Rows[e.RowIndex];
                txtMakv.Text = row.Cells[0].Value.ToString();
                txtTenkv.Text = row.Cells[1].Value.ToString();

                txtMakv.Enabled = false;
                txtTenkv.Enabled = false;
            }
        }

        private void FormKhuVuc_Load(object sender, EventArgs e)
        {
            dvKhuVuc.DataSource = khuvucbus.getdata();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                KHUVUC kv = new KHUVUC();
                kv.makv = txtMakv.Text.ToString();
                kv.tenkv = txtTenkv.Text.ToString();
                khuvucbus.InsertKHUVUC(kv);
                MessageBox.Show("Thêm Thành Công!");
                dvKhuVuc.DataSource = khuvucbus.getdata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm Thất Bại!");
            }
            txtMakv.Clear();
            txtTenkv.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMakv.Text.ToString() != "")
            {
                try
                {
                    KHUVUC kv = new KHUVUC();
                    kv.makv = txtMakv.Text.ToString();

                    khuvucbus.DeleteKHUVUC(kv.makv);

                    MessageBox.Show("Xoá Thành Công!");
                    dvKhuVuc.DataSource = khuvucbus.getdata();
                }
                catch (Exception ex) { MessageBox.Show("Xoá Thất Bại!"); }
            }
            txtMakv.Clear();
            txtTenkv.Clear();
            txtMakv.Enabled = true;
            txtTenkv.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMakv.Enabled = false;
            txtTenkv.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                KHUVUC kv = new KHUVUC();
                kv.makv = txtMakv.Text.ToString();
                kv.tenkv = txtTenkv.Text.ToString();
                khuvucbus.UpdateKHUVUC(kv, kv.makv);
                MessageBox.Show("Lưu Thành Công!");
                dvKhuVuc.DataSource = khuvucbus.getdata();
            }
            catch (Exception ex) { MessageBox.Show("Lưu Thất Bại!"); }
            txtMakv.Enabled = true;
            txtTenkv.Enabled = true;
            txtMakv.Clear();
            txtTenkv.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMakv.Clear();
            txtTenkv.Clear();
            txtMakv.Enabled = true;
            txtTenkv.Enabled = true;
        }
    }
}