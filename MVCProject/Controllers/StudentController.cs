using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL_Library;
using Helper_Library;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

        Studentmethod cs = null;
        public StudentController()
        {
            cs = new Studentmethod();
        }
        public List<StudentModel> list1()
        {
            List<StudentModel> c1 = new List<StudentModel>();
            List<Studentsdata> ds = cs.studentdatas();
            foreach (var item in ds)
            {
                StudentModel c = new StudentModel();
                c.StudentId = item.StudentId;
                c.StudentName = item.StudentName;
                c.StudentAge = item.StudentAge;
                c1.Add(c);
            }
            return c1;
        }
        public ActionResult Index()
        {
            List<StudentModel> s1 = list1();
            return View(s1);
        }
        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(FormCollection c)
        {
            try
            {
                Studentsdata s1 = new Studentsdata();
                s1.StudentId = Convert.ToInt32(Request["StudentId"]);
                s1.StudentName = Request["StudentName"].ToString();
                s1.StudentAge= Convert.ToInt32(Request["StudentAge"]);
                cs.AddStudent(s1);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        public ActionResult EditDetails(int id)
        {
            List<StudentModel> m = list1();
            StudentModel m2 = m.Find(m3 => m3.StudentId == id);
            return View(m2);
        }
        [HttpPost]
        public ActionResult EditDetails(int id, FormCollection m3)
        {
            try
            {
                Studentsdata s1 = new Studentsdata();
                s1.StudentId = Convert.ToInt32(Request["StudentId"]);
                s1.StudentName = Request["StudentName"].ToString();
                s1.StudentAge= Convert.ToInt32(Request["StudentAge"]);
                cs.updateStudent(s1);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            List<StudentModel> m = list1();
            StudentModel m2 = m.Find(m3 => m3.StudentId == id);
            return View(m2);

        }
        public ActionResult Delete(int id)
        {
            try
            {
                cs.RemoveStudent(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex);
            }

        }


    }
}