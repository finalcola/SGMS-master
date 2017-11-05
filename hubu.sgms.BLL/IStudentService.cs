using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.BLL
{
    public interface IStudentService
    {

        Student GetStudentById(string id);

        IList<Course_choosing> SelectGrades(string stuId, int year);
        
    }
}
