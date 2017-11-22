using hubu.sgms.BLL;
using hubu.sgms.BLL.Impl;
using hubu.sgms.DAL;
using hubu.sgms.Model;
using hubu.sgms.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hubu.sgms.WebApp.Controllers
{
    /// <summary>
    /// 相应对课程信息进行增删改查的Controller
    /// 返回的js格式：
    /// 1、单个结果:status,message,result
    /// 2、返回List数据:count,resultList
    /// status=0表示请求失败，1表示成功
    /// message表示错误或成功信息
    /// result表示返回的单个对象，处理失败返回0
    /// </summary>
    public class CourseController : Controller
    {
        private ICourseService courseService = new CourseServiceImpl();

        public const int PageDefaultSize = 15;

        public const int PassedStatus = 1;

        public const int FailedStatus = 0;

        /// <summary>
        /// 跳转到课程展示列表页面
        /// </summary>
        /// <returns></returns>

        public ActionResult CourseDisplay()
        {
            //提取出参数的课程类型
            string courseType = Request["courseType"];
            //设置到ViewData中，将页面中的默认值改为courseType
            ViewData["courseTypeFromRequest"] = courseType;
            
            return View();
        }

        public ActionResult GetCourseDetail(int courseId)
        {

            Course course = courseService.SelectCourseById(courseId);
            ViewData["courseName"] = course.course_name;
            ViewData["courseType"] = course.course_type;
            ViewData["courseHour"] = course.course_hour;
            ViewData["courseCredit"] = course.course_credit;
            ViewData["coursePhoto"] = course.course_photo;
            return View();
        }
        

        // POST: Course
        /// <summary>
        /// 根据课程id获取详细信息
        /// </summary>
        /// <param name="courseId">课程id</param>
        /// <returns></returns>
        public ActionResult SelectCourseById(int courseId)
        {

            #region 验证登陆，如果未登录则返回请求错误的js
            Login login = (Login)Session["loginInfo"];
            if (login == null)
            {
                return Json(JsonUtils.CreatJsonObj(0, "未登录", null));
            }
            #endregion
            Course course = courseService.SelectCourseById(courseId);
            return Json(JsonUtils.CreatJsonObj(0, "OK！", course));
        }

        /// <summary>
        /// 获取相应类型的课程基本信息集
        /// </summary>
        /// <param name="courseType">
        /// 课程类型:1-专业必修课,2-专业选修课,3-公共必修课,4-公共选修课
        /// </param>
        /// <param name="page">起始页数</param>
        /// <param name="size">每页展示数量(从Request中读取，默认为10)</param>
        /// <returns></returns>
                    
        public ActionResult SelectCoursesByType(int courseType, int page)
        {
            int size = 0;
            string sizeStr = Request["size"];
            //如果传入的size为空或不合法，则size为默认大小
            if (sizeStr != null && !"".Equals(sizeStr))
            {
                try
                {
                    size = Convert.ToInt32(sizeStr);
                }
                catch (Exception)
                {
                    //如果转换发生异常，则size设置为默认大小
                    size = PageDefaultSize;
                }
            }
            else
            {
                size = PageDefaultSize;
            }

            //查询Count
            int count = courseService.SelectCountByType((CourseType)courseType, PassedStatus);

            IList<Course> courseList = courseService.SelectCoursesBaseInfo((CourseType)courseType, PassedStatus, page, size);

            return Json(JsonUtils.CreatJsonObj<Course>(count, courseList));
        }

        /// <summary>
        /// 搜索课程入口
        /// 可传入的参数有:["courseType"])课程类型,["courseTime"]开课时间,["collegeName"]开课学院,["courseName"]课程名称
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectCourses()
        {
            string courseTypeStr = Request["courseType"];
            int courseType = 1;//课程类型
            try
            {
                courseType = Convert.ToInt32(courseTypeStr);
            }
            catch (Exception e)
            {
                return Json(JsonUtils.CreatJsonObj(0, "不存在该课程类型!", null));
            }

            string courseTime = Request["courseTime"];//开课时间
            string collegeId = Request["collegeId"];//开课学院
            string courseName = Request["courseName"];//课程名称
            int page = Convert.ToInt32(Request["page"]);
            int size = Convert.ToInt32(Request["size"]);
            page = (page <= 0) ? 1 : page;
            size = (size <= 0) ? PageDefaultSize : size;

            if (courseTime != null && !"".Equals(courseTime))
            {
                int month = DateTime.Now.Month;
                int priod = (month <= 6) ? 1 : 2;//上半年为01，下半年为02
                courseTime += "0" + priod;
            }

            int count = courseService.SelectCount((CourseType)courseType, courseTime, collegeId, courseName);
            IList<Course> courseList = courseService.SelectCourse((CourseType)courseType, courseTime, collegeId, courseName, page, size);

            return Json(JsonUtils.CreatJsonObj<Course>(count, courseList));
        }

        /// <summary>
        /// 获取学院信息列表
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectColleges()
        {
            IList<College> colleges = courseService.SelectColleges();
            int count = colleges.Count;
            return Json(JsonUtils.CreatJsonObj<College>(count, colleges));
        }

        /// <summary>
        /// 选课接口，需要入参:学生id,教师_课程表的id
        /// </summary>
        /// <param name="teacherCourseId">教师_课程表的id</param>
        /// <returns></returns>
        public ActionResult ChooseCourse(string teacherCourseId)
        {
            if(teacherCourseId == null || "".Equals(teacherCourseId))
            {
                return Json(JsonUtils.CreatJsonObj(1, "课程id不能为空", null));
            }
            //获取登录信息
            Login login = (Login)Session["loginInfo"];
            if (login == null)
            {
                //跳转到登录页面
                return Json(JsonUtils.CreatJsonObj(1, "您还未登录!", null));
            }
            string stuId = login.username;//用登录名作为学生表的主键

            try
            {
                courseService.ChooseCourse(stuId, teacherCourseId);
                return Json(JsonUtils.CreatJsonObj(0, "OK", null));
            } catch (Exception)
            {
                return Json(JsonUtils.CreatJsonObj(1, "添加课程失败", null));
            }
            
        }

        /// <summary>
        /// 跳转到学生选课页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ChooseCoursePage()
        {
            //获取登录信息
            Login login = (Login)Session["loginInfo"];
            if (login == null)
            {
                //跳转到登录页面
                Session["prePage"] = "/Course/ChooseCourseView";//将当前页面地址放入session，登录后返回到该页面
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        /// <summary>
        /// 获取导航栏信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetNavbarInfo()
        {
            //courseTypeName,courseTypeId
            IList<Object> courseTypes = CourseTypeUtils.GetCourseTypes();
            IList<College> colleges = courseService.SelectColleges();
            return Json(new { courseTypes = courseTypes, colleges = colleges ,courseTypeCount=courseTypes.Count,collegeCount=colleges.Count});

        }

        public ActionResult HomeCourseDetail(int courseId)
        {
            Course course = courseService.SelectCourseById(courseId);

            ViewData["courseName"] = course.course_name;
            ViewData["courseType"] = course.course_type;
            ViewData["courseHour"] = course.course_hour;
            ViewData["courseCredit"] = course.course_credit;
            ViewData["coursePhoto"] = course.course_photo;
            ViewData["courseCollege"] = course.college_id;
            ViewData["courseExperiment"] = course.course_experiment;
            ViewData["courseOpentime"] = course.course_opentime;
            return View();
        }
    }


    #region 生成JsonObj的工具类
    /// <summary>
    /// 生成JsonObj的工具类
    /// </summary>
    public class JsonUtils
    {
        public static Object CreatJsonObj(int status, string msg, Object obj)
        {
            if (status == 1)
            {
                //请求失败
                return new { status = 0, message = msg, result = 0 };
            }
            else
            {
                if (msg == null)
                {
                    msg = "OK!";
                }
                return new { status = 1, message = msg, result = obj };
            }
        }

        public static Object CreatJsonObj<T>(int count, IList<T> list)
        {
            return new { count = count, list = list };
        }
    }
    #endregion
}