using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerTest.DAL.Domain;
using ManagerTest.DAL.EF.Repositories;

namespace ManagerTest.BL
{
    public class GetUser
    {
        public RepositoryUserEF user;
        public GetUser()
        {
            user = new RepositoryUserEF();

        }
        public IEnumerable<User> ReturnUser()
        {
            return user.GetAll();
        }

    }
}
