using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL_Library
{
    public class ClassData
    {
        public int Classid { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

    }
    public class Studentsdata
    {
       public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
    }
    public class Subjectsdata
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

    }
}
