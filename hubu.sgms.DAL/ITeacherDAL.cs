using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.DAL
{
    public interface ITeacherDAL
    {
        IList<Teacher_course> SelectAllCourse(string department, string major);
    }
}
