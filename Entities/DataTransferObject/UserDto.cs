using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public record UserDto   // if it it defined like this. not need to define [Serializable]
    {
        public int Id { get; init; }
        public string? Name { get; init; }   
        public string? Surname { get; init; }
        public string? City { get; init; }

    }
}
