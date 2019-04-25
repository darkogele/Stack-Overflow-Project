using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverFlowProjectDomainModels;
using StackOverflowProjectViewModels;
using StackOverflowProjectRepositories;
using AutoMapper.Configuration;
using StackOverflowProjectServiceLayer.Interfaces;
using StackOverflowProjectRepositories.Interfaces;
using AutoMapper;

namespace StackOverflowProjectServiceLayer
{
    public class UserService : IUSerService
    {
        IUsersRepository _ur;
        public UserService(IUsersRepository ur)
        {
            _ur = ur;
        }

        public void DeleteUser(int uid)
        {
            _ur.DeleteUser(uid);
        }

        public UserViewModel GetuserByUserID(int userID)
        {
            throw new NotImplementedException();
        }

        public List<UserViewModel> GetUsers()
        {
            throw new NotImplementedException();
        }

        public UserViewModel GetUsersByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public UserViewModel GetUsersByEmailAndPassword(string email, string password)
        {
            throw new NotImplementedException();
        }

        public int InsertUser(RegisterViewModel uvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<RegisterViewModel, User>(); cfg.IgnoreUnmapped();});
            IMapper mapper = config.CreateMapper();
            var u = mapper.Map<RegisterViewModel, User>(uvm);
            u.PasswordHash = SHA256HashGenerator.GenerateHash(uvm.Password);
            _ur.InsertUser(u);
            int uid = _ur.GetlatestuserID();
            return uid;
        }

        public void UpdateUserDetails(EditUserDetailsViewModel uvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditUserDetailsViewModel, User>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            var u = mapper.Map<EditUserDetailsViewModel, User>(uvm);
            _ur.UpdateUserDetails(u);
        }

        public void UpdateUserPassword(EditUserPasswordViewModel uvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditUserPasswordViewModel, User>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            var u = mapper.Map<EditUserPasswordViewModel, User>(uvm);
            u.PasswordHash = SHA256HashGenerator.GenerateHash(uvm.Password);
            _ur.UpdateUserPassword(u);
        }
    }
}
