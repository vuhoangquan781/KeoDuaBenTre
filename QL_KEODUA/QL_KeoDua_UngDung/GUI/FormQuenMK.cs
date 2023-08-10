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
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;

namespace QL_KeoDua_UngDung.GUI
{
    public partial class FormQuenMK : DevExpress.XtraEditors.XtraForm
    {
        string randomcode;
        public static string to;
        public FormQuenMK()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string from, pass, messageBody;
            Random rand = new Random();
            randomcode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (textBox1.Text).ToString();
            from = "rongtroi488@gmail.com";
            pass = "9629352123A@";
            messageBody = "Code của bạn là: " + randomcode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Quên Mật Khẩu";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Gửi mã thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (randomcode == (textBox2.Text).ToString())
            {
                to = textBox1.Text;
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=QL_KEODUA;Integrated Security=True");
                    //SqlCommand cmd = new SqlCommand("UPDATE ACCOUNT SET MatKhau=1 where EMAIL='" + textBox1.Text + "'", con);
                    SqlCommand cmd = new SqlCommand("exec quenmk @matkhau=1,@Email='" + textBox1.Text + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Đã Cài Lại Mật Khẩu, Mật Khẩu Mặt Định Của Bạn là 1");
                    FormLogin fm = new FormLogin();
                    this.Hide();
                    fm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Mã không chính xác");
            }
        }
    }
}