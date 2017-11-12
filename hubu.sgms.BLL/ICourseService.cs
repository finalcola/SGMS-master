using hubu.sgms.DAL;
using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.BLL
{
    /// <summary>
    /// 2017年10月3日 17:28:03
    /// </summary>
    public interface ICourseService
    {
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


        // 添加课程信息数据
        string AddCourseBaseInfo(string courseID, string courseName, decimal courseCreadit, string courseHour, string courseType, string courseDepartement, string courseClass, string courseTheory,
                                   string courseExperiment, string courseOpentime, string coursePrior, int status);
        
        // 修改课程信息数据
        string UpdateCourseBaseInfo(string courseID,string courseName, decimal courseCreadit, string courseHour, string courseType, string courseDepartement, string courseClass,string courseTheory,
                                    string courseExperiment, string courseOpentime, string coursePrior, int status);

        // 删除课程信息数据
        string DeleteCourseBaseInfo(string courseID);


        /// <summary>
        /// 查询课程,当入参为-1或null或""时，表示省略该参数
        /// </summary>
        /// <param name="courseType">课程类型</param>
        /// <param name="courseOpentime">开课时间</param>
        /// <param name="collageName">开课学院</param>
        /// <param name="courseName">课程名</param>
        /// <returns></returns>
        IList<Course> SelectCourse(CourseType courseType, string courseOpentime, string collegeId, string courseName, int page, int size);


        int SelectCount(CourseType courseType, string courseOpentime, string collegeId, string courseName);

        /// <summary>
        /// 获取学院列表(所有信息)
        /// </summary>
        /// <returns></returns>
        IList<College> SelectColleges();

        /// <summary>
        /// 根据id查询学院信息
        /// </summary>
        /// <param name="collegeId"></param>
        /// <returns></returns>
        College SelectCollegeById(string collegeId);

        /// <summary>
        /// 选课
        /// </summary>
        /// <param name="stuId">学生id</param>
        /// <param name="teacherCourseId">教师选课记录表的id</param>
        /// <returns></returns>
        bool ChooseCourse(string stuId, string teacherCourseId);

        #region 删除学生选课
        void DeleteCourseChoosing(string stuId, string courseId);
        #endregion


        /// <summary>
        /// 获取课程类型列表
        /// </summary>
        /// <returns></returns>
        IList<Course> SelectCourseTypes();

        /// <summary>
        /// 根据课程类型和学院查询所有老师排课表
        /// </summary>
        /// <param name="courseType"></param>
        /// <param name="collegeId"></param>
        /// <returns></returns>
        IList<Teacher_course> SelectTeacherCourseList(string courseType, string collegeId);

        /// <summary>
        /// 查询学生已选的课程
        /// </summary>
        /// <param name="stuId"></param>
        /// <returns></returns>
        IList<Course_choosing> SelectCourseChoosingListByStu(string stuId);


        IList<College> SelCollegeforArrangeCourse();

        IList<Course> SelCourseforArrangeCourse(string course_type, string college);

    }
}
