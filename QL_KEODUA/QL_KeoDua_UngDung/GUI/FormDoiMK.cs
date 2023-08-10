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
    public partial class FormDoiMK : DevExpress.XtraEditors.XtraForm
    {
        DOIMKBUS mkBus = new DOIMKBUS();
        private string tdn;
        public FormDoiMK(string _tdn)
        {
            InitializeComponent();
            tdn = _tdn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_MKM.Text != txt_NL.Text)
            {
                lbl_KhongKhop.Visible = true;
                return;
            }

            if (mkBus.CheckExist1(tdn, txt_MKC.Text) == true)
            {
                try
                {
                    if (txt_MKM.Text == "" && txt_NL.Text == "")
                    {
                        lbl_KDeTrong1.Visible = true;
                        lbl_KDeTrong2.Visible = true;
                        return;
                    }
                    else
                    {
                        THANHVIEN _tv = new THANHVIEN();
                        _tv.TenDangNhap = tdn;
                        _tv.MatKhau = txt_MKM.Text;

                        mkBus.DoiMatKhau(_tv);
                        //lb_ThanhCong.Visible = true;

                        MessageBox.Show("Đổi Thành Công");

                        FormLogin frmlg = new FormLogin();
                        this.Hide();
                        frmlg.ShowDialog();
                    }
                }
                catch
                {

                }
            }
            else
            {
                lbl_Sai.Visible = true;
            }
        }

        private void FormDoiMK_Load(object sender, EventArgs e)
        {
            lbl_KhongKhop.Visible = false;
            lbl_Sai.Visible = false;
            lb_ThanhCong.Visible = false;
            lbl_KDeTrong1.Visible = false;
            lbl_KDeTrong2.Visible = false;
        }
    }
}