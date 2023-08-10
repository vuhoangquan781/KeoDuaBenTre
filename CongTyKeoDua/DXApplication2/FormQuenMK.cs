using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;

namespace DXApplication2
{
    public partial class FormQuenMK : Form
    {
        public FormQuenMK()
        {
            InitializeComponent();
        }
        string randomcode;
        public static string to;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string from, pass, messageBody;
            Random rand = new Random();
            randomcode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (textBox1.Text).ToString();
            from = "leenedq7@gmail.com";
            pass = "Khanh0212";
            messageBody = "Code của bạn là: " + randomcode;
            message.To.Add(to);
            message.From=new MailAddress(from);
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

        private void simpleButton2_Click(object sender, EventArgs e)
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
                    FormLOGIN fm = new FormLOGIN();
                    this.Hide();
                    fm.ShowDialog();
                }
                catch(Exception ex)
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
