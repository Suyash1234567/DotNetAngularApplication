using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetAngularApplication.Models;

namespace DotNetAngularApplication.Data
{
    public class StudentData
    {
        public static List<StudentViewModel> GetStudent()
        {
            return new List<StudentViewModel>
            {
                 new StudentViewModel
                {
                    StudentId=1,
                    StudentName="Ram",
                    StudentClass=11,
                    StudentAge=16
                },
                new StudentViewModel
                {
                    StudentId=2,
                    StudentName="Shyam",
                    StudentClass=10,
                    StudentAge=15
                },
                new StudentViewModel
                {
                    StudentId=3,
                    StudentName="Balram",
                    StudentClass=9,
                    StudentAge=14
                },
                new StudentViewModel
                {
                    StudentId=4,
                    StudentName="Ghanshyam",
                    StudentClass=8,
                    StudentAge=13
                },
                new StudentViewModel
                {
                    StudentId=5,
                    StudentName="Ravan",
                    StudentClass=7,
                    StudentAge=12
                },
                 new StudentViewModel
                {
                    StudentId=6,
                    StudentName="Aayaram",
                    StudentClass=6,
                    StudentAge=11
                },
                  new StudentViewModel
                {
                    StudentId=7,
                    StudentName="Gayaram",
                    StudentClass=5,
                    StudentAge=10
                }
            };
        }

        public static List<StudentViewModel> GetStudentByName(string name)
        {
            List<StudentViewModel> studentList = new List<StudentViewModel>();
            studentList = (from s in GetStudent()
                           where s.StudentName.ToLower().Contains(name.ToLower())
                           select s).ToList();
            return studentList;

        }

        public static List<StudentViewModel> GetStudentById(int id)
        {
            List<StudentViewModel> studentList = new List<StudentViewModel>();
            studentList = (from s in GetStudent()
                           where s.StudentId == id
                           select s).ToList();
            return studentList;

            //}
        }

        public static List<StudentViewModel> GetStudentByAge(int age)
        {
            List<StudentViewModel> studentList = new List<StudentViewModel>();
            studentList = (from s in GetStudent()
                           where s.StudentAge == age
                           select s).ToList();
            return studentList;

            //}
        }

        public static List<StudentViewModel> GetStudentByClass(int className)
        {
            List<StudentViewModel> studentList = new List<StudentViewModel>();
            studentList = (from s in GetStudent()
                           where s.StudentClass == className
                           select s).ToList();
            return studentList;

            //}
        }
    }
}
