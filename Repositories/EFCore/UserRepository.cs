using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext context) : base(context)
        {
        }
        public void CreateOneUser(User user)  => Create(user);
     

        public void DeleteOneUser(User user) => Delete(user);


        public IQueryable<User> GetAllUsers(bool trackChanges) =>
                FindAll(trackChanges);


        public User GetOneUser(int id, bool trackChanges) =>
            FindByCondition(b => b.Id.Equals(id), trackChanges)
            .SingleOrDefault();
        
        public void UpdateOneUser(User user) => Update(user);
      
    }
}
