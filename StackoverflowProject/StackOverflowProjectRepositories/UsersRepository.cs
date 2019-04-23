using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverFlowProjectDomainModels;

namespace StackOverflowProjectRepositories
{
    public interface IUsersRepository
    {
        void InsertUser(User user);
        void UpdateUserDetails(User user);
        void UpdateUserPassword(User user);
        void DeleteUser(int uid);
        List<User> GetUsers();
        List<User> GetUsersByEmailAndPassword(string email, string password);
        List<User> GetUsersByEmail(string email);
        List<User> GetUsersByUserID(int userId);
        int GetlatestuserID();
    }

    class UsersRepository : IUsersRepository
    {
        private StackOverflowDatabaseDbContext _db;
        public UsersRepository(StackOverflowDatabaseDbContext db)
        {
            _db = db;
        }

        public void DeleteUser(int uid)
        {
            var us = _db.Users.Where(d => d.UserID == uid).FirstOrDefault();
            if (us != null)
            {
                _db.Users.Remove(us);
                _db.SaveChanges();
            }
        }

        public int GetlatestuserID()
        {
            var latest = _db.Users.Select(l => l.UserID).Max();
            return latest;
        }

        public List<User> GetUsers()
        {
            var users = _db.Users.Where(u =>u.IsAdmin == false).OrderBy(n=>n.Name).ToList();
            return users;
        }

        public List<User> GetUsersByEmail(string Email)
        {
            var user = _db.Users.Where(e => e.Email == Email).ToList();
            return user;
        }

        public List<User> GetUsersByEmailAndPassword(string email, string password)
        {
            var us = _db.Users.Where(e => e.Email == email && e.PasswordHash == password).ToList();
            return us;         
        }

        public List<User> GetUsersByUserID(int UserId)
        {
            var users = _db.Users.Where(x => x.UserID == UserId).ToList();
            return users;            
        }

        public void InsertUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public void UpdateUserDetails(User user)
        {
            var us = _db.Users.Where(u => u.UserID == user.UserID).FirstOrDefault();
            if (us != null)
            {
                us.Name = user.Name;
                us.Mobile = user.Mobile;
                _db.SaveChanges();               
            }
            
        }

        public void UpdateUserPassword(User user)
        {
            var us = _db.Users.Where(u => u.UserID == user.UserID).FirstOrDefault();
            if (us != null)
            {
                us.PasswordHash = user.PasswordHash;
                _db.SaveChanges();
            }
        }
    }
}
