using hubu.sgms.BLL;
using hubu.sgms.BLL.Impl;
using hubu.sgms.DAL;
using hubu.sgms.Model;
using hubu.sgms.WebApp.Models;
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
    /// 


    public class ArrangeController : Controller
    {
        static string coursetype = "";
        static string college = "";
        static string majorid = "";
        static string teacherid = "";
        static string courseid = "";
        static string buildingid = "";
        static string weekdayid = "";
        static string classroomid = "";
        static string classid = "";
        static string course_timeid = "";


        private ICollegeService collegeService = new CollegeServiceImpl();
        private ITeacher_CourseService Teacher_CourseService = new Teacher_CourseServiceImpl();
        private ICourseService courseService = new CourseServiceImpl();
        private IMajorService majorService = new MajorServiceImpl();
        private IClassService classService = new ClassServiceImpl();
        private IArrange_CourseService arrange_courseService = new Arrange_CourseServiceImpl();
        private ITeacherService teacherService = new TeacherServiceImpl();
        private IClassroomService classroomService = new ClassroomServiceImpl();
        private ICourse_TimeService course_timeService = new Course_TimeServiceImpl();


       


        

        


        public ActionResult CAArrangeCourse()
        {

            return View("CAArrangeCourse");
        }

        public ActionResult CAFillMajor(string college)
        {
            IList<Major> m = majorService.SelMajorByCollegeId(college);

            var categoryMajorList = new List<Major>();

            for (int i = 0; i < m.Count; i++)
            {
                categoryMajorList.Add(m[i]);
            }

            var selectItemListforMajor = new List<SelectListItem>() {
                       new SelectListItem(){Value="",Text="全部",Selected=true}
                   };
            var selectMajorList = new SelectList(categoryMajorList, "major_id", "major_name");

            selectItemListforMajor.AddRange(selectMajorList);

            ViewBag.majorList = selectItemListforMajor.AsEnumerable();

            return Json(selectItemListforMajor);
        }


        public ActionResult CAFillCourse(string college, string coursetype)
        {
            IList<Course> c = courseService.SelCourseforArrangeCourse(coursetype, college);

            var categoryList = new List<Course>();

            for (int i = 0; i < c.Count; i++)
            {
                categoryList.Add(c[i]);
            }

            var selectItemListforCourse = new List<SelectListItem>() {
                       new SelectListItem(){Value="",Text="全部",Selected=true}
                   };
            var selectCollegeList = new SelectList(categoryList, "course_id", "course_name");

            selectItemListforCourse.AddRange(selectCollegeList);

            return Json(selectItemListforCourse);
        }

        public ActionResult CAFillTeacher(string college)
        {
            IList<Teacher> t = teacherService.SelTeacherByCollegeId(college);

            var categoryTeacherList = new List<Teacher>();

            for (int i = 0; i < t.Count; i++)
            {
                categoryTeacherList.Add(t[i]);
            }

            var selectItemListforTeacher = new List<SelectListItem>() {
                       new SelectListItem(){Value="",Text="全部",Selected=true}
                   };
            var selectTeacherList = new SelectList(categoryTeacherList, "teacher_id", "teacher_name");

            selectItemListforTeacher.AddRange(selectTeacherList);

            return Json(selectItemListforTeacher);
        }

        public ActionResult CAFillClass(string major)
        {
            IList<Class> c1 = classService.SelClassByMajorId(major);

            var categoryClassList = new List<Class>();

            for (int i = 0; i < c1.Count; i++)
            {
                categoryClassList.Add(c1[i]);
            }

            var selectItemListforClass = new List<SelectListItem>() {
                       new SelectListItem(){Value="",Text="全部",Selected=true}
                   };
            var selectClassList = new SelectList(categoryClassList, "class_id", "yuliu1");

            selectItemListforClass.AddRange(selectClassList);

            return Json(selectItemListforClass);
        }

        public ActionResult CAFillClassroom(string building)
        {
            IList<Classroom> c = classroomService.SelClassroomByBuilding(building);
            var categoryClassroomList = new List<Classroom>();
            for (int j = 0; j < c.Count; j++)
            {
                categoryClassroomList.Add(c[j]);
            }
            var selectItemListforClassroom = new List<SelectListItem>();
            
                selectItemListforClassroom = new List<SelectListItem>() {
                       new SelectListItem(){Value="",Text="全部",Selected=true}
                   };
            
            var selectClassroomList = new SelectList(categoryClassroomList, "classroom_id", "classroom");

            selectItemListforClassroom.AddRange(selectClassroomList);

            return Json(selectItemListforClassroom);
        }

        public ActionResult CAFillClasstime(string classroom, string weekday, string teacher, string class1)
        {
            IList<Course_Time> ct = course_timeService.SelCourseTimeByItems(classroom, weekday,teacher,class1);
            var categoryCourse_TimeList = new List<Course_Time>();

            for (int j = 0; j < ct.Count; j++)
            {
                categoryCourse_TimeList.Add(ct[j]);
            }

            
            var selectItemListforCourse_Time = new List<SelectListItem>();
            if (ct.Count == 0)
            {
                selectItemListforCourse_Time = new List<SelectListItem>() {

                       new SelectListItem(){Value="",Text="该教室当天已无空闲上课时段",Selected=true}
                   };
            }
            else {
                selectItemListforCourse_Time = new List<SelectListItem>() {

                       new SelectListItem(){Value="",Text="全部",Selected=true}
                   };
            }
            var selectCourse_TimeList = new SelectList(categoryCourse_TimeList, "time_id", "classtime");

            selectItemListforCourse_Time.AddRange(selectCourse_TimeList);

            return Json(selectItemListforCourse_Time);
        }

   
          public ActionResult InsArrangeDetail(string class1,string course,string teacher,string classroom,string classtime,string weekday)
        { 
            int i = 0;
            int j = 0;

            IList<Teacher_course> tc = Teacher_CourseService.SelTeacher_CourseByDetail(course, teacher, class1);
          
            if (tc.Count == 0) { i = Teacher_CourseService.AddTeacher_Course(course, teacher, class1);}
            
             j = arrange_courseService.AddArrange_Course(course, teacher, class1, classroom, classtime);

            IList<Course_Time> ct = course_timeService.SelCourseTimeByItems(classroom, weekday, teacher, class1);
            var categoryCourse_TimeList = new List<Course_Time>();
            for (int k = 0; k < ct.Count; k++)
            {
                categoryCourse_TimeList.Add(ct[k]);
            }
            var selectItemListforCourse_Time = new List<SelectListItem>();
            if (ct.Count == 0)
            {
                selectItemListforCourse_Time = new List<SelectListItem>() {

                       new SelectListItem(){Value="",Text="该教室当天已无空闲上课时段",Selected=true}
                   };
            }
            else { 
                 selectItemListforCourse_Time = new List<SelectListItem>() {
                
                       new SelectListItem(){Value="",Text="全部",Selected=true}
                   };}
            var selectCourse_TimeList = new SelectList(categoryCourse_TimeList, "time_id", "classtime");

            selectItemListforCourse_Time.AddRange(selectCourse_TimeList);

            return Json(selectItemListforCourse_Time);
        }

      
    }
}