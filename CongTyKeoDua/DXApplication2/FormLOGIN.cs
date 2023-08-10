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
using DevExpress.XtraReports.Data;
using DXApplication2.BUS;

namespace DXApplication2
{
    public partial class FormLOGIN : DevExpress.XtraEditors.XtraForm
    {
        ThanhVien_BUS tvBus = new ThanhVien_BUS();
        public FormLOGIN()
        {
            InitializeComponent();
            
        }

        private void InitializeComponent(FormLOGIN formLOGIN, object _flg, string v, object _tdn)
        {
            throw new NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_TK_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_DN_Click(object sender, EventArgs e)
        {
            if (tvBus.DangNhap(txt_TK.Text, txt_MK.Text) == true)
            {
                FormMain frmMain = new FormMain(this, txt_TK.Text);
                this.Hide();
                frmMain.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
            }
        }

        private void FormLOGIN_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lb_quenmk_Click(object sender, EventArgs e)
        {
            FormQuenMK qmk = new FormQuenMK();
            this.Hide();
            qmk.Show();
        }

        private void lb_DK_Click(object sender, EventArgs e)
        {
            FormDangKy frmDK = new FormDangKy();
            this.Hide();
            frmDK.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (tvBus.DangNhap(txt_TK.Text, txt_MK.Text) == true)
            {
                FormMain frmMain = new FormMain(this, txt_TK.Text);
                this.Hide();
                frmMain.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}