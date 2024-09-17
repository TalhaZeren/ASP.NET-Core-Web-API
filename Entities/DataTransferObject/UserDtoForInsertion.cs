using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public record UserDtoForInsertion : UserDtoForManipulation // We take properties from abstract
    {                                                          // class which is name "UserDtoForManipulation"

    }                                                      
    
}
