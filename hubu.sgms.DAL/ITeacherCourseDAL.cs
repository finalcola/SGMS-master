using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.DAL
{
    public interface ITeacherCourseDAL
    {
        /// <summary>
        /// 通过id查询选课教师选课记录
        /// </summary>
        /// <param name="id">教师选课表的主键id</param>
        /// <returns></returns>
        Teacher_course SelectById(string id);

        IList<Teacher_course> SelectCourseList(string courseType, string collegeId);
    }
}
