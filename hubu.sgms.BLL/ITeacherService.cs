using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.BLL
{
    public interface ITeacherService
    {
        /// <summary>
        /// 查询所有的课程信息
        /// </summary>
        /// <param name="department"></param>
        /// <param name="major"></param>
        /// <returns></returns>
        IList<Teacher_course> SelectAllCourse(string department, string major);
    }
}
