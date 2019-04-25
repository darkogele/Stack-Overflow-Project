using StackOverflowProjectViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowProjectServiceLayer.Interfaces
{
    public interface IUSerService
    {
        int InsertUser(RegisterViewModel uvm);
        void UpdateUserDetails(EditUserDetailsViewModel uvm);
        void UpdateUserPassword(EditUserPasswordViewModel uvm);
        void DeleteUser(int uid);
        List<UserViewModel> GetUsers();
        UserViewModel GetUsersByEmailAndPassword(string email, string password);
        UserViewModel GetUsersByEmail(string email);
        UserViewModel GetuserByUserID(int userID);
    }
}
