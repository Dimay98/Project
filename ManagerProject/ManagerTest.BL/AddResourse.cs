using ManagerTest.DAL.Domain;
using ManagerTest.DAL.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerTest.BL
{
    public class AddResourse
    {
        public RepositoryResourseEF resourse;
       
        public AddResourse()
        {
            resourse = new RepositoryResourseEF();
        }
        public bool AddRes(string name, int serialn, string time, string purposetouse)
        {
            try
            {
                resourse.Create(new Resourse { Name = name, SerialN = serialn, Time = time, PurposeToUse = purposetouse });
                resourse.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
