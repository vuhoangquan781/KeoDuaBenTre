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
    public partial class FormLoaiSP : DevExpress.XtraEditors.XtraForm
    {
        LOAISPBUS lspbus = new LOAISPBUS();
        connect cn = new connect();
        public FormLoaiSP()
        {
            InitializeComponent();
        }

        private void dvLSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dvLSP.Rows[e.RowIndex];
                txtMalsp.Text = row.Cells[0].Value.ToString();
                txtTenlsp.Text = row.Cells[1].Value.ToString();

                txtMalsp.Enabled = false;
                txtTenlsp.Enabled = false;
            }
        }

        private void FormLoaiSP_Load(object sender, EventArgs e)
        {
            dvLSP.DataSource = lspbus.getdata();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                LOAISP lsp = new LOAISP();
                lsp.MALOAISP1 = txtMalsp.Text.ToString();
                lsp.TENLOAISP1 = txtTenlsp.Text.ToString();
                lspbus.InsertLSP(lsp);
                MessageBox.Show("Thêm Thành Công!");
                dvLSP.DataSource = lspbus.getdata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm Thất Bại!");
            }
            txtMalsp.Clear();
            txtTenlsp.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMalsp.Text.ToString() != "")
            {
                try
                {
                    LOAISP lsp = new LOAISP();
                    lsp.MALOAISP1 = txtMalsp.Text.ToString();
                    lspbus.DeleteLSP(lsp.MALOAISP1);

                    MessageBox.Show("Xoá Thành Công!");
                    dvLSP.DataSource = lspbus.getdata();
                }
                catch (Exception ex) { MessageBox.Show("Xoá Thất Bại!"); }
            }
            txtMalsp.Clear();
            txtTenlsp.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMalsp.Enabled = false;
            txtTenlsp.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMalsp.Clear();
            txtTenlsp.Clear();
            txtMalsp.Enabled = true;
            txtTenlsp.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                LOAISP lsp = new LOAISP();
                lsp.MALOAISP1 = txtMalsp.Text.ToString();
                lsp.TENLOAISP1 = txtTenlsp.Text.ToString();
                lspbus.UpdateLSP(lsp, lsp.MALOAISP1);
                MessageBox.Show("Lưu Thành Công!");
                dvLSP.DataSource = lspbus.getdata();
            }
            catch (Exception ex) { MessageBox.Show("Lưu Thất Bại!"); }
            txtMalsp.Clear();
            txtTenlsp.Clear();
            txtMalsp.Enabled = true;
            txtTenlsp.Enabled = true;
        }
    }
}