using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers(bool trackChanges);
        User GetOneUser(int id,bool trackChanges);
        User CreateOneUser(User user);
        void UpdateOneUser(int id,User user,bool trackChanges);
        void DeleteOneUser(int id,bool trackChanges);

    }
}
