using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Insta_Mart.Models;

namespace Insta_Mart.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        InstaMartDBEntities db = new InstaMartDBEntities();
        public ActionResult Index()
        {

            if(Session["aid"] !=null)
            {
            }
            else
            {
                Response.Write("<script>alert('Login First then you can enter Admin Zone');window.location.href='/Home/Login'</script>");

            }
            return View();
        }

        public ActionResult ContactMgmt()
        {

            return View(db.contacts.ToList());
        }
        public void Logout()
        {
            Session.Abandon();
            Response.Write("<script>alert('Logout');window.location.href='/Home/Login'</script>");
        }

        public ActionResult ChangePassword()
        {

            return View();
        }
        [HttpPost]
        public void ChangePassword(string oldpass, string newpass, string confirmpass)
        {
            try
            {
                if (newpass == confirmpass)
                {
                    signIn lg = db.signIns.Where(x => x.password == oldpass).SingleOrDefault();
                    lg.password = confirmpass;
                    db.SaveChanges();
                    Response.Write("<script>alert('Your Password Changed Successfully');window.location.href='/Home/Login'</script>");

                }
                else
                {
                    Response.Write("<script>alert('Your Password Does Not Match');window.location.href='/Home/Login'</script>");
                }

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('We cannot Change Your Password');window.location.href='/Home/Login'</script>");
            
            }
            
        }

    }
}
