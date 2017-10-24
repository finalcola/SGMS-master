using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hubu.sgms.Model;
using System.Data;
using hubu.sgms.Utils;

namespace hubu.sgms.DAL.Impl
{
    public class TeacherCourseDALImpl : ITeacherCourseDAL
    {

        private TeacherCourseDALImpl() { }

        public static ITeacherCourseDAL teacherCourseDAL = new TeacherCourseDALImpl();

        public static ITeacherCourseDAL Instance()
        {
            return teacherCourseDAL;
        }

        /// <summary>
        /// 根据主键查询所有信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Teacher_course SelectById(string id)
        {
            string sql = "select * from Teacher_course where teacher_course_id='" + id + "'";
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql);
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                Teacher_course teacher_Course = new Teacher_course();
                BeanUils.SetStringValues(teacher_Course, row);
                if (row["course_credit"]!=null)
                {
                    teacher_Course.course_credit = Convert.ToDecimal(row["course_credit"]);
                }
                if (row["status"]!=null)
                {
                    teacher_Course.status = Convert.ToInt32(row["status"]);
                }
                return teacher_Course;
            }
            return null;
        }
    }
}
