using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.BLL
{
    public interface ICourse_TimeService
    {
        IList<Course_Time> SelCourseTimeByItems(string ClassroomId, string Weekday, string TeacherId, string ClassId);
    }
}
