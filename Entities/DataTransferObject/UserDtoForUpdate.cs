

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public record UserDtoForUpdate(int Id, string? Name, string? Surname, string? City);
   
}
