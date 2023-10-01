using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Insta_Mart.Models;

namespace Insta_Mart.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        InstaMartDBEntities db = new InstaMartDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Shop()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Cart()
        {
        return View();
        }

        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

       [HttpPost]
        public ActionResult Contact(contact Reg, string cp1, string hd1)
        {
            try {
                if (hd1 == cp1)
                {
                    db.contacts.Add(Reg);
                    db.SaveChanges();
                    Response.Write("<script>alert('massage sent Successfully !')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Invalid Captcha Code !')</script>");
                }
            }

            catch(Exception ex)
            {
             Response.Write("<script>alert('Sorry Please Try Again Later !')</script>");
            }

            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(signUp rg)
        {
            try
            {
                db.SaveChanges();
                db.signUps.Add(rg);
                Response.Write("<script>window.location.href='/Home/Successfull'</script>");

            }

            catch(Exception ex)
            {
                Response.Write("<script>alert('Please Again Later !!');window.location.href='/Home/Registration'</script>");
            }
            return View();
        }

        public ActionResult Successfull()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

       [HttpPost]
        public ActionResult Login(signIn lg)
        {
            try
            { 
            var res=db.signIns.Where(x=> x.email==lg.email && x.password==lg.password).SingleOrDefault();
                if(res.email==lg.email && res.password==lg.password)
                {
                    Session["aid"] = res.email;
                Response.Write("<script>alert('Welcome to Admin Zone');window.location.href='/Admin/Index'</script>");
                }

                else
                    {
                Response.Write("<script>alert('Invalid User Id Or Password')</script>");
                }
            
            }

            catch(Exception ex)
            {
            
             Response.Write("<script>alert('Invalid User Id Or Password')</script>");
            }
            return View();
        }
    }
}
