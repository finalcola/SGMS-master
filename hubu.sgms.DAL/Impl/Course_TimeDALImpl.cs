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
    public class Course_TimeDALImpl:ICourse_TimeDAL
    {
        public IList<Course_Time> SelCourseTimeByItems(string ClassroomId, string Weekday,string TeacherId, string ClassId)
        {
            string sql = "select time_id ,classtime from course_time where weekday=@weekday and time_id not in (select  time_id from arrange_course where classroom_id=@classroomid) and time_id not in (select time_id from Arrange_course where teacher_course_id in (select teacher_course_id from Teacher_course where teacher_id=@teacherid or class_id=@classid))";
            SqlParameter[] pars = {
                new SqlParameter("@classroomid",ClassroomId),
                new SqlParameter("@weekday",Weekday),
                new SqlParameter("@classid",ClassId),
                new SqlParameter("@teacherid",TeacherId)

             };
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, pars);

            IList<Course_Time> Course_TimeList = new List<Course_Time>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Course_Time ct = new Course_Time();
                ct.time_id = dataTable.Rows[i]["time_id"].ToString();
                ct.classtime = dataTable.Rows[i]["classtime"].ToString();
                Course_TimeList.Add(ct);
            }
            return Course_TimeList;
        }
    }
}
