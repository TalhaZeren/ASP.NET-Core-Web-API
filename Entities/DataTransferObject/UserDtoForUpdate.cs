

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public record UserDtoForUpdate : UserDtoForManipulation  // Abstract class was implemented. Abstract class is not
    {                                                           // gotten "new" and not used any classes directly.
                                                                // But it can be implemented.
        [Required]
        public int Id { get; set; }
    }                                                    

}
