using AutoMapper;
using Entities.DataTransferObject;
using Entities.Exceptions;
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
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public UserManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
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
                throw new UserNotFoundException(id);
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

            var  user = _manager.User.GetOneUser(id,trackChanges);
            if(user is null)
            {
                throw new UserNotFoundException(id);
            }
            return user;    
        }

        public void UpdateOneUser(int id, UserDtoForUpdate userDto, bool trackChanges)
        {
            // check the entity for exsisting 
            var entity = _manager.User.GetOneUser(id, trackChanges);
            if (entity is null)
            {
                throw new UserNotFoundException(id);
            }
            
            //entity.Name = user.Name;
            //entity.Surname = user.Surname;
            //entity.City = user.City;    

            entity = _mapper.Map<User>(userDto); // Auto Mapping is completing...

            _manager.User.UpdateOneUser(entity);
            _manager.Save();

        }
    }
}
