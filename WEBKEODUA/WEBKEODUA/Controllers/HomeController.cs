using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using WEBKEODUA.Models;
using System.Configuration;
using System.Net;

namespace WEBKEODUA.Controllers
{
    public class HomeController : Controller
    {
        QL_KEODUA_WEBEntities4 objModel = new QL_KEODUA_WEBEntities4();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Dangky()
        {
            return View();
        }

        //create a string MD5
        //public static string GetMD5(string str)
        //{
        //    MD5 md5 = new MD5CryptoServiceProvider();
        //    byte[] fromData = Encoding.UTF8.GetBytes(str);
        //    byte[] targetData = md5.ComputeHash(fromData);
        //    string byte2String = null;

        //    for (int i = 0; i < targetData.Length; i++)
        //    {
        //        byte2String += targetData[i].ToString("x2");

        //    }
        //    return byte2String;
        //}


        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Dangky(KHACHHANG _user)
        {
            if (ModelState.IsValid)
            {
                var check = objModel.KHACHHANGs.FirstOrDefault(s => s.SDT == _user.SDT);
                if (check == null)
                {

                    objModel.Configuration.ValidateOnSaveEnabled = false;
                    objModel.KHACHHANGs.Add(_user);
                    objModel.SaveChanges();

                    return RedirectToAction("Login");




                    //if (ModelState.IsValid)
                    //{
                    //    var check = objModel.KHACHHANGs.FirstOrDefault(s => s.SDT == _user.SDT);
                    //    if (check == null)
                    //    {
                    //        //_user.Password = GetMD5(_user.Password);
                    //        //_user.NGHENGHIEP = _user.NGHENGHIEP;
                    //        //_user.NGAYSINH= _user.NGAYSINH;
                    //        objModel.Configuration.ValidateOnSaveEnabled = false;
                    //        objModel.KHACHHANGs.Add(_user);
                    //        objModel.SaveChanges();
                    //        return RedirectToAction("Index");
                    //    }
                    //    else
                    //    {
                    //        ViewBag.error = "SDT already exists";
                    //        return View();
                    //    }
                }
                else
                {
                    ViewBag.error = "SDT đã tồn tại";
                    return View();
                }
               
            }
            return View();
        }

        public ActionResult Login()
        {
            //if (!Session["UserAdmin"].Equals(""))
            //{
            //    return RedirectToAction("Index", "Login");
            //}
            //ViewBag.error = "";

            return View();
        }

        [HttpPost]


        //public ActionResult Login(KHACHHANG kh, FormCollection f)
        //{
        //    var taikhoan = f["SDT"];
        //    var matkhau = f["NGAYSINH"];
        //    if (string.IsNullOrEmpty(taikhoan))
        //    {
        //        ViewData["Loi6"] = "Tài khoản không được bỏ trống";
        //    }
        //    if (string.IsNullOrEmpty(matkhau))
        //    {
        //        ViewData["Loi7"] = "Vui lòng nhập mật khẩu";
        //    }
        //    if (taikhoan != kh.SDT && matkhau != kh.NGAYSINH)
        //    {
        //        ViewData["Loi8"] = "Tài khoản hoặc mật khẩu đã sai!";

        //    }
        //    if (taikhoan == kh.SDT && matkhau == kh.NGAYSINH)
        //    {
        //        kh = objModel.KHACHHANGs.SingleOrDefault(c => c.SDT == taikhoan && c.NGAYSINH == matkhau);
        //        if (kh != null)
        //        {
        //            Session["tk"] = kh;
        //            return RedirectToAction("SanPhamPartial", "SanPham");

        //        }
        //        else
        //        {
        //            ViewData["Loi9"] = "Sai tên đăng nhập hoạc mật khẩu, vui lòng đăng nhập lại";
        //        }

        //    }
        //    return View();

        //}

        public ActionResult Login(FormCollection f)
        {

            string error = "";
            string username = f["Email"];
            string pass = f["Password"];

            var check = objModel.KHACHHANGs.Where(m => (m.SDT.Equals(username))).FirstOrDefault();

            if (check == null)
            {
                error = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            else
            {
                if (check.NGAYSINH.Equals(pass))
                {
                    //Session["UserAdmin"] = check.Email;
                    //Session["idUser"] = check.idUser;
                    //Session["Lastname"] = check.LastName;
                    Session["TENKHACH"] = check.TENKHACH;
                    return RedirectToAction("Index", "SanPham");
                }
                else
                {
                    error = ("Tên đăng nhập hoặc mật khẩu không đúng");
                }
            }
            error = username + pass;
            ViewBag.error = error;
            return View();

        }


        public ActionResult Logout()

        {
            Session["UserAdmin"] = "";
            Session["idUser"] = "";
            Session["Lastname"] = "";
            Session["FistName"] = "";

            return RedirectToAction("Login", "Home");
        }





        //public ActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(string SDT, string Tenkh)
        //{
        //    if (ModelState.IsValid)
        //    {              
        //        var f_password = Tenkh; /* GetMD5(Tenkh);*/
        //        var data = objModel.KHACHHANGs.Where(s => s.SDT.Equals(SDT) && s.TENKHACH.Equals(f_password)).ToList();
        //        if (data.Count() > 0)
        //        {
        //            //add session
        //            Session["FullName"] = data.FirstOrDefault().TENKHACH;
        //            Session["SDT"] = data.FirstOrDefault().SDT;
        //            Session["MaKH"] = data.FirstOrDefault().MAKHACH;
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            ViewBag.error = "Login failed";
        //            return RedirectToAction("Login");
        //        }
        //    }
        //    return View();
        //}


        ////Logout
        //public ActionResult Logout()
        //{
        //    Session.Clear();//remove session
        //    return RedirectToAction("Login");
        //}
        // GET: Mail



        public ActionResult LienHe()
        {
            return View();
        }



        /// <summary>
        /// //
        /// </summary>
        /// <returns></returns>


        public ActionResult MailIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Mail(FormCollection col)
        {
            var Receiver = col["form"];
            var to = col["to"];
            var Subject = col["Subject"];
            var Body = col["body"];
            //var Receiver = Request.Form["Receiver"];
            //var Subject = Request.Form["Subject"];
            //string Body = Request.Form["Body"];
            var Email = ConfigurationManager.AppSettings["Email"].ToString();
            MailMessage obj = new MailMessage(Email, Receiver);
            obj.Subject = Subject;
            obj.Body = Body;
            obj.IsBodyHtml = true;

            MailAddress bcc = new MailAddress("crystallvhq@gmail.com");
            obj.Bcc.Add(bcc);
            //attach file
            HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength > 0)
            {
                string fileName = System.IO.Path.GetFileName(file.FileName);
                obj.Attachments.Add(new Attachment(file.InputStream, fileName));
            }

            using (SmtpClient smtp = new SmtpClient())
            {
                var Password = ConfigurationManager.AppSettings["PasswordEmail"].ToString();

                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(Email, Password);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;//465

                smtp.Send(obj);
                ViewBag.Message = "Email sent.";

                try
                {
                    smtp.Send(obj);
                    ViewBag.Message = "Sent Email";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Err:" + ex.ToString();

                }
            }
            return View();
        }
    }
}