using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL_Library;
using Helper_Library;
using Microsoft.Ajax.Utilities;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class

        ClassMethod cs = null;
        public ClassController()
        {
            cs = new ClassMethod();
        }
        public List<ClassModel> list1()
        {
            List<ClassModel> c1 = new List<ClassModel>();
            List<ClassData> ds = cs.classdatas();
            foreach (var item in ds)
            {
                ClassModel c = new ClassModel();
                c.Classid = item.Classid;
                c.StudentId = item.StudentId;
                c.SubjectId = item.SubjectId;
                c1.Add(c);
            }
            return c1;
        }
        public ActionResult Index()
        {
            List<ClassModel> s1 = list1();
            return View(s1);
        }

        public ActionResult AddClass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddClass(FormCollection c)
        {
            try
            {
                ClassData c1 = new ClassData();
                c1.Classid = Convert.ToInt32(Request["Classid"]);
                c1.StudentId = Convert.ToInt32(Request["StudentId"]);
                c1.SubjectId = Convert.ToInt32(Request["SubjectId"]);
                cs.AddClass(c1);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }


        }

        public ActionResult EditDetails(int id)
        {
            List<ClassModel> m = list1();
            ClassModel m2 = m.Find(m3 => m3.Classid == id);
            return View(m2);
        }
        [HttpPost]
        public ActionResult EditDetails(int id, FormCollection m3)
        {
            try
            {
                ClassData c2 = new ClassData();
                c2.Classid = Convert.ToInt32(Request["Classid"]);
                c2.StudentId = Convert.ToInt32(Request["StudentId"]);
                c2.SubjectId = Convert.ToInt32(Request["SubjectId"]);
                cs.updateClass(c2);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        public ActionResult Details(int id)
        {
            List<ClassModel> m = list1();
            ClassModel m2 = m.Find(m3 => m3.Classid == id);
            return View(m2);

        }
        public ActionResult Delete(int id)
        {
            try
            {
                cs.RemoveClass(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}