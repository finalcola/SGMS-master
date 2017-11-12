using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.DAL
{
    /// <summary>
    /// 对课程进行增删改查的操作
    /// </summary>
    public interface ICourseDAL
    {
        CourseType GetCourseType(string name);
       

        IList<Course> SelCourseforArrangeCourse(string course_type, string college);

        #region 分页查询相应类别的基本课程信息
        /// <summary>
        /// 分页查询相应类别的课程
        /// </summary>
        /// <param name="courseType">课程类型（枚举）</param>
        /// <param name="status">课程状态</param>
        /// <param name="start">在数据库中的页数</param>
        /// <param name="size">查询大小</param>
        /// <returns></returns>
        IList<Course> SelectCoursesBaseInfo(CourseType courseType, int status, int start, int size);
        #endregion


        #region 根据课程id查找课程详细信息
        /// <summary>
        /// 根据课程id查找课程详细信息
        /// </summary>
        /// <param name="id">课程id</param>
        /// <returns></returns>
        Course SelectCourseById(int id);
        #endregion

        Course SelectCourseById(string id);


        #region 查询最新的size门课程
        /// <summary>
        /// 查询最新的size门课程
        /// </summary>
        /// <param name="size">查询数量</param>
        /// <param name="courseType">课程类型</param>
        /// <returns></returns>
        IList<Course> SelectCoursesOrderByDate(CourseType courseType, int size);
        #endregion


        #region 查询选课人数最多的size门课程
        /// <summary>
        /// 查询选课人数最多的size门课程
        /// </summary>
        /// <param name="courseType">课程类型</param>
        /// <param name="size"></param>
        /// <returns></returns>
        IList<Course> SelectCoursesOrderBySelectCount(CourseType courseType, int size);
        #endregion

        /// <summary>
        /// 获取数据库中相应课程类型的数量
        /// </summary>
        /// <param name="courseType">课程类型</param>
        /// <param name="status">课程的status</param>
        /// <returns></returns>
        int SelectCountByType(CourseType courseType, int status);


        #region
        /// <summary>
        /// 添加课程的基本信息进数据库
        /// </summary>
        /// <param name="courseId">课程id 自动生成</param>
        /// <param name="courseName">课程名</param>
        /// <param name="courseCreadit">课程学分</param>
        /// <param name="courseHour">课程学时</param>
        /// <param name="courseType">课程类型</param>
        /// <param name="courseTheory">课程理论课时</param>
        /// <param name="courseExperiment">课程实验课时</param>
        /// <param name="courseOpentime">课程开放时间</param>
        /// <param name="coursePrior">先行课程</param>
        /// <param name="status">课程状态</param>
        /// <returns></returns>
        string AddCourseBaseInfo(string courseID,string courseName, decimal courseCreadit, string courseHour, string courseType, string courseTheory,
                                  string courseDepartement, string courseClass, string courseExperiment, string courseOpentime, string coursePrior, int status);

        #endregion


        #region
        /// <summary>
        /// 修改课程信息
        /// </summary>
        /// <param name = "courseId">无法修改</param>
        /// <param name="courseName">课程名</param>
        /// <param name="courseCreadit">课程学分</param>
        /// <param name="courseHour">课程学时</param>
        /// <param name="courseType">课程类型</param>
        /// <param name="courseTheory">课程理论课时</param>
        /// <param name="courseExperiment">课程实验课时</param>
        /// <param name="courseOpentime">课程开放时间</param>
        /// <param name="coursePrior">先行课程</param>
        /// <param name="status">课程状态</param>
        /// <returns></returns>
        #endregion
        string UpdateCourseBaseInfo(string courseID, string courseName, decimal courseCreadit, string courseHour, string courseType, string courseDepartement, string courseClass, string courseTheory, string courseExperiment, string courseOpentime, string coursePrior, int status);

        string DeleteCourseBaseInfo(String courseID);

        /// <summary>
        /// 查询课程,当入参为-1或null或""时，表示省略该参数
        /// </summary>
        /// <param name="courseType">课程类型</param>
        /// <param name="courseOpentime">开课时间</param>
        /// <param name="collageId">开课学院id</param>
        /// <param name="courseName">课程名</param>
        /// <returns></returns>
        IList<Course> SelectCourse(CourseType courseType, string courseOpentime, string collageId, string courseName, int page, int size);

        /// <summary>
        /// 查询课程总数，与SelectCourse配合使用
        /// </summary>
        /// <param name="courseType"></param>
        /// <param name="courseOpentime"></param>
        /// <param name="collageId"></param>
        /// <param name="courseName"></param>
        /// <returns></returns>
        int SelectCount(CourseType courseType, string courseOpentime, string collageId, string courseName);

        /// <summary>
        /// 学生选课接口
        /// </summary>
        /// <param name="student">封装学生信息</param>
        /// <param name="course">封装课程信息</param>
        void ChooseCourse(Student student, Teacher_course courseInfo);

        /// <summary>
        /// 删除已选课程
        /// </summary>
        /// <param name="stuId"></param>
        /// <param name="courseId"></param>
        void DeleteCourseChoosing(string stuId, string courseId);

        /// <summary>
        /// 查询学生选课记录
        /// </summary>
        /// <param name="stuId">学生id</param>
        /// <returns></returns>
        IList<Course_choosing> SelectCourseChoosingListByStu(string stuId);

        /// <summary>
        /// 查询选课的具体信息
        /// </summary>
        /// <param name="courseChoosingId"></param>
        /// <returns></returns>
        Course_choosing SelectCourseChoosingDetails(string courseChoosingId);

        /// <summary>
        /// 查询学生在year年的各科成绩
        /// </summary>
        /// <param name="stuId"></param>
        /// <param name="year">年度</param>
        /// <returns>封装成绩字段和课程名，不查询其他信息</returns>
        IList<Course_choosing> SelectGrade(string stuId,int year);

        /// <summary>
        /// 获取课程类型列表
        /// </summary>
        /// <returns></returns>
        IList<String> SelectCourseTypes();
        
        
    }

    public enum CourseType
    {
        [Description("专业必修课")]
        Required = 1,
        [Description("专业选修课")]
        Elective = 2,
        [Description("公共必修课")]
        PublicRequired = 3,
        [Description("公共选修课")]
        PublicElective = 4
    }

    /// <summary>
    /// 课程类型相关的工具类
    /// </summary>
    public class CourseTypeUtils
    {
        /// <summary>
        /// 通过反射获取CourseType上的注解
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public static String GetInfo(CourseType course)
        {
            Type type = typeof(CourseType);
            foreach (MemberInfo mInfo in type.GetMembers())
            {
                if (mInfo.Name.Equals(course.ToString()))
                {
                    foreach (Attribute attr in Attribute.GetCustomAttributes(mInfo))
                    {
                        if (attr.GetType() == typeof(DescriptionAttribute))
                        {
                            //Console.WriteLine(((DescriptionAttribute)attr).Description);
                            return ((DescriptionAttribute)attr).Description;
                        }
                    }
                }


            }

            return null;
        }

        public static CourseType GetCourseType(string name)
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

        /// <summary>
        /// 获取课程类型列表
        /// </summary>
        /// <returns></returns>
        public static IList<Object> GetCourseTypes()
        {
            IList<Object> courses = new List<Object>();

            foreach (CourseType courseType in Enum.GetValues(typeof(CourseType)))
            {
                string courseTypeName = GetInfo(courseType);
                courses.Add(new { courseTypeName=courseTypeName,courseTypeId=(int)courseType});
            }

            return courses;
        }
    }





}
