using hubu.sgms.DAL;
using hubu.sgms.DAL.Impl;
using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.BLL.Impl
{
    public class Course_TimeServiceImpl:ICourse_TimeService
    {
        private ICourse_TimeDAL Course_TimeDAL = new Course_TimeDALImpl();

        public IList<Course_Time> SelCourseTimeByItems(string ClassroomId, string Weekday, string TeacherId, string ClassId)
        {
            return Course_TimeDAL.SelCourseTimeByItems(ClassroomId, Weekday, TeacherId, ClassId);
        }
    }
}
