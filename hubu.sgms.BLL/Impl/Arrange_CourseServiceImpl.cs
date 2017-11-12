using hubu.sgms.DAL;
using hubu.sgms.DAL.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.BLL.Impl
{
   public  class Arrange_CourseServiceImpl:IArrange_CourseService
    {
        IArrange_CourseDAL Arrange_CourseDAL = new Arrange_CourseDALImpl();
        public int AddArrange_Course(string course_id, string teacher_id, string class_id, string classroom_id, string time_id)
        {
            return Arrange_CourseDAL.AddArrange_Course(course_id,  teacher_id, class_id,  classroom_id,  time_id);
        }
    }
}
