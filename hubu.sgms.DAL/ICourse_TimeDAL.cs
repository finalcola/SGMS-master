using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.DAL
{
    public interface ICourse_TimeDAL
    {
        IList<Course_Time> SelCourseTimeByItems(string ClassroomId,string Weekday,string TeacherId, string ClassId);

     //   Major SelMajorByMajorId(string MajorId);
    }
}
