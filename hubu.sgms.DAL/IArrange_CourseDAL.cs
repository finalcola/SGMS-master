using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.DAL
{
    public interface IArrange_CourseDAL
    {
        int AddArrange_Course(string course_id, string teacher_id, string class_id, string classroom_id, string time_id);
    }
}
