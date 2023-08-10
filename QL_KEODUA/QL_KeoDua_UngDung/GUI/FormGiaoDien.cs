using QL_KeoDua_UngDung.GUI;
using QLKeoDua.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QL_KeoDua_UngDung
{
    public partial class FormGiaoDien : DevExpress.XtraEditors.XtraForm
    {
        private FormLogin fLg;
        private string tdn;
        private string tenv;
        public FormGiaoDien()
        {
            InitializeComponent();
        }
        public FormGiaoDien(FormLogin _flg, string _tdn)
        {
            InitializeComponent();
            tdn = _tdn;
            fLg = _flg;
            connect _dt = new connect();
            DataTable dt = _dt.returnquery("select * from ACCOUNT where TenDangNhap = '" + tdn + "'");
            string gt = dt.Rows[0]["Quyen"].ToString();
            if (gt == "0")
            {
                menuStrip1.Visible = true;
            }
            else
            {
                quảnLýSảnPhẩmToolStripMenuItem.Visible = false;
                quảnLýNhânViênToolStripMenuItem.Visible = false;
                quảnLýChiNhánhToolStripMenuItem.Visible = false;
                quảnLýNhàPhânPhốiToolStripMenuItem.Visible = false;
            }
        }

        private void kháchHàngToolStripMenuItem_DoubleClick(object sender, EventArgs e)
        {
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKhachHang kh = new FormKhachHang();
            kh.Show();
        }

        private void nhàPhânPhốiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNhaPP npp = new FormNhaPP();
            npp.Show();
        }

        private void tỉnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTinh t = new FormTinh();
            t.Show();
        }

        private void khuVựcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKhuVuc kv = new FormKhuVuc();
            kv.Show();
        }

        private void sảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormSanPham sp = new FormSanPham();
            sp.Show();
        }

        private void loạiSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLoaiSP lsp = new FormLoaiSP();
            lsp.Show();
        }

        private void đơnĐặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDDH ddh = new FormDDH();
            ddh.Show();
        }

        private void chiTiếtĐơnĐặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCTDDH ctddh = new FormCTDDH();
            ctddh.Show();
        }

        private void xuấtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormXH xh = new FormXH();
            xh.Show();
        }

        private void chiTiếtXuấtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCTXH ctxh = new FormCTXH();
            ctxh.Show();
        }

        private void chiNhánhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChiNhanh cn = new FormChiNhanh();
            cn.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNhanVien nv = new FormNhanVien();
            nv.Show();
        }

        private void tàiKhoảnNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            FormCapQuyen frm = new FormCapQuyen();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            panel4.Controls.Add(frm);
        }

        private void FormGiaoDien_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=localhost;Initial Catalog=QL_KeoDua;Integrated Security=True";
            using (con)
            {
                con.Open();
                string query = "select TenDangNhap from ACCOUNT where TenDangNhap='" + tdn + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                string strUsrNm = Convert.ToString(cmd.ExecuteScalar());
                label2.Text = strUsrNm;
                con.Close();
            }
        }

        private void dMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormDoiMK mk = new FormDoiMK(tdn);
            mk.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormLogin fm = new FormLogin();
            this.Hide();
            fm.ShowDialog();
        }
    }
}
