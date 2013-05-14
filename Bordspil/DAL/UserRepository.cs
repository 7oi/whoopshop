using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using Bordspil.Models;

namespace Bordspil.DAL
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private AppDataContext context;

        public UserRepository(AppDataContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserByID(int id)
        {
            return context.Users.Find(id);
        }

        public void InsertUser(User user)
        {
            context.Users.Add(user);
        }

        public void DeleteUser(int userID)
        {
            User UserProfiles = context.Users.Find(userID);
            context.Users.Remove(UserProfiles);
        }

        public void UpdateUser(User user)
        {
            context.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        void IUserRepository.DeleteUser(int userID)
        {
            throw new NotImplementedException();
        }

        User IUserRepository.GetUserByID(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<User> IUserRepository.GetUsers()
        {
            throw new NotImplementedException();
        }

        void IUserRepository.InsertUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}