using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ManagerTest.DAL.Repositories;
using ManagerTest.DAL.Domain;

namespace ManagerTest.DAL.EF.Repositories
{
    public class RepositoryUserEF : IRepository<User>
    {

        public Context db;

        public RepositoryUserEF()
        {
            this.db = new Context();
        }

        public virtual IEnumerable<User> GetAll()
        {
            return db.Users;

        }
        public void Load()
        {
            db.Users.Load();
        }
        public virtual void Create(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void Delete(User user)
        {

            User us = db.Users.Find(user.Id);
            if (us != null)
                db.Users.Remove(us);
            db.SaveChanges();
        }


        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
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
