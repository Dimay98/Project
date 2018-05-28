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

        public ResourseContext db;
        //public RepositoryResourseEF(DbContext context)
        //{
        //    db = context;
        //    dbSet = context.Set<Resourse>();
        //}
        //public IEnumerable<Resourse> GetAll()
        //{
        //    return dbSet.Local.ToBindingList();
        //}
        //public ResourseContext db;

        //public RepositoryResourseEF(ResourseContext context)
        //{
        //    db = context;
        //}
       public RepositoryResourseEF()
        {
            this.db = new ResourseContext();
        }
        public virtual IEnumerable<Resourse> GetAll()
        {
            return db.Resourses.Local.ToBindingList() ;
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
            db.Resourses.Remove(resourse);
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
