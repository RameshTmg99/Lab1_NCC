using Lab1.Models;
using System.Collections.Generic;
using System.Linq;
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
        [HttpGet]
        public ActionResult Create()
        {
            //var data = dbcontext.products.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            //var data = dbcontext.products.ToList();
           List<object> parameter = new List<object>();
            parameter.Add(p.Name);
            parameter.Add(p.SerialNumber);
            parameter.Add(p.Company);
            object[] parameterArray = parameter.ToArray();
            int output = dbcontext.Database.ExecuteSqlCommand("INSERT INTO products(name,serialNumber,company)VALUES(@p0,@p1,@p2)", parameterArray);
            if(output>0)
            {
                ViewBag.success = "Data added Successfully";
            }
            else
            {
                ViewBag.error = "Data not added !!";
            }
            return View();
        }
        public ActionResult details(int id)
        {
            var data = dbcontext.products.SqlQuery("SELECT * FROM products where id=@p0", id).SingleOrDefault();
            return View(data);       
        }

        public ActionResult delete(int id)
        {
            var data = dbcontext.Database.ExecuteSqlCommand("DELETE FROM products where id=@p0", id);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult edit(int id)
        {
            var data = dbcontext.products.SqlQuery("SELECT * FROM products where id = @p0", id).SingleOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult edit(Product p)
        {
            List<object> parameter = new List<object>();
            parameter.Add(p.Name);
            parameter.Add(p.SerialNumber);
            parameter.Add(p.Company);
            parameter.Add(p.Id);
            object[] parameterArray = parameter.ToArray();
            int output = dbcontext.Database.ExecuteSqlCommand("UPDATE products set name=@p0,serialNumber=@p1,company=@p2 where id=@p3", parameterArray);
            if (output > 0)
            {
                ViewBag.success = "Data Updated Successfully";
            }
            else
            {
                ViewBag.error = "Data not Updated !!";
            }
            return RedirectToAction("index"); ;

        }
    }
}