using hubu.sgms.BLL;
using hubu.sgms.BLL.Impl;
using hubu.sgms.DAL;
using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hubu.sgms.WebApp.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService studentService = StudentServiceImpl.Instance();
        private ICourseService courseService = new CourseServiceImpl();

        // GET: Student
        public ActionResult Index()
        {
            //student_address: location,
            //student_name: $("#student_name").val(),
            //student_id_card: $("#student_id_card").val(),
            //student_phone: $("#student_phone").val(),
            //student_email: $("#student_email").val(),
            //student_other: $("#student_other").val()
            Login login = (Login)Session["loginInfo"];
            if (login == null)
            {
                //未登录
                //跳转到登录页面
                Session["prePage"] = "/Student/Index";//将当前页面地址放入session，登录后返回到该页面
                return RedirectToAction("Index", "Login");
            }

            //查询学生信息
            Student student = studentService.GetStudentById(login.username);
            ViewData["student"] = student;

            return View();
        }

        public ActionResult ChangeInfo(string student_name, string student_address, string student_id_card,
            string student_phone, string student_other, string student_email)
        {
            return Json(new { status = 1 });
        }

        public ActionResult ChangePassPage()
        {
            return View();
        }

        #region 跳转到学籍信息页面
        public ActionResult InfoPage()
        {
            Login login = (Login)Session["loginInfo"];
            if (login == null)
            {
                //未登录
                //跳转到登录页面
                Session["prePage"] = "/Student/Index";//将当前页面地址放入session，登录后返回到该页面
                return RedirectToAction("Index", "Login");
            }

            string username = login.username;
            //string username = "201702";

            Student student = studentService.GetStudentById(username);
            ViewData["student"] = student;
            return View();
        }
        #endregion


        #region 学生选课接口,参数:老师课程表id
        /// <summary>
        /// 选课接口，需要入参:教师_课程表的id
        /// </summary>
        /// <param name="teacherCourseId">教师_课程表的id</param>
        /// <returns></returns>
        public ActionResult ChooseCourse(string teacherCourseId)
        {
            if (teacherCourseId == null || "".Equals(teacherCourseId))
            {
                return Json(JsonUtils.CreatJsonObj(1, "课程id不能为空", null));
            }
            //获取登录信息
            Login login = (Login)Session["loginInfo"];
            if (login == null)
            {
                return Json(JsonUtils.CreatJsonObj(1, "请先登录!", null));
            }
            string stuId = login.username;//用登录名作为学生表的主键


            try
            {
                courseService.ChooseCourse(stuId, teacherCourseId);
                return Json(JsonUtils.CreatJsonObj(0, "添加成功!", null));
            }
            catch (Exception e)
            {
                return Json(JsonUtils.CreatJsonObj(1, e.Message, null));
            }

        }
        #endregion

        #region 删除学生选课,入参:课程id
        public ActionResult DeleteCourseChooseing(string courseId)
        {
            //获取登录信息
            Login login = (Login)Session["loginInfo"];
            if (login == null)
            {
                return Json(JsonUtils.CreatJsonObj(1,"请先登录!",null));
            }

            Course course = courseService.SelectCourseById(courseId);
            if (course == null)
            {
                return Json(JsonUtils.CreatJsonObj(1, "没有该课程!", null));
            }
            if (course.course_type.IndexOf("选修") == -1)
            {
                return Json(JsonUtils.CreatJsonObj(1, "无法删除非选修课程!", null));
            }

            string stuId = login.username;
            try
            {
                courseService.DeleteCourseChoosing(stuId, courseId);
                
                return Json(JsonUtils.CreatJsonObj(0, "OK!", null));
            } catch(Exception e)
            {
                return Json(JsonUtils.CreatJsonObj(1, e.Message, null));
            }
            
        }
        #endregion

        #region 根据课程类型查询老师选课表和已选课表
        public ActionResult ChooseCourseList(String courseTypeName)
        {
            CourseType courseType = CourseTypeUtils.GetCourseType(courseTypeName);
            Login login = (Login)Session["loginInfo"];
            Student student = studentService.GetStudentById(login.username);
            string collegeId = student.college_id;

            //学生可以选择任意学院的公共选修课，所以不需要指定学院id
            if (courseTypeName.Equals("公共选修课"))
            {
                collegeId = null;
            }

            //所有相应课程类型的课程
            IList<Teacher_course> teacher_courses = courseService.SelectTeacherCourseList(courseTypeName,collegeId);
            IList<Course_choosing> course_Choosings = courseService.SelectCourseChoosingListByStu(student.student_id);

            return Json(new { t_course_count=teacher_courses.Count,t_course=teacher_courses,
                course_choose_count=course_Choosings.Count,course_choose=course_Choosings});
        }
        #endregion


        #region 跳转到选课页面
        public ActionResult ChooseCoursePage(string courseTypeName)
        {
            if (courseTypeName == null || courseTypeName.Equals(""))
            {
                return View("Error");
            }

            Login login = (Login)Session["loginInfo"];
            if (login == null)
            {
                //未登录
                //跳转到登录页面
                Session["prePage"] = "/Student/Index";//将当前页面地址放入session，登录后返回到该页面
                return RedirectToAction("Index", "Login");
            }

            Student student = studentService.GetStudentById(login.username);
            string collegeId = student.college_id;

            //学生可以选择任意学院的公共选修课，所以不需要指定学院id
            if (courseTypeName.Equals("公共选修课"))
            {
                collegeId = null;
            }

            //所有相应课程类型的课程
            IList<Teacher_course> teacher_courses_all = courseService.SelectTeacherCourseList(courseTypeName, collegeId);
            IList<Course_choosing> course_choosings = courseService.SelectCourseChoosingListByStu(student.student_id);

            IList<Teacher_course> teacher_courses = new List<Teacher_course>();
            //筛选teacher_courses_all中还没选的课程,并且查询出课程信息
            foreach (Teacher_course t_course in teacher_courses_all)
            {
                Course course = courseService.SelectCourseById(t_course.course_id);
                t_course.College = courseService.SelectCollegeById(course.college_id);
                t_course.Course = course;
                for (int i = 0; i < course_choosings.Count; i++)
                {
                    Course_choosing course_Choosing = course_choosings[i];
                    if (!course_Choosing.course_id.Equals(t_course.course_id))
                    {
                        if (i == (course_choosings.Count - 1))
                        {
                            teacher_courses.Add(t_course);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        //该课程已经被选过了
                        break;
                    }
                }

            }
            if (course_choosings.Count == 0)
            {
                //如果没有已选课程
                teacher_courses = teacher_courses_all;
            }

            //查询course_choosings中的课程信息
            IList<Course> choosedCourseList = new List<Course>();
            foreach(Course_choosing course_chooseing in course_choosings)
            {
                Course course = courseService.SelectCourseById(course_chooseing.course_id);
                choosedCourseList.Add(course);
            }

            ViewData["teacher_courses"] = teacher_courses;
            ViewData["course_choosings"] = choosedCourseList;
            return View();
        }
        #endregion

        #region 查询成绩界面
        public ActionResult GradeInfoPage()
        {
            Login login = (Login)Session["loginInfo"];
            if (login == null)
            {
                //未登录
                //跳转到登录页面
                Session["prePage"] = "/Student/Index";//将当前页面地址放入session，登录后返回到该页面
                return RedirectToAction("Index", "Login");
            }

            
            //查询成绩信息
            string yearStr = Request["year"];
            int year = DateTime.Now.Year;//默认为今年
            if (yearStr != null)
            {
                try
                {
                    year = Convert.ToInt32(yearStr);
                }
                catch (Exception)
                {
                    
                }
            }
            try
            {
                IList<Course_choosing> courses = studentService.SelectGrades(login.username, year);
                ViewData["courses"] = courses;
            }
            catch (Exception e)
            {
                return Json(JsonUtils.CreatJsonObj(1, e.Message, e));
            }           

            return View();
        }
        #endregion

    }
}