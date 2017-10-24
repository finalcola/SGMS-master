using hubu.sgms.DAL;
using hubu.sgms.DAL.Impl;
using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.BLL.Impl
{
    public class TeacherServiceImpl : ITeacherService
    {
        ITeacherDAL teacherDAL = new TeacherDALImpl();

        public IList<Teacher_course> SelectAllCourse(string department, string major)
        {
            return teacherDAL.SelectAllCourse(department,major);
        }
    }
}
