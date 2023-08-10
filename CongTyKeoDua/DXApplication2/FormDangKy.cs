using DXApplication2.BUS;
using DXApplication2.DAO;
using DXApplication2.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace DXApplication2
{
    public partial class FormDangKy : Form
    {
        AccountBUS accbus = new AccountBUS();
        AccountDAO acc = new AccountDAO();
        public FormDangKy()
        {
            InitializeComponent();
        }
        public bool KTDK(string user)
        {
            try
            {
                acc.ketnoiCN.Open();
                string CauLenh = "DECLARE @return_value int EXEC	@return_value = [dbo].[sp_KiemTraTenDangNhapTonTai] "
                    + "@tendangnhap = N'" + user + "' SELECT	'Return Value' = @return_value";
                SqlCommand cmd = new SqlCommand(CauLenh, acc.ketnoiCN);
                object value = cmd.ExecuteScalar();
                acc.ketnoiCN.Close();
                int kq = int.Parse(value.ToString());
                if (kq == 1)
                {
                    return true;
                }
                else
                    return false;
            }
            catch { return false; }
        }
        private void FormDangKy_Load(object sender, EventArgs e)
        {
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if((txtPass.Text.ToString().Trim().ToLower() == txtXacNhanMK.Text.ToString().Trim().ToLower())==true)
                {    
                    if ((txtTDN.Text != "" && txtPass.Text != "" && txtXacNhanMK.Text != "" && txtSDT.Text != "") == true)
                    {
                        if ((KTDK(txtTDN.Text)) == true)
                        {
                            ACCOUNT acc = new ACCOUNT();
                            acc.tendangnhap = txtTDN.Text.ToString();
                            acc.matkhau = (txtPass.Text.ToString());
                            acc.sdt = txtSDT.Text.ToString();
                            accbus.Dangky(acc);
                            MessageBox.Show("Đăng Ký Thành Công!");
                            this.Dispose();
                            FormLOGIN fm = new FormLOGIN();
                            fm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Tên đăng nhập tồn tại!");
                        }
                    }
                    else
                    {
                    MessageBox.Show("Không được để trống!");
                    }
                }
                else { MessageBox.Show("Mật khẩu không chính xác!"); }
            }
            catch (Exception ex) { MessageBox.Show("Đăng Ký Thất Bại!"); }
        }

    }
}

