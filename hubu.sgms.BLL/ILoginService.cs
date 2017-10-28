using hubu.sgms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.BLL
{
    public interface ILoginService
    {
        Login GetUser(string username, string password);

        void ChangePass(string username, string password);
    }
}
