using DXApplication2.BUS;
using DXApplication2.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication2
{
    public partial class FormDoiMK : Form
    {
        DoiMatKhau_BUS mkBus = new DoiMatKhau_BUS();
        private string tdn;
        public FormDoiMK(string _tdn)
        {
            InitializeComponent();
            tdn = _tdn; 
        }

        private void btn_CN_Click(object sender, EventArgs e)
        {
            lb_KhongKhop.Visible = false;
            lb_sai.Visible = false;
            lb_ThanhCong.Visible = false;
            if (txt_MKM.Text != txt_NL.Text)
            {
                lb_KhongKhop.Visible = true;
                return;
            }

            if (mkBus.CheckExist(tdn, txt_MKC.Text) == true)
            {
                try
                {
                    ThanhVien_DTO _tv = new ThanhVien_DTO();
                    _tv.TenDangNhap = tdn;
                    _tv.MatKhau = txt_MKM.Text;

                    mkBus.DoiMatKhau(_tv);
                    //lb_ThanhCong.Visible = true;

                    MessageBox.Show("Đổi Thành Công");

                    FormLOGIN frmlg = new FormLOGIN();
                    this.Hide();
                    frmlg.ShowDialog();
                }
                catch
                { 
                
                }
            }
            else
            {
                lb_sai.Visible = true;

            }

        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
