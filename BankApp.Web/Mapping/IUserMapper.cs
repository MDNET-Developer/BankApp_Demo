using BankApp.Web.Data.Entities;
using BankApp.Web.Models;
using System.Collections.Generic;

namespace BankApp.Web.Mapping
{
    public interface IUserMapper
    {
        public List<UserListViewModel> MapToListOfUserList(List<ApplicationUser> applicationUsers);
        public UserListViewModel MapToUserList(ApplicationUser applicationUsers);
    }
}
