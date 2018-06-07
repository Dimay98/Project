using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerTest.DAL.Domain;
using ManagerTest.DAL.EF.Repositories;

namespace ManagerTest.BL
{
    public class AddUser
    {
        public RepositoryUserEF user;


        public AddUser()
        {
            user = new RepositoryUserEF();
        }
        public bool AddUsr(string fio, string login, string password, string role)
        {
            try
            {

                user.Create(new User {  FIO= fio, Login = login, Password = password, Role = role });

                user.Save();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
