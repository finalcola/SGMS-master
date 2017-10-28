using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hubu.sgms.Model;
using hubu.sgms.DAL;
using hubu.sgms.DAL.Impl;

namespace hubu.sgms.BLL.Impl
{
    public class StudentServiceImpl : IStudentService
    {
        private static IStudentService studentService = new StudentServiceImpl();

        public static IStudentService Instance()
        {
            return studentService;
        }

        private IStudengDAL studentDAL = StudentDALImpl.Instance();
        private ICollegeDAL collegeDAL = CollegeDALImpl.Instance();

        public Student GetStudentById(string id)
        {
            Student student = studentDAL.SelectStudentById(id);
            if (student != null)
            {
                College college = collegeDAL.SelectById(student.college_id);
                student.College = college;
            }

            return student;
        }
    }
}
