using hubu.sgms.BLL;
using hubu.sgms.BLL.Impl;
using hubu.sgms.DAL;
using hubu.sgms.Model;
using NewWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hubu.sgms.WebApp.Controllers
{
    public class HomeController : Controller
    {
        IHomeService homeService = new HomeServiceImpl();
        INewsServices NewInfoBll = new INewsServices();

        //刷新首页的时候就显示新闻
        public ActionResult Index()
        {
            List<News> newInfoList = NewInfoBll.GetEntityList();
            for(int j=1;j<9;j++)
            {
                ViewData["title"+j] = newInfoList[newInfoList.Count - j].Title;
                ViewData["time"+j] = newInfoList[newInfoList.Count - j].SubDateTime;
                @ViewData["id"+j] = newInfoList[newInfoList.Count - j].Id;
            }
            @ViewData["msg1"] = newInfoList[newInfoList.Count - 1].Msg;
            @ViewData["msg2"] = newInfoList[newInfoList.Count - 2].Msg;
            @ViewData["msg3"] = newInfoList[newInfoList.Count - 3].Msg;
            return View();
        }




        /// <summary>
        /// 1-专业必修课,2-专业选修课,3-公共必修课,4-公共选修课
        /// </summary>
        /// <returns>返回json数据 0表示正确 1表示错误</returns>
        public ActionResult GetNewCourse(int size) {

            string code = "0";

            IList<Course> newCourseList = homeService.SelectNewCourse(0, size);
            IList<Course> zxCourseList = homeService.SelectCourseByType((CourseType)2, size);
            IList<Course> gxCourseList = homeService.SelectCourseByType((CourseType)4, size);
            IList<Course> gbCourseList = homeService.SelectCourseByType((CourseType)3, size);
            IList<Course> zbCourseList = homeService.SelectCourseByType((CourseType)1, size);

            if (newCourseList.Count > 0 && zxCourseList.Count <= 0 && 
                gxCourseList.Count > 0 && gbCourseList.Count > 0 && 
                zbCourseList.Count > 0) {
                code = "1";
            }           

            return Json(new {
                newCourseList = newCourseList,
                zxCourseList = zxCourseList,
                gxCourseList = gxCourseList,
                gbCourseList = gbCourseList,
                zbCourseList = zbCourseList,
                status = code
            });
            
        }
        
        
        
          

    }

 
}