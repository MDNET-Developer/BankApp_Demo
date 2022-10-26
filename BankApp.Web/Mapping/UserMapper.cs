using BankApp.Web.Data.Entities;
using BankApp.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace BankApp.Web.Mapping
{
    public class UserMapper:IUserMapper
    {
        public List<UserListViewModel> MapToListOfUserList(List<ApplicationUser> applicationUsers)
        {
           return applicationUsers.Select(x => new UserListViewModel
            {
                MId=x.Id,
                MName=x.Name,
                MSurname=x.Surname
            }).ToList();

        }

        public UserListViewModel MapToUserList(ApplicationUser applicationUsers)
        {
            return new UserListViewModel
            {
                MId = applicationUsers.Id,
                MName = applicationUsers.Name,
                MSurname = applicationUsers.Surname
            };

        }
    }
}
