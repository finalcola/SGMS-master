using hubu.sgms.BLL;
using hubu.sgms.DAL;
using NewWeb.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace hubu.sgms.WebApp.Controllers
{
    public class NewsController : Controller
    {
        //
       INewsServices NewInfoBll = new INewsServices();
       
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 分页展示数据
        /// </summary>
        /// <returns></returns>
        public JsonResult ShowNewsList()
        {
            //要求返回的数据json对象  {total:200,rows:[{},{}]}
            int pageSize = int.Parse(Request["rows"]??"10");
            int pageIndex = int.Parse(Request["page"]??"1");
            List<News> newInfoList= NewInfoBll.GetPageEntityList(pageIndex, pageSize);
            //查询所有数据
            var allNews = NewInfoBll.GetRecordCount();
            //把totle和rows:[{},{}]一起返回
            //先建立一个匿名类
            var dataJson = new { total = allNews, rows = newInfoList };
            var json = Json(dataJson, JsonRequestBehavior.AllowGet);
            return json;
        }

        /// <summary>
        /// 根据id查询记录
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowModelById()
        {
            int id = int.Parse(Request["id"]);
            News model = NewInfoBll.GetEntityModel(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        public ActionResult test()
        {
            return View();
        }


        /// <summary>
        /// 删除记录
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteNewInfo()
        {
            int id = int.Parse(Request["id"]);
            var r = NewInfoBll.DeleteNewInfo(id);
            if (r)
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }


        /// <summary>
        /// 修改记录
        /// </summary>
        /// <returns></returns>
        /// 不允许验证
        [ValidateInput(false)]
        public ActionResult UpdateNewInfo()
        {
            News newInfo = null;
            newInfo = new News();
            newInfo.Id = Convert.ToInt32(Request["Id"]);
            newInfo.Title = Request["Title"];
            newInfo.Author = Request["Author"];
            newInfo.Msg = Request["UpdateMsg"];
            newInfo.ImagePath = Request["UpdateImagePath"];
            newInfo.SubDateTime = DateTime.Now;
            if (NewInfoBll.UpdateNewInfo(newInfo))
            {
                return View();
            }
            else
            {
                return Content("no");
            }
        }


        /// <summary>
        /// 文件上传
        /// </summary>
        /// <returns></returns>
        public ActionResult FileUpload()
        {
            //接收文件
            HttpPostedFileBase file = Request.Files["MenuIcon"];
            //进行判断
            if (file == null)
            {
                return Content("no:上传文件不能为空!");
            }
            else 
            { 
                //获取文件名
                string fileName = Path.GetFileName(file.FileName);
                //获取文件扩展名(全部转换为大写)
                string fileExt = Path.GetExtension(fileName).ToUpper();
                //判断扩展名
                if (fileExt == ".JPG" || fileExt == ".PNG")
                {
                    //创建文件夹
                    string dir = "/FileUploadImage/";
                    Directory.CreateDirectory(Path.GetDirectoryName(Request.MapPath(dir)));
                    //更新文件名称
                    string newFileName = Convert.ToString(DateTime.Now.Year) + Convert.ToString(DateTime.Now.Month) + Convert.ToString(DateTime.Now.Day) + Convert.ToString(DateTime.Now.Hour) + Convert.ToString(DateTime.Now.Minute) + Convert.ToString(DateTime.Now.Second);
                    //全路径
                    string fullDir = dir + newFileName + fileExt;
                    //保存图片
                    file.SaveAs(Request.MapPath(fullDir));
                    //返回标识符和全路径
                    return Content("ok:" + fullDir);
                }
                else
                {
                    return Content("no:上传文件格式错误");
                }
            }
        }
       
        
        
        
        /// <summary>
        /// 添加新闻
        /// </summary>
        /// <returns></returns>   
        [ValidateInput(false)]
        public ActionResult AddNewInfo()
        {
            News newInfo = null;
            newInfo = new News();
            newInfo.Title = Request["Title"];
            newInfo.Author = Request["Author"];
            newInfo.Msg= Request["Msg"]; 
            newInfo.ImagePath = Request["ImagePath"];
            newInfo.SubDateTime = DateTime.Now;
            if (NewInfoBll.AddNewInfo(newInfo))
            {
                // return Content("ok");
                return View();
            }
            else
            {
                return Content("no");
            }
        }

        /// <summary>
        /// 详细查看
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowDetail(int id)
        {
            List<News> newInfoList = NewInfoBll.GetEntityList();

            ViewData["count"] = newInfoList[newInfoList.Count - 1].Id;
            //得到数据库中的第一条记录和最后一条记录
            int first = newInfoList[0].Id;
            int last = newInfoList[newInfoList.Count - 1].Id;

            //给当前新闻赋值
            News newInfo = NewInfoBll.GetEntityModel(id);
            ViewData["Id"] = newInfo.Id;
            ViewData["Title"] = newInfo.Title;
            ViewData["Author"] = newInfo.Author;
            ViewData["ImagePath"] = newInfo.ImagePath;
            ViewData["Msg"] = newInfo.Msg;
            ViewData["SubDateTime"] = newInfo.SubDateTime;

            //找到当前新闻的上一条新闻和下一条新闻的id
            int next = 0;
            int prior = 0;
            if (id == first || id == last)
            {

                if (newInfo.Id == first)   //第一条新闻没有上一条新闻
                {
                    next = newInfoList[1].Id;
                }
                if (newInfo.Id == last)   //最后一条新闻没有下一条新闻
                {
                    prior = newInfoList[newInfoList.Count - 2].Id;
                }
            }
            else {
                for (int i = 0; i < newInfoList.Count; i++)
                {
                    if (newInfoList[i].Id == newInfo.Id)
                    {
                        next = newInfoList[i - 1].Id;
                        prior = newInfoList[i + 1].Id;
                    }
                }
            }

            //判断当前新闻是否为第一条新闻或者最后一条新闻
            if (id== first)
            {
                ViewData["Titleup"] = "湖北大学";
                ViewData["ImagePathup"] = "/FileUploadImage/logo.jpg";
                ViewData["Msgup"] = "湖北大学（Hubei University）简称湖大（HUBU） ，坐落于湖北省武汉市，是湖北省人民政府与教育部共建的省属重点综合性大学，入选“中西部高校基础能力建设工程”，是湖北省“2011计划”牵头高校，武器装备科研生产二级保密资格高校，中国政府奖学金来华留学生和港澳台学生接收高校，是教育部和英国大使馆批准设立的湖北省唯一的雅思（IELTS）考试考点单位";
            }
            else
            {
                News upnewInfo = NewInfoBll.GetEntityModel(prior);
                ViewData["Titleup"] = upnewInfo.Title;
                ViewData["ImagePathup"] = upnewInfo.ImagePath;
                if (upnewInfo.Msg.Length > 70)
                {
                    ViewData["Msgup"] = upnewInfo.Msg.Substring(0, 70);
                }
                else
                {
                    ViewData["Msgup"] = upnewInfo.Msg;
                }
                ViewData["Msgup"] = ViewData["Msgup"] + "......";
            }


            //为最后一页，没有下一页
            if (id == last)
            {
                ViewData["Titlenext"] = "湖北大学";
                ViewData["ImagePathnext"] = "/FileUploadImage/logo.jpg";
                ViewData["Msgnext"] = "湖北大学（Hubei University）简称湖大（HUBU） ，坐落于湖北省武汉市，是湖北省人民政府与教育部共建的省属重点综合性大学，入选“中西部高校基础能力建设工程”，是湖北省“2011计划”牵头高校，武器装备科研生产二级保密资格高校，中国政府奖学金来华留学生和港澳台学生接收高校，是教育部和英国大使馆批准设立的湖北省唯一的雅思（IELTS）考试考点单位";

            }
            else
            {
                News nextnewInfo = NewInfoBll.GetEntityModel(next);
                ViewData["Titlenext"] = nextnewInfo.Title;
                ViewData["ImagePathnext"] = nextnewInfo.ImagePath;
                if (nextnewInfo.Msg.Length > 70)
                {
                    ViewData["Msgnext"] = nextnewInfo.Msg.Substring(0, 70);
                }
                else
                {
                    ViewData["Msgnext"] = nextnewInfo.Msg;
                }
                ViewData["Msgnext"] = ViewData["Msgnext"] + "......";
            }
           

            return View();
        }

        /// <returns></returns>
        public ActionResult AdminShowDetail(int id)
        {
            List<News> newInfoList = NewInfoBll.GetEntityList();

            ViewData["count"] = newInfoList[newInfoList.Count-1].Id;
            //得到数据库中的第一条记录和最后一条记录
            int first = newInfoList[0].Id;
            int last = newInfoList[newInfoList.Count - 1].Id;

            //给当前新闻赋值
            News newInfo = NewInfoBll.GetEntityModel(id);
            ViewData["Id"] = newInfo.Id;
            ViewData["Title"] = newInfo.Title;
            ViewData["Author"] = newInfo.Author;
            ViewData["ImagePath"] = newInfo.ImagePath;
            ViewData["Msg"] = newInfo.Msg;
            ViewData["SubDateTime"] = newInfo.SubDateTime;

            //找到当前新闻的上一条新闻和下一条新闻的id
            int next = 0;
            int prior = 0;
            if (id == first || id == last)
            {

                if (newInfo.Id == first)   //第一条新闻没有上一条新闻
                {
                    next = newInfoList[1].Id;
                }
                if (newInfo.Id == last)   //最后一条新闻没有下一条新闻
                {
                    prior = newInfoList[newInfoList.Count - 2].Id;
                }
            }
            else {
                for (int i = 0; i < newInfoList.Count; i++)
                {
                    if (newInfoList[i].Id == newInfo.Id)
                    {
                        next = newInfoList[i - 1].Id;
                        prior = newInfoList[i + 1].Id;
                    }
                }
            }

            //判断当前新闻是否为第一条新闻或者最后一条新闻
            if (id == first)
            {
                ViewData["Titleup"] = "湖北大学";
                ViewData["ImagePathup"] = "/FileUploadImage/logo.jpg";
                ViewData["Msgup"] = "湖北大学（Hubei University）简称湖大（HUBU） ，坐落于湖北省武汉市，是湖北省人民政府与教育部共建的省属重点综合性大学，入选“中西部高校基础能力建设工程”，是湖北省“2011计划”牵头高校，武器装备科研生产二级保密资格高校，中国政府奖学金来华留学生和港澳台学生接收高校，是教育部和英国大使馆批准设立的湖北省唯一的雅思（IELTS）考试考点单位";
            }
            else
            {
                News upnewInfo = NewInfoBll.GetEntityModel(prior);
                ViewData["Titleup"] = upnewInfo.Title;
                ViewData["ImagePathup"] = upnewInfo.ImagePath;
                if (upnewInfo.Msg.Length > 70)
                {
                    ViewData["Msgup"] = upnewInfo.Msg.Substring(0, 70);
                }
                else
                {
                    ViewData["Msgup"] = upnewInfo.Msg;
                }
                ViewData["Msgup"] = ViewData["Msgup"] + "......";
            }


            //为最后一页，没有下一页
            if (id == last)
            {
                ViewData["Titlenext"] = "湖北大学";
                ViewData["ImagePathnext"] = "/FileUploadImage/logo.jpg";
                ViewData["Msgnext"] = "湖北大学（Hubei University）简称湖大（HUBU） ，坐落于湖北省武汉市，是湖北省人民政府与教育部共建的省属重点综合性大学，入选“中西部高校基础能力建设工程”，是湖北省“2011计划”牵头高校，武器装备科研生产二级保密资格高校，中国政府奖学金来华留学生和港澳台学生接收高校，是教育部和英国大使馆批准设立的湖北省唯一的雅思（IELTS）考试考点单位";

            }
            else
            {
                News nextnewInfo = NewInfoBll.GetEntityModel(next);
                ViewData["Titlenext"] = nextnewInfo.Title;
                ViewData["ImagePathnext"] = nextnewInfo.ImagePath;
                if (nextnewInfo.Msg.Length > 70)
                {
                    ViewData["Msgnext"] = nextnewInfo.Msg.Substring(0, 70);
                }
                else
                {
                    ViewData["Msgnext"] = nextnewInfo.Msg;
                }
                ViewData["Msgnext"] = ViewData["Msgnext"] + "......";
            }


            return View();
        }

        public ActionResult ShowMore()
        {
            return View();
        }
    }
}

