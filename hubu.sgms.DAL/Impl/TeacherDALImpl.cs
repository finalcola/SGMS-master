using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.DAL.Impl
{
    public class TeacherDALImpl : ITeacherDAL
    {
        public IList<Teacher_course> SelectAllCourse(string department, string major)
        {
            string sql = "select * from Teacher_course where 1=1";
            SqlParameter[] pars = new SqlParameter[2];
            int i = 0;

            if(department != null && department != "")
            {          
                sql += " and department like '%@department%'";
                pars[i++] = new SqlParameter("@department", department);
            }
            if (major != null && major != "")
            {
                sql += " and major like '%@major%'";
                pars[i++] = new SqlParameter("@major", major);
            }

            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, pars);
            IList<Teacher_course> CourseList = new List<Teacher_course>();
            foreach(DataRow dataRow in dataTable.Rows)
            {
                Teacher_course course = new Teacher_course {
                    teacher_course_id = dataRow["teacher_course_id"].ToString(),
                    course_id = dataRow["course_id"].ToString(),
                    course_name = dataRow["course_name"].ToString(),
                    teacher_id = dataRow["teacher_id"].ToString(),
                    teacher_name = dataRow["teacher_name"].ToString(),
                    _class = dataRow["_class"].ToString(),
                    class_id = dataRow["class_id"].ToString(),
                    grade = dataRow["grade"].ToString(),
                    department = dataRow["department"].ToString(),
                    college_id = dataRow["college_id"].ToString(),
                    major = dataRow["major"].ToString(),
                    major_id = dataRow["major_id"].ToString(),
                    course_credit = Convert.ToDecimal(dataRow["course_credit"]),
                    classroom_id = dataRow["classroom_id"].ToString(),
                    status = Convert.ToInt32(dataRow["status"]),
                    yuliu1 = dataRow["yuliu1"].ToString(),
                    yuliu2 = dataRow["yuliu2"].ToString()

                };
                CourseList.Add(course);
            }
            return CourseList;
        }

        public IList<Course_choosing> SelectAllStudentCourse(string department, string major)
        {
            throw new NotImplementedException();
        }
    }
}
