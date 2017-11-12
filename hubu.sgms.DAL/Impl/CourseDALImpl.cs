using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hubu.sgms.Model;
using System.Data.SqlClient;
using System.Data;
using hubu.sgms.Utils;

namespace hubu.sgms.DAL.Impl
{
    public class CourseDALIml : ICourseDAL
    {
        //基本信息对应的数据库字段
        public const string BaseInfo = "course_id,course_name,course_credit,course_hour,college_id ";
        //public const string BaseInfo = "course_id,course_name,course_credit,course_hour,course_type,course_theory,course_experiment,course_opentime,course_prior,status";



        public int SelectCountByType(CourseType courseType, int status)
        {
            string sql = "select count(*) as result from Course where course_type = @course_type and status = @status";
            string courseTypeDesc = CourseTypeUtils.GetInfo(courseType);//获取课程类型的中文表示（字段上的注解）
            SqlParameter[] parameters = {
                new SqlParameter("@course_type",courseTypeDesc),
                new SqlParameter("@status",status),
            };
            //查询
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, parameters);
            DataRow dataRow = dataTable.Rows[0];
            int count = Convert.ToInt32(dataRow["result"]);
            return count;
        }

        
        
        //--------------管理员添加修改课程----------------//
  
        public string AddCourseBaseInfo(string courseID, string courseName, decimal courseCreadit, string courseHour, string courseType, string courseDepartement, string courseClass, string courseTheory, string courseExperiment, string courseOpentime, string coursePrior, int status)
        {
            DateTime dt_new = DateTime.Now;
            DateTime dt_old = new DateTime(2010, 1, 1, 0, 0, 0);
            TimeSpan ts = dt_new.Subtract(dt_old).Duration();
            string dateDiff = ts.Days.ToString() + ts.Hours.ToString() +ts.Minutes.ToString() + ts.Seconds.ToString();
            courseID = dateDiff.ToString();

            String courseopentime= courseOpentime;
            string[] arr = courseopentime.Split(' ');
            string year = arr[3];
            string month = arr[1];
            string day = arr[2];
            string end="";
            int start=0;
            if (month.Equals("Feb")|| month.Equals("Mar")|| month.Equals("Apr")||
                month.Equals("May") || month.Equals("Jun") || month.Equals("Jul") || 
                month.Equals("Aug") || month.Equals("Sep"))
            {
                end = "02";
            }
            else
            {
                end = "01";
            }
            
           start = Convert.ToInt32(year)%2000;
           courseOpentime = start.ToString()+end ;

            //添加的id是系统自己生成的，并且保证其唯一性  专业和学院目前不插入
            string sql = "Insert into Course(course_id,course_name,course_credit,course_hour,course_type,course_theory,course_experiment,course_opentime,course_prior,status)values(@courseID, @courseName, @courseCreadit, @courseHour, @courseType,@courseTheory, @courseExperiment, @courseOpentime, @coursePrior, @status)";
            //@courseId, @courseName, @courseCreadit, @courseHour, @courseType, course_department,course_class,@courseTheory, @courseExperiment, @courseOpentime, @coursePrior, @status
            SqlParameter[] parameters = {
                new SqlParameter("@courseID",courseID),
                new SqlParameter("@courseName",courseName),
                new SqlParameter("@courseCreadit",courseCreadit),
                new SqlParameter("@courseHour",courseHour),
                new SqlParameter("@courseType",courseType),
      //          new SqlParameter("@courseDepartment",courseDepartment),
      //          new SqlParameter("@courseClass",courseClass),
                new SqlParameter("@courseTheory",courseTheory),
                new SqlParameter("@courseExperiment",courseExperiment),
                new SqlParameter("@courseOpentime",courseOpentime),
                new SqlParameter("@coursePrior",coursePrior),
                new SqlParameter("@status",status)
            };

            int count = DBUtils.getDBUtils().cud(sql, parameters);
            string succeed = "成功添加" + count + "个课程信息";
            return succeed;
        }

        public string UpdateCourseBaseInfo(string courseID, string courseName, decimal courseCreadit, string courseHour, string courseType, string courseDepartement, string courseClass, string courseTheory, string courseExperiment, string courseOpentime, string coursePrior, int status)
        {
            String courseopentime = courseOpentime;
            string[] arr = courseopentime.Split(' ');
            string year = arr[3];
            string month = arr[1];
            string day = arr[2];
            string end = "";
            int start = 0;
            if (month.Equals("Feb") || month.Equals("Mar") || month.Equals("Apr") ||
                month.Equals("May") || month.Equals("Jun") || month.Equals("Jul") ||
                month.Equals("Aug") || month.Equals("Sep"))
            {
                end = "02";
            }
            else
            {
                end = "01";
            }

            start = Convert.ToInt32(year) % 2000;
            courseOpentime = start.ToString() + end;

            //目前不更新学院和专业
            string sql = "update Course set course_name=@courseName,course_credit=@courseCreadit,course_hour=@courseHour,course_type=@courseType,course_theory=@courseTheory,course_experiment=@courseExperiment,course_opentime=@courseOpentime,course_prior=@coursePrior,status=@status where course_id=@courseID";
            
            //@courseId, @courseName, @courseCreadit, @courseHour, @courseType, @courseTheory, @courseExperiment, @courseOpentime, @coursePrior, @status
            SqlParameter[] parameters={
                new SqlParameter("@courseID",courseID),
                new SqlParameter("@courseName",courseName),
                new SqlParameter("@courseCreadit",courseCreadit),
                new SqlParameter("@courseHour",courseHour),
                new SqlParameter("@courseType",courseType),
                new SqlParameter("@courseTheory",courseTheory),
                new SqlParameter("@courseExperiment",courseExperiment),
                new SqlParameter("@courseOpentime",courseOpentime),
                new SqlParameter("@coursePrior",coursePrior),
                new SqlParameter("@status",status)
            };

            int count = DBUtils.getDBUtils().cud(sql, parameters);
            string succeed = "成功添加" + count + "个课程信息";
            return succeed;
        }


        public string DeleteCourseBaseInfo(String courseID)
        {
            //目前不更新学院和专业
            string sql = "delete from Course where course_id=@courseId";
            
            SqlParameter[] parameters = {
                new SqlParameter("@courseID",courseID)
            };

            int count = DBUtils.getDBUtils().cud(sql, parameters);
            string succeed = "成功删除" + count + "个课程信息";
            return succeed;
        }

        //---------------管理员添加修改课程---------------//


        #region 查询指定id的所有课程信息
        Course ICourseDAL.SelectCourseById(int id)
        {
            string sql = "select * from course where course_id = @course_id";
            SqlParameter[] parameters = {
                new SqlParameter("@course_id",id+"")
            };
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, parameters);
            Course course = new Course();
            if (dataTable.Rows.Count > 0)
            {
                //mdzz
                DataRow dataRow = dataTable.Rows[0];
                course.course_id = dataRow["course_id"].ToString();
                course.course_name = dataRow["course_name"].ToString();
                course.course_credit = decimal.Parse(dataRow["course_credit"].ToString());
                course.course_hour = dataRow["course_hour"].ToString();
                course.course_type = dataRow["course_type"].ToString();
                course.college_id = dataRow["college_id"].ToString();
                course.class_id = dataRow["class_id"].ToString();
                course.course_theory = dataRow["course_theory"].ToString();
                course.course_experiment = dataRow["course_experiment"].ToString();
                course.course_opentime = dataRow["course_opentime"].ToString();
                course.course_prior = dataRow["course_prior"].ToString();
                //  course.status =Int32.Parse(dataRow["status"].ToString());
                course.status =1;
                course.course_photo = dataRow["course_photo"].ToString();
            }
            return course;
        }
        #endregion

        #region 根据id(string类型)查询课程
        Course ICourseDAL.SelectCourseById(string id)
        {
            string sql = "select * from course where course_id = @course_id";
            SqlParameter[] parameters = {
                new SqlParameter("@course_id",id+"")
            };
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, parameters);
            Course course = new Course();
            if (dataTable.Rows.Count > 0)
            {
                //mdzz
                DataRow dataRow = dataTable.Rows[0];
                BeanUils.SetStringValues(course, dataRow);
                if (dataRow["status"] != null)
                {
                    course.status = Convert.ToInt32(dataRow["status"]);
                }
                if (dataRow["course_credit"] != null)
                {
                    course.course_credit = Convert.ToDecimal(dataRow["course_credit"]);
                }
            }
            return course;
        }
        #endregion


        #region 根据课程类型查询课程的基本信息列表（course_id,course_name,course_credit,course_hour,college_id）
        public IList<Course> SelectCoursesBaseInfo(CourseType courseType, int status,
                            int start, int size)
        {
            //string sql = "SELECT TOP @size " + BaseInfo + " from Course "
            //    + " where course_type = @course_type and status = @status and course_id not in "
            //    + " (SELECT TOP (@size2 * ( @start - 1 )) course_id FROM Course ORDER BY course_id) "
            //    + " ORDER BY course_id ";
            string sql = "SELECT " + BaseInfo + " from Course  where course_type = @course_type and status = @status  ORDER BY course_id";
            string courseTypeDesc = CourseTypeUtils.GetInfo(courseType);//获取课程类型的中文表示（字段上的注解）
            SqlParameter[] parameters = {
                //new SqlParameter("@size",size),
                //new SqlParameter("@start",start),
                new SqlParameter("@course_type",courseTypeDesc),
                //new SqlParameter("@size2",size),
                new SqlParameter("@status",status),
            };

            //查询
            DataTable dataTable = DBUtils.getDBUtils().getRecordsWithPage(sql, parameters, size, start);

            //存放结果
            IList<Course> courseList = new List<Course>();

            //遍历
            foreach (DataRow dataRow in dataTable.Rows)
            {
                //public const string BaseInfo = "course_id,course_name,course_credit,course_hour,college_id ";

                Course course = new Course();
                course.course_id = dataRow["course_id"].ToString();
                course.course_name = dataRow["course_name"].ToString();
                course.course_credit = decimal.Parse(dataRow["course_credit"].ToString());
                course.course_hour = dataRow["course_hour"].ToString();
                course.course_experiment = dataRow["college_id"].ToString();
                courseList.Add(course);
            }
            return courseList;
        }
        #endregion

        #region 查询最新的size门课程的基本信息
        public IList<Course> SelectCoursesOrderByDate(CourseType courseType, int size)
        {
            string sql = "SELECT TOP @size  " + BaseInfo + " from Course "
                + "where course_type = @course_type and status='1' order by course_id ";
            string courseTypeDesc = CourseTypeUtils.GetInfo(courseType);//获取课程类型的中文表示（字段上的注解）
            SqlParameter[] parameters = {
                new SqlParameter("@size",size),
                new SqlParameter("@course_type",courseTypeDesc)
            };

            //查询
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, parameters);
            //存放结果
            IList<Course> courseList = new List<Course>();
            //遍历
            foreach (DataRow dataRow in dataTable.Rows)
            {
                //public const string BaseInfo = "course_id,course_name,course_credit,course_hour,college_id ";

                Course course = new Course();
                course.course_id = dataRow["course_id"].ToString();
                course.course_name = dataRow["course_name"].ToString();
                course.course_credit = decimal.Parse(dataRow["course_credit"].ToString());
                course.course_hour = dataRow["course_hour"].ToString();
                course.college_id = dataRow["college_id"].ToString();
                courseList.Add(course);
            }
            return courseList;

        }
        #endregion



        #region 查询选课人数最多的size门课程
        public IList<Course> SelectCoursesOrderBySelectCount(CourseType courseType, int size)
        {
            string sql = " select top @size " + BaseInfo
                + " from (select course_id, COUNT(*) as c from Course_choosing group by course_id) as Id_C(course_id,c),Course c "
                + " where Id_C.course_id=c.course_id and course_type = @course_type "
                + " order by Id_c.c desc ";
            string courseTypeDesc = CourseTypeUtils.GetInfo(courseType);//获取课程类型的中文表示（字段上的注解）
            SqlParameter[] parameters = {
                new SqlParameter("@size",size),
                new SqlParameter("@course_type",courseTypeDesc)
            };

            //查询
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, parameters);
            //存放结果
            IList<Course> courseList = new List<Course>();
            //遍历
            foreach (DataRow dataRow in dataTable.Rows)
            {
                //public const string BaseInfo = "course_id,course_name,course_credit,course_hour,college_id ";

                Course course = new Course();
                course.course_id = dataRow["course_id"].ToString();
                course.course_name = dataRow["course_name"].ToString();
                course.course_credit = decimal.Parse(dataRow["course_credit"].ToString());
                course.course_hour = dataRow["course_hour"].ToString();
                course.college_id = dataRow["college_id"].ToString();
                courseList.Add(course);
            }
            return courseList;
        }
        #endregion

        public IList<Course> SelectCourse(CourseType courseType, string courseOpentime, string collegeId, string courseName,
            int page, int size)
        {
            string sql = "select " + BaseInfo +
                " from Course where course_type=@courseType ";
            // and course_opentime=@courseOpentime and college_id = @collegeId order by course_id

            string courseTypeDesc = CourseTypeUtils.GetInfo(courseType);//获取课程类型的中文表示（字段上的注解）

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@courseType", courseTypeDesc));

            //拼接sql
            #region 拼接sql，并把相应参数放入list
            if (courseOpentime != null && !"".Equals(courseOpentime))
            {
                sql += " and course_opentime=@courseOpentime ";
                paramList.Add(new SqlParameter("@courseOpentime", courseOpentime));
            }
            if (collegeId != null && !"".Equals(collegeId))
            {
                sql += " and college_id = @collegeId ";
                paramList.Add(new SqlParameter("@collegeId", collegeId));
            }
            if (courseName != null && !"".Equals(courseName))
            {
                sql += " and course_name like @course_name ";
                courseName = "%" + courseName + "%";
                paramList.Add(new SqlParameter("@course_name", courseName));
            }
            sql += " order by course_id ";
            #endregion

            SqlParameter[] parameters = paramList.ToArray();

            //查询
            DataTable dataTable = DBUtils.getDBUtils().getRecordsWithPage(sql, parameters, size, page);
            //存放结果
            IList<Course> courseList = new List<Course>();
            //遍历
            foreach (DataRow dataRow in dataTable.Rows)
            {
                //public const string BaseInfo = "course_id,course_name,course_credit,course_hour,college_id ";

                Course course = new Course();
                course.course_id = dataRow["course_id"].ToString();
                course.course_name = dataRow["course_name"].ToString();
                course.course_credit = decimal.Parse(dataRow["course_credit"].ToString());
                course.course_hour = dataRow["course_hour"].ToString();
                course.college_id = dataRow["college_id"].ToString();
                courseList.Add(course);
            }
            return courseList;
        }

        /// <summary>
        /// 查询课程总数
        /// </summary>
        /// <param name="courseType"></param>
        /// <param name="courseOpentime"></param>
        /// <param name="collegeId"></param>
        /// <param name="courseName"></param>
        /// <returns></returns>
        public int SelectCount(CourseType courseType, string courseOpentime, string collegeId, string courseName)
        {
            string sql = "select count(*) as res " +
                " from Course where course_type=@courseType ";
            // and course_opentime=@courseOpentime and college_id = @collegeId order by course_id

            string courseTypeDesc = CourseTypeUtils.GetInfo(courseType);//获取课程类型的中文表示（字段上的注解）

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@courseType", courseTypeDesc));

            //拼接sql
            #region 拼接sql，并把相应参数放入list
            if (courseOpentime != null && !"".Equals(courseOpentime))
            {
                sql += " and course_opentime=@courseOpentime ";
                paramList.Add(new SqlParameter("@courseOpentime", courseOpentime));
            }
            if (collegeId != null && !"".Equals(collegeId))
            {
                sql += " and college_id = @collegeId ";
                paramList.Add(new SqlParameter("@collegeId", collegeId));
            }
            if (courseName != null && !"".Equals(courseName))
            {
                sql += " and course_name like @course_name";
                courseName = "%" + courseName + "%";
                paramList.Add(new SqlParameter("@course_name", courseName));
            }
            #endregion

            SqlParameter[] parameters = paramList.ToArray();
            //查询
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, parameters);

            DataRow row = dataTable.Rows[0];
            int count = Convert.ToInt32(row["res"]);

            return count;
        }

        /// <summary>
        /// 选课
        /// </summary>
        /// <param name="student"></param>
        /// <param name="courseInfo"></param>
        public void ChooseCourse(Student student, Teacher_course courseInfo)
        {
            Course_choosing course_Choosing = new Course_choosing();
            BeanUils.TransFields(student, course_Choosing);
            BeanUils.TransFields(courseInfo, course_Choosing);
            //学生课程表id由教师选课表id和学生id联合组成
            course_Choosing.course_choosing_id = courseInfo.teacher_course_id + student.student_id;
            //status默认为1
            string sql = "insert into Course_choosing(course_choosing_id,student_id,student_name,teacher_course_id,teacher_id,teacher_name,course_id,course_name,classroom_id,status,course_credit) "
                + " values(@course_choosing_id,@student_id,@student_name,@teacher_course_id,@teacher_id,@teacher_name,@course_id,@course_name,@classroom_id,@status,@course_credit)";
            IList<SqlParameter> sqlParameterList = BeanUils.SetInSQL(sql, course_Choosing);
            DBUtils.getDBUtils().cud(sql, sqlParameterList.ToArray());
        }

        #region 删除学生选课
        public void DeleteCourseChoosing(string stuId, string courseId)
        {
            string sql = "delete from Course_choosing where student_id=@stuId and course_id=@courseId ";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@stuId", stuId));
            paramList.Add(new SqlParameter("@courseId", courseId));
            DBUtils.getDBUtils().cud(sql, paramList.ToArray());
        }
        #endregion


        /// <summary>
        /// 查询学生选课记录,查询全部记录，所以当某些字段为null时，会抛出异常
        /// </summary>
        /// <param name="stuId">学生id</param>
        /// <returns></returns>
        public IList<Course_choosing> SelectCourseChoosingListByStu(string stuId)
        {
            string sql = "select * from Course_choosing where student_id='" + stuId + "'";
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql);
            IList<Course_choosing> courses = new List<Course_choosing>();
            foreach(DataRow row in dataTable.Rows)
            {
                Course_choosing course = new Course_choosing();
                int successCount = BeanUils.SetStringValues(course, row);
                try
                {
                    course.status = Convert.ToInt32(row["status"]);
                    course.usual_grade = Convert.ToDecimal(row["usual_grade"]);
                    course.test_grade = Convert.ToDecimal(row["test_grade"]);
                    course.course_credit = Convert.ToDecimal(row["course_credit"]);
                    course.total_grade = Convert.ToDecimal(row["total_grade"]);
                } catch (Exception e)
                {

                }
                courses.Add(course);
            }

            return courses;
        }

        /// <summary>
        /// 查询选课的具体信息
        /// </summary>
        /// <param name="courseChoosingId"></param>
        /// <returns></returns>
        public Course_choosing SelectCourseChoosingDetails(string courseChoosingId)
        {
            string sql = "select * from Course_choosing where course_choosing_id='" + courseChoosingId + "'";
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql);
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                Course_choosing course = new Course_choosing();
                int successCount = BeanUils.SetStringValues(course, row);
                try
                {
                    course.status = Convert.ToInt32(row["status"]);
                    course.usual_grade = Convert.ToDecimal(row["usual_grade"]);
                    course.test_grade = Convert.ToDecimal(row["test_grade"]);
                    course.course_credit = Convert.ToDecimal(row["course_credit"]);
                    course.total_grade = Convert.ToDecimal(row["total_grade"]);
                }
                catch (Exception e)
                {

                }
                return course;
            }
            return null;
        }


        /// <summary>
        /// 查询学生的各科成绩
        /// </summary>
        /// <param name="stuId"></param>
        /// <returns>封装成绩字段和课程名，不查询其他信息</returns>
        public IList<Course_choosing> SelectGrade(string stuId, int year)
        {
            //上半学期和下半学期
            string year01 = (year % 100) + "01";//将201702转化为1702格式
            string year02 = (year % 100) + "02";
            string sql = "select c.course_name,usual_grade,test_grade,total_grade,c.course_credit from Course_choosing cs , Course c "
                + " where student_id = @stuId and cs.course_id = c.course_id and c.course_opentime in (@year01, @year02)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@stuId", stuId));
            paramList.Add(new SqlParameter("@year01", year01));
            paramList.Add(new SqlParameter("@year02", year02));

            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql,paramList.ToArray());
            IList<Course_choosing> courses = new List<Course_choosing>();
            foreach (DataRow row in dataTable.Rows)
            {
                Course_choosing course = new Course_choosing();
                if (row["course_name"] != null)
                {
                    course.course_name = Convert.ToString(row["course_name"]);
                }
                if (row["usual_grade"] != null)
                {
                    try
                    {
                        course.usual_grade = Convert.ToDecimal(row["usual_grade"]);
                    }
                    catch (Exception)
                    {
                        course.usual_grade = null;
                    }

                }
                if (row["test_grade"] != null)
                {
                    try
                    {
                        course.test_grade = Convert.ToDecimal(row["test_grade"]);
                    }
                    catch (Exception)
                    {
                        course.usual_grade = null;
                    }
                }
                if (row["total_grade"] != null)
                {
                    try
                    {
                        course.total_grade = Convert.ToDecimal(row["total_grade"]);
                    }
                    catch (Exception)
                    {
                        course.usual_grade = null;
                    }

                }
                if (row["course_credit"] != null)
                {
                    try
                    {
                        course.course_credit = Convert.ToDecimal(row["course_credit"]);
                    }
                    catch (Exception)
                    {
                        course.course_credit = null;
                    }
                }

                courses.Add(course);
            }

            return courses;
        }

        /// <summary>
        /// 获取课程类型列表
        /// </summary>
        /// <returns></returns>
        public IList<String> SelectCourseTypes()
        {
            string courseTypeSql = "select distinct course_type from Course";
            DataTable dataTable = DBUtils.getDBUtils().getRecords(courseTypeSql);
            IList<string> courseTypes = new List<string>();

            foreach(DataRow row in dataTable.Rows)
            {
                if (row["course_type"] != null)
                {
                    courseTypes.Add(Convert.ToString(row["course_type"]));
                }

            }
            return courseTypes;
        }


        public IList<Course> SelCourseforArrangeCourse(string course_type, string college)
        {
            string sql = "select course_id,course_name from course where college_id=@college and course_type=@course_type";

            SqlParameter[] pars = {
                new SqlParameter("@course_type",course_type),
                new SqlParameter("@college",college)
        };
            //查询
            DataTable dataTable = DBUtils.getDBUtils().getRecords(sql, pars);

            //存放结果
            IList<Course> courseList = new List<Course>();

            //遍历
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Course c = new Course();
                c.course_id = dataTable.Rows[i]["course_id"].ToString();
                c.course_name = dataTable.Rows[i]["course_name"].ToString();
                courseList.Add(c);
            }

            // foreach (DataRow dataRow in dataTable["name"].Rows)
            //  {
            //  c.college_id = dataRow["college_id"].ToString();
            //       c.name = dataRow["name"].ToString();
            //       collegeList.Add(c);
            //   }
            return courseList;
        }


        public  CourseType GetCourseType(string name)
        {
            foreach (CourseType courseType in Enum.GetValues(typeof(CourseType)))
            {
                if (courseType.ToString().Equals(name))
                {
                    return courseType;
                }
            }
            return CourseType.PublicElective;
        }
    }
}
