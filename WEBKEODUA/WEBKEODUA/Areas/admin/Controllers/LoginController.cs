using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBKEODUA.Models;
namespace WEBKEODUA.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: admin/Login
        QL_KEODUA_WEBEntities4 db = new QL_KEODUA_WEBEntities4();
        public ActionResult Index()
        {
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

        public ActionResult Login(FormCollection f)
        {

            string error = "";
            string username = f["Email"];
            string pass = f["Password"];

            var check = db.Users.Where(m => m.Email.Equals("quan@gmail") && (m.Email.Equals(username))).FirstOrDefault();

            if (check == null)
            {
                error = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            else
            {
                if (check.Password.Equals(pass))
                {
                    Session["UserAdmin"] = check.Email;
                    Session["idUser"] = check.idUser;
                    Session["Lastname"] = check.LastName;
                    Session["FistName"] = check.FirstName;
                    return RedirectToAction("Index");
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

            return RedirectToAction("Login", "Login");
        }
    }
}