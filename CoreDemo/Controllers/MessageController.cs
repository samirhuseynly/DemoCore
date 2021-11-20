using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager message2Manager = new Message2Manager(new EfMessage2Repository());
        [AllowAnonymous]
        public IActionResult Inbox()
        {
            int id = 1;
            var value = message2Manager.GetInboxListByWriter(id);
            return View(value);
        }

        public IActionResult MessageDetails(int id)
        {
            var value = message2Manager.TGetById(id);
            return View(value);
        }
    }
}
