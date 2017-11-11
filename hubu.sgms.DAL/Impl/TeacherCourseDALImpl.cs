using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hubu.sgms.Model;
using System.Data;
using hubu.sgms.Utils;
using System.Data.SqlClient;

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

        public IList<Teacher_course> SelectCourseList(string courseType, string collegeId)
        {
            string collegeSql = " ";
            if (collegeId != null && !"".Equals(collegeId))
            {
                collegeSql = " college_id='" + collegeId + "' and ";
            }
            string sql = "select * from Teacher_course where "+collegeSql+" course_id in (select course_id from Course where course_type=@courseType)";
            SqlParameter[] pars = {
                new SqlParameter("@courseType",courseType)
            };
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, pars);
            IList<Teacher_course> courseList = new List<Teacher_course>();
            foreach(DataRow row in dataTable.Rows)
            {
                Teacher_course course = new Teacher_course();
                BeanUils.SetStringValues(course, row);
                if (row["status"] != null)
                {
                    course.status = Convert.ToInt32(row["status"]);
                }
                courseList.Add(course);
            }

            return courseList;
        }
    }
}
