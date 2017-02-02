using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetPersonList()
        {
            using (PersonEntities dataContext = new PersonEntities())
            {

                var employeeList = dataContext.PersonInfoes.ToList();
                return Json(employeeList, JsonRequestBehavior.AllowGet);
            }
        }
        public string AddEmployee(PersonInfo Emp)
        {
            if (Emp != null)
            {
                using (PersonEntities dataContext = new PersonEntities())
                {
                    dataContext.PersonInfoes.Add(Emp);
                    dataContext.SaveChanges();
                    return "Employee Updated";
                }
            }
            else
            {
                return "Invalid Employee";
            }
        }
        public JsonResult GetPersonByID(string id)
        {
            using (PersonEntities dataContext = new PersonEntities())
            {
                int no = Convert.ToInt32(id);
                var employeeList = dataContext.PersonInfoes.Find(no);
                return Json(employeeList, JsonRequestBehavior.AllowGet);
            }
        }

    }
}