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
    public partial class FormChiNhanh : DevExpress.XtraEditors.XtraForm
    {
        CHINHANHBUS chinhanhbus = new CHINHANHBUS();
        connect cn = new connect();
        public FormChiNhanh()
        {
            InitializeComponent();
        }

        private void FormChiNhanh_Load(object sender, EventArgs e)
        {
            dvChiNhanh.DataSource = chinhanhbus.getdata();
        }

        private void dvChiNhanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dvChiNhanh.Rows[e.RowIndex];
                txtMaCN.Text = row.Cells[0].Value.ToString();
                txtTenCN.Text = row.Cells[1].Value.ToString();
                txtMaCN.Enabled = false;
                txtTenCN.Enabled = false;
                //txtMakv.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                CHINHANH cn = new CHINHANH();
                cn.MACN1 = txtMaCN.Text.ToString();
                cn.TENCN1 = txtTenCN.Text.ToString();
                chinhanhbus.InsertCHINHANH(cn);
                MessageBox.Show("Thêm Thành Công!");
                dvChiNhanh.DataSource = chinhanhbus.getdata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm Thất Bại!");
            }
            txtMaCN.Clear();
            txtTenCN.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaCN.Text.ToString() != "")
            {
                try
                {
                    CHINHANH cn = new CHINHANH();
                    cn.MACN1 = txtMaCN.Text.ToString();

                    chinhanhbus.DeleteCHINHANH(cn.MACN1);

                    MessageBox.Show("Xoá Thành Công!");
                    dvChiNhanh.DataSource = chinhanhbus.getdata();
                }
                catch (Exception ex) { MessageBox.Show("Xoá Thất Bại!"); }
            }
            txtMaCN.Clear();
            txtTenCN.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaCN.Enabled = false;
            txtTenCN.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaCN.Clear();
            txtTenCN.Clear();
            txtMaCN.Enabled = true;
            txtTenCN.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CHINHANH cn = new CHINHANH();
                cn.MACN1 = txtMaCN.Text.ToString();
                cn.TENCN1 = txtTenCN.Text.ToString();
                chinhanhbus.UpdateCHINHANH(cn, cn.MACN1);
                MessageBox.Show("Lưu Thành Công!");
                dvChiNhanh.DataSource = chinhanhbus.getdata();
            }
            catch (Exception ex) { MessageBox.Show("Lưu Thất Bại!"); }
            txtMaCN.Clear();
            txtTenCN.Clear();
            txtMaCN.Enabled = true;
        }
    }
}