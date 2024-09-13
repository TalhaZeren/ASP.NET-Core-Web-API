using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IQueryable<User> GetAllUsers(bool trackChanges);
        User GetOneUser(int id,bool trackChanges); 
        void CreateOneUser(User user);
        void UpdateOneUser(User user);
        void DeleteOneUser(User user);
    }
}
