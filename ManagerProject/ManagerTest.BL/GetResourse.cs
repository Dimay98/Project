using ManagerTest.DAL.Domain;
using ManagerTest.DAL.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.EntityClient;

namespace ManagerTest.BL
{
    public class GetResourse
    {
        public RepositoryResourseEF resourse;
        public GetResourse()
        {
            resourse = new RepositoryResourseEF();
            
        }
        public IEnumerable<Resourse> ReturnResourse()
        {
            return resourse.GetAll().ToList();
        }
       
    }
}
