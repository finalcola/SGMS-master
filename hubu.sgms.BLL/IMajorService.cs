using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.BLL
{
   public interface IMajorService
    {
        IList<Major> SelMajorByCollegeId(string CollegeId);
        Major SelMajorByMajorId(string MajorId);

    }


}
