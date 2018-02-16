using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.Models;

namespace ContosoUniversity.Controllers
{
    public class HomeController : Controller
    {
        //private ActionController db = new ActionController();
        private ApplicationDbContext dbo = new ApplicationDbContext();

        public ActionResult Index()
        {
           
            var usersCelebrations = dbo.Celebrations.Where(uc => uc.User.Email == User.Identity.Name).ToList();
            return View(usersCelebrations.ToList());
            //return View();
        }
    
        
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       

      /*  protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        } */
    }
}