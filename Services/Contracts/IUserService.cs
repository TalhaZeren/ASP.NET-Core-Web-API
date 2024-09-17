using Entities.DataTransferObject;
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
        IEnumerable<UserDto> GetAllUsers(bool trackChanges);
        UserDto GetOneUser(int id,bool trackChanges);
        UserDto CreateOneUser(UserDtoForInsertion userDtoInsertion);
        void UpdateOneUser(int id,UserDtoForUpdate userDto,bool trackChanges);
        void DeleteOneUser(int id,bool trackChanges);

        (UserDtoForUpdate userDtoForUpdate, User user) GetOneUserForPatch(int id,bool trackChanges);    

        void SaveChangesForPatch(UserDtoForUpdate userDtoForUpdate, User user);

    }
}
