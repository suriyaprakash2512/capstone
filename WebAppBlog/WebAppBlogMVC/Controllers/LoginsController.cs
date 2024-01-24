using BlogLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppBlogMVC.Models;

namespace WebAppBlogMVC.Controllers
{
    public class LoginsController : Controller
    {
       
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Login());
        }
        [HttpPost]
        public ActionResult Index(LogIn sign)
        {
            if (ModelState.IsValid)
            {
                if ((sign.EmailId == "surya@gmail.com") && (sign.Password == "surya@25"))
                {

                    Session["UserId"] = Guid.NewGuid();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Either User Name or Password Incorrect!!!");
                    return View(sign);

                }
            }
            else
            { return View(sign); }

        }
    }
}
