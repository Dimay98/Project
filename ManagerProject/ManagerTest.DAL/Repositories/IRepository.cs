using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerTest.DAL.Domain;

namespace ManagerTest.DAL.Repositories
{
    public interface IRepository<T> where T : Resourse
    {

        IEnumerable<T> GetAll();
        void Create(T item);
        void Delete(T item);
        void Update(T item);
        void Close();
    }
}
