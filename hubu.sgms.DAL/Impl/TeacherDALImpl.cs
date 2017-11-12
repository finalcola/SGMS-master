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
        public IList<Teacher_course> SelectAllCourse(string teacher_id)
        {
            string sql = "select * from Teacher_course where teacher_id = @teacher_id";
            SqlParameter[] pars = { new SqlParameter("@teacher_id", teacher_id) };
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql,pars);
            IList<Teacher_course> CourseList = new List<Teacher_course>();
            foreach(DataRow dataRow in dataTable.Rows)
            {
                Teacher_course course = new Teacher_course {
                    teacher_course_id = dataRow["teacher_course_id"].ToString(),
                    course_id = dataRow["course_id"].ToString(),
                    course_name = dataRow["course_name"].ToString(),
                    teacher_id = dataRow["teacher_id"].ToString(),
                    teacher_name = dataRow["teacher_name"].ToString(),
                    _class = dataRow["class"].ToString(),
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

        public IList<Course_choosing> SelectAllStudentCourse(string courseid)
        {
            string sql = "select * from Course_choosing where course_id = @courseid";
            SqlParameter[] pars = { new SqlParameter("@courseid", courseid) };
            
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, pars);
            IList<Course_choosing> CourseList = new List<Course_choosing>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Course_choosing course = new Course_choosing
                {
                    course_choosing_id = dataRow["course_choosing_id"].ToString(),
                    student_id = dataRow["student_id"].ToString(),
                    student_name = dataRow["student_name"].ToString(),
                    teacher_course_id = dataRow["teacher_course_id"].ToString(),
                    teacher_id = dataRow["teacher_id"].ToString(),
                    teacher_name = dataRow["teacher_name"].ToString(),
                    course_id = dataRow["course_id"].ToString(),
                    course_name = dataRow["course_name"].ToString(),
                    /*usual_grade = Convert.ToDecimal(dataRow["usual_grade"]),
                    test_grade = Convert.ToDecimal(dataRow["test_grade"]),
                    total_grade = Convert.ToDecimal(dataRow["total_grade"]),*/
                    course_credit = Convert.ToDecimal(dataRow["course_credit"]),
                    _class = dataRow["class"].ToString(),
                    status = Convert.ToInt32(dataRow["status"]),
                    //yuliu1 = dataRow["yuliu1"].ToString(),
                    //yuliu2 = dataRow["yuliu2"].ToString(),
                    //yuliu3 = dataRow["yuliu3"].ToString()
                };
                if(dataRow["usual_grade"] != null && dataRow["usual_grade"].ToString() != "")
                {
                    course.usual_grade = Convert.ToDecimal(dataRow["usual_grade"]);
                }
                if (dataRow["test_grade"] != null && dataRow["test_grade"].ToString() != "")
                {
                    course.test_grade = Convert.ToDecimal(dataRow["test_grade"]);
                }
                if (dataRow["total_grade"] != null && dataRow["total_grade"].ToString() != "")
                {
                    course.total_grade = Convert.ToDecimal(dataRow["total_grade"]);
                }
                CourseList.Add(course);
            }
            return CourseList;
        }

        public int InsertStudentGrade(string usual_grade, string test_grade, string total_grade, string student_id)
        {       
            //插入成绩
            if(usual_grade != "" && usual_grade != null && test_grade != "" && test_grade != null)
            {
                String sql = "update Course_choosing set usual_grade = @usual_grade,test_grade = @test_grade,total_grade = @total_grade where student_id = @student_id";
                SqlParameter[] pars = { new SqlParameter("@usual_grade", usual_grade), new SqlParameter("@test_grade", test_grade), new SqlParameter("@total_grade", total_grade), new SqlParameter("@student_id", student_id) };
                return DBUtils.getDBUtils().cud(sql, pars);
            } 
            else if (usual_grade != "" && usual_grade != null && (test_grade == "" || test_grade == null))
            {
                String sql = "update Course_choosing set usual_grade = @usual_grade where student_id = @student_id";
                SqlParameter[] pars = { new SqlParameter("@usual_grade", usual_grade), new SqlParameter("@student_id", student_id) };
                return DBUtils.getDBUtils().cud(sql, pars);
            }
            else if (test_grade != "" && test_grade != null && (usual_grade == "" || usual_grade == null))
            {
                String sql = "update Course_choosing set test_grade = @test_grade where student_id = @student_id";
                SqlParameter[] pars = { new SqlParameter("@test_grade", test_grade), new SqlParameter("@student_id", student_id) };
                return DBUtils.getDBUtils().cud(sql, pars);
            }
            else
            {
                return 0;
            }


        }

        public Status GetStatus(string courseid)
        {
            string sql = "select * from Status where courseid = @courseid";
            SqlParameter[] pars = { new SqlParameter("@courseid", courseid) };
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, pars);
            Status status = null;
            if(dataTable.Rows.Count > 0)
            {
                DataRow dataRow = dataTable.Rows[0];
                status = new Status();
                status.Id = dataRow["Id"].ToString();
                status.courseid = dataRow["courseid"].ToString();
                status.status = dataRow["status"].ToString();
               // status.global_status = dataRow["global_status"].ToString();
            }
            return status;
        }

        public void SetStatus(string mystatus,string courseid)
        {
            String sql = "insert into Status(Id,courseid, status) values(@myid,@courseid,@mystatus)";
            SqlParameter[] pars = { new SqlParameter("@myid",Guid.NewGuid()) ,new SqlParameter("@courseid", courseid), new SqlParameter("@mystatus", mystatus) };
            DBUtils.getDBUtils().cud(sql, pars);
        }

        public void SetAllStatus(string mystatus)
        {
            String sql = "update Status set scale = @mystatus where id = 1";
            SqlParameter[] pars = { new SqlParameter("@mystatus", mystatus) };
            DBUtils.getDBUtils().cud(sql, pars);
        }

        public Status GetAllStatus()
        {
            string sql = "select * from Status where Id = 1";
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, new SqlParameter[] { });
            Status status = null;
            if (dataTable.Rows.Count > 0)
            {
                DataRow dataRow = dataTable.Rows[0];
                status = new Status();
                status.Id = dataRow["Id"].ToString();
                status.global_status = dataRow["global_status"].ToString();
            }
            return status;
        }


        public IList<Teacher> SelTeacherByCollegeId(string CollegeId)
        {
            string sql = "select Teacher_id,Teacher_name from Teacher where college_id=@collegeid ";
            SqlParameter[] pars = {
                new SqlParameter("@collegeid",CollegeId),

             };
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, pars);

            IList<Teacher> teacherList = new List<Teacher>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Teacher t = new Teacher();
                t.teacher_id = dataTable.Rows[i]["teacher_id"].ToString();
                t.teacher_name = dataTable.Rows[i]["teacher_name"].ToString();
                teacherList.Add(t);
            }
            return teacherList;
        }

        public Teacher SelTeacherByTeacherId(string TeacherId)
        {
            string sql = "select Teacher_name from Teacher where Teacher_id=@id";

            SqlParameter[] pars = {
                new SqlParameter("@id",TeacherId),

        };

            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, pars);

            Teacher t = null;


            if (dataTable.Rows.Count > 0)
            {
                t = new Teacher();
                DataRow dataRow = dataTable.Rows[0];

                t.teacher_name = dataRow["teacher_name"].ToString();

            }

            return t;
        }
    }
}
