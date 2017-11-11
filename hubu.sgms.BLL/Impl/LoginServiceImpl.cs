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
    public class LoginServiceImpl : ILoginService
    {
        ILoginDAL loginDAL = new LoginDALImpl();

        public Login GetUser(string username, string password)
        {
            return loginDAL.GetUser(username,password);
            
        }


        public void ChangePass(string username, string password)
        {
            loginDAL.ChangePass(username, password);
        }


    }
}
