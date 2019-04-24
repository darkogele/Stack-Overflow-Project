using StackOverFlowProjectDomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowProjectRepositories.Interfaces
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
}
