using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserManager : IUserService
    {
        private readonly IRepositoryManager _manager;

        public UserManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public User CreateOneUser(User user)
        {
            if(user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _manager.User.CreateOneUser(user);
            _manager.Save();
            return user;
        }
        public void DeleteOneUser(int id, bool trackChanges)
        {
            // Checking 
            var entity = _manager.User.GetOneUser(id, trackChanges);
            if(entity is null)
            { 
                throw new ArgumentNullException(nameof(entity));
            }
            _manager.User.DeleteOneUser(entity);
            _manager.Save();
        }
        public IEnumerable<User> GetAllUsers(bool trackChanges)
        {
           return _manager.User.GetAllUsers(trackChanges);
        }

        public User GetOneUser(int id, bool trackChanges)
        {
            return _manager.User.GetOneUser(id,trackChanges);
        }

        public void UpdateOneUser(int id, User user, bool trackChanges)
        {
            // check the entity for exsisting 
            var entity = _manager.User.GetOneUser(id, trackChanges);
            if (entity is null)
            {
                throw new ArgumentNullException($" User with id : {id} could not found.");
            }
            if(user  == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            entity.Name = user.Name;
            entity.Surname = user.Surname;
            entity.City = user.City;    

            _manager.User.UpdateOneUser(entity);
            _manager.Save();

        }
    }
}
