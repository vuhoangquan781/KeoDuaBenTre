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

namespace QL_KeoDua_UngDung.GUI
{
    public partial class FormLogin : DevExpress.XtraEditors.XtraForm
    {
        THANHVIENBUS tvBus = new THANHVIENBUS();
        public FormLogin()
        {
            InitializeComponent();
        }
        private void InitializeComponent(FormLogin formLOGIN, object _flg, string v, object _tdn)
        {
            throw new NotImplementedException();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (tvBus.DangNhap(txt_TK.Text, txt_MK.Text) == true)
            {
                FormGiaoDien frmMain = new FormGiaoDien(this, txt_TK.Text);
                this.Hide();
                frmMain.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lb_quenmk_Click(object sender, EventArgs e)
        {
            FormQuenMK qmk = new FormQuenMK();
            this.Hide();
            qmk.Show();
        }
    }
}