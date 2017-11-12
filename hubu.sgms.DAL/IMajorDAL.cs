using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.DAL
{
    public interface IMajorDAL
    {
        IList<Major> SelMajorByCollegeId(string CollegeId);

        Major SelMajorByMajorId(string MajorId);
    }
}
