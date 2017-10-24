using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.DAL
{
    public interface ITeacherDAL
    {
        /// <summary>
        /// 查询所有的课程信息
        /// </summary>
        /// <param name="department"></param>
        /// <param name="major"></param>
        /// <returns></returns>
        IList<Teacher_course> SelectAllCourse(string department, string major);

        /// <summary>
        /// 查询所有选课信息   
        /// </summary>
        /// <param name="department"></param>
        /// <param name="major"></param>
        /// <returns></returns>
        IList<Course_choosing> SelectAllStudentCourse(string department, string major);
    }
}
