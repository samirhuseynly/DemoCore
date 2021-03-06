using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context context = new Context();
            var userMail = User.Identity.Name;
            var writerID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.v1 = context.Blogs.Count().ToString();
            ViewBag.v2 = context.Blogs.Where(x => x.WriterID == writerID).Count();
            ViewBag.v3 = context.Categories.Count().ToString();
            return View();
        }
    }
}
