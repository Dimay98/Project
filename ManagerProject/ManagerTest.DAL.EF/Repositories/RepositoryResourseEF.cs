using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerTest;
using System.Data.Entity;
using ManagerTest.DAL.Repositories;
using ManagerTest.DAL.Domain;

namespace ManagerTest.DAL.EF.Repositories
{
    public class RepositoryResourseEF :IRepository<Resourse>
    {

        public Context db;
       
       public RepositoryResourseEF()
        {
            this.db = new Context();
        }
      
        public virtual IEnumerable<Resourse> GetAll()
        {
            
           
            return db.Resourses;

        }
        public void Load()
        {
            db.Resourses.Load();
        }
        public virtual void Create(Resourse resourse)
        {
            db.Resourses.Add(resourse);
            db.SaveChanges();
        }
       
        public void Delete(Resourse resourse)
        {
            //db.Resourses.Remove(resourse);
            //db.SaveChanges();

            Resourse res = db.Resourses.Find(resourse.Id);
            if (res != null)
                db.Resourses.Remove(res);
            db.SaveChanges();
        }
    
       
        public void Update(Resourse resourse)
        {
            db.Entry(resourse).State = EntityState.Modified;
            db.SaveChanges();
        }
        public virtual void Save()
        {
            db.SaveChanges();
        }
        public void Close()
        {
            db.Dispose();
        }
    }
}
