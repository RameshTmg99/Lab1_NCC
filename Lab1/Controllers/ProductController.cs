using Lab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1.Controllers
{
    public class ProductController : Controller
    {
        DataContext dbcontext = new DataContext();
        // GET: Product
        public ActionResult Index()
        {
            var data = dbcontext.products.ToList();
            return View(data);
        }
    }
}