using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public abstract record UserDtoForManipulation           // Validations.
    {
        [Required (ErrorMessage ="Name is a required field.")]
        [MinLength(3,ErrorMessage ="Name must contain at least 3 character.")]
        [MaxLength(20, ErrorMessage = "Name can be contains max 20 character.")] 
        public string Name { get; init; }

        [Required(ErrorMessage = "Surname is a required field.")]
        [MinLength(3, ErrorMessage = "Surname must contain at least 3 character.")]
        [MaxLength(20, ErrorMessage = "Surname can be contains max 20 character.")]
        public string Surname { get; init; }

        [Required(ErrorMessage = "City is a required field.")]
        [MinLength(3, ErrorMessage = "City must contain at least 3 character.")]
        [MaxLength(20,ErrorMessage ="City can be contains max 20 character.")]
        public string City { get; init; }

    }
}
