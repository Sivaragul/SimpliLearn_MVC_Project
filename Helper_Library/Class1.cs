using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL_Library;
using DAL_Library;


namespace Helper_Library
{
    public class ClassMethod
    {
        public void AddClass(ClassData s)
        {
            SchoolEntities context = new SchoolEntities();
            Class s1 = new Class();
            s1.ClassId = s.Classid;
            s1.StudId = s.StudentId;
            s1.SubId = s.SubjectId;
            context.Classes.Add(s1);
            context.SaveChanges();


        }
        public bool RemoveClass(int id)
        {
            SchoolEntities context = new SchoolEntities();
            List<Class> m1 = context.Classes.ToList();
            Class s2 = m1.Find(m => m.ClassId == id);
            if (s2 != null)
            {
                context.Classes.Remove(s2);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public void updateClass(ClassData s)
        {
            SchoolEntities context = new SchoolEntities();
            List<Class> m1 = context.Classes.ToList();
            Class s2 = m1.Find(m => m.ClassId == s.Classid);
            s2.ClassId = s.Classid;
            s2.StudId = s.StudentId;
            s2.SubId = s.SubjectId;
            context.SaveChanges();
        }
        public List<ClassData> classdatas()
        {
            SchoolEntities context = new SchoolEntities();
            List<ClassData> s = new List<ClassData>();
            List<Class> m1 = context.Classes.ToList();
            foreach (var item in m1)
            {
                s.Add(new ClassData
                {
                    Classid = item.ClassId,
                    StudentId = (int)item.StudId,
                    SubjectId = (int)item.SubId,
                });
            }
            return s;
        }

    }
    public class Studentmethod
    {
        public void AddStudent(Studentsdata s)
        {
            SchoolEntities context = new SchoolEntities();
            Student s1 = new Student();
            s1.StudId= s.StudentId;
            s1.StudName = s.StudentName;
            s1.Age = s.StudentAge;
            context.Students.Add(s1);
            context.SaveChanges();

        }
        public void RemoveStudent(int id)
        {
            SchoolEntities context = new SchoolEntities();
            List<Student> s = context.Students.ToList();
            Student s1 = s.Find(m => m.StudId == id);
            context.Students.Remove(s1);
            context.SaveChanges();
        }
        public void updateStudent(Studentsdata s2)
        {
            SchoolEntities context = new SchoolEntities();
            List<Student> s = context.Students.ToList();
            Student s1 = s.Find(m => m.StudId == s2.StudentId);
            s1.StudId = s2.StudentId;
            s1.StudName = s2.StudentName;
            s1.Age = s2.StudentAge;
            context.SaveChanges();
        }
        public List<Studentsdata> studentdatas()
        {
            SchoolEntities context = new SchoolEntities();
            List<Studentsdata> s = new List<Studentsdata>();
            List<Student> s1 = context.Students.ToList();
            foreach (var item in s1)
            {
                s.Add(
                    new Studentsdata
                    {
                        StudentId = item.StudId,
                        StudentName = item.StudName,
                        StudentAge = (int)item.Age

                    }
                );
            }
            return s;
        }
    }
    public class SubjectMethods
    {
        public void AddSubject(Subjectsdata s)
        {
            SchoolEntities context = new SchoolEntities();
            Subject s1 = new Subject();
            s1.SubId = s.SubjectId;
            s1.SubName = s.SubjectName;
            context.Subjects.Add(s1);
            context.SaveChanges();

        }
        public void RemoveSubject(int id)
        {
            SchoolEntities context = new SchoolEntities();
            List<Subject> s1 = context.Subjects.ToList();
            Subject s2 = s1.Find(m => m.SubId == id);
            context.Subjects.Remove(s2);
            context.SaveChanges();
        }
        public void updatesubject(Subjectsdata s)
        {
            SchoolEntities context = new SchoolEntities();
            List<Subject> s1 = context.Subjects.ToList();
            Subject s2 = s1.Find(m => m.SubId == s.SubjectId);
            s2.SubId = s.SubjectId;
            s2.SubName = s.SubjectName;
            context.SaveChanges();

        }
        public List<Subjectsdata> Subjlist()
        {
            List<Subjectsdata> s1 = new List<Subjectsdata>();
            SchoolEntities context = new SchoolEntities();
            List<Subject> s = context.Subjects.ToList();
            foreach (var item in s)
            {
                s1.Add(
                    new Subjectsdata
                    {
                        SubjectId = item.SubId,
                        SubjectName = item.SubName
                    
                    });
            }
            return s1;
        }
    }
}
