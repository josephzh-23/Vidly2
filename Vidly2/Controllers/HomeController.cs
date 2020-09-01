using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;

namespace Vidly2.Controllers
{
    public class HomeController : Controller
    {

        private MyDBContext db;

        public HomeController()
        {
            db = new MyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CheckEmail()
        {

            return View();

        }


        [HttpPost]
        public ActionResult CheckEmail(Student student)
        {

            //Building a query string
            //store in name and pass it to abouts page



            /*     NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
                 queryString.Add(student.Guid, "value1");
                 queryString.Add("key2", "value2");*/

            string num = "33";
            Uri url = new Uri("https://localhost:44393/home/checkemail").
                  AddQuery("guid", num).
                  AddQuery("pageSize", "200");


            ViewBag.uri = url;
            student.Name = url.ToString();


            //Here we extract the guid here 

            string query_string = string.Empty;

           query_string = HttpUtility.ParseQueryString(url.Query).Get("guid");


            student.School = query_string;    // this displayed 


            //Checking the guid 
            var students = db.Students.SingleOrDefault(c => c.Id == student.Id);



            //Extract the guid from a url string?


            if (students != null)
            {


            }
            //Validation + send email if valid 

            //Send email with the string of guid attached 

            return View("About", student);



        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        // A method for grabbing part of query string 
      

    }
}