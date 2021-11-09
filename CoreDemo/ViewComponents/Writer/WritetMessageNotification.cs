using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{
    public class WritetMessageNotification : ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EfMessageRepository());
        public IViewComponentResult Invoke()
        {
            string p;
            p = "samirhueynli2803@gmail.com";
            var value = messageManager.GetInboxListByWriter(p);
            return View(value);
        }
    }
}
