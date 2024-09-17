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

        public UserDto CreateOneUser(UserDtoForInsertion userDtoInsert)
        {
            if(userDtoInsert is null)
            {
                throw new ArgumentNullException(nameof(userDtoInsert));
            }
           var entity =  _mapper.Map<User>(userDtoInsert);
            _manager.User.CreateOneUser(entity); // Saved to database and after that; 
            _manager.Save();
            return _mapper.Map<UserDto>(entity); // returned UserDto to View certain
                                                 // data from service to contoller.
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
        public IEnumerable<UserDto> GetAllUsers(bool trackChanges)
        {
           var user = _manager.User.GetAllUsers(trackChanges);
           return _mapper.Map<IEnumerable<UserDto>>(user);  
        }

        public UserDto GetOneUser(int id, bool trackChanges)
        {

            var  user = _manager.User.GetOneUser(id,trackChanges);
            if(user is null)
            {
                throw new UserNotFoundException(id);
            }
           return _mapper.Map<UserDto>(user);
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
            // instead of these; AutoMapper was used.

            entity = _mapper.Map<User>(userDto); // Auto Mapping is completing...

            _manager.User.UpdateOneUser(entity);
            _manager.Save();

        }
    }
}
