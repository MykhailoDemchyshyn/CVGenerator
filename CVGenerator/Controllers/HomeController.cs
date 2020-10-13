using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVGenerator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        [HttpPost]
        public ActionResult Resume(HttpPostedFileBase upload, string firstName, string lastName, string dateOfBirth, string sex, string workExperience, string typeEducation, string university, bool csharp,bool js,bool html, string[] hobies)
        {
            ViewBag.FirstName = firstName;
            ViewBag.LastName = lastName;
            ViewBag.DateOfBirth = dateOfBirth;
            ViewBag.Sex = sex;
            ViewBag.WorkExperience = workExperience;
            ViewBag.TypeEducation = typeEducation;
            ViewBag.University = university;
            if (csharp) ViewBag.Skills += "c#" + "; ";
            if (js) ViewBag.Skills += nameof(js) + "; ";
            if (html) ViewBag.Skills += nameof(html) + "; ";
            if (upload != null)
            {
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                upload.SaveAs(Server.MapPath("~/Home/Files/" + fileName));
                ViewBag.Photo = "./Files/" + fileName;
            }
            foreach(string elem in hobies)
            {
                ViewBag.Hobies += elem + "; ";
            }
            return View();
        }
    }
}