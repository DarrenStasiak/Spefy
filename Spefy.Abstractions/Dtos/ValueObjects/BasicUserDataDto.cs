using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spefy.Contract.Dtos.ValueObjects
{
    public class BasicUserDataDto
    {
        public string Id { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }

        public BasicUserDataDto()
        {

        }
        public BasicUserDataDto(string id, string country, string email)
        {
            Id = id;
            Country = country;
            Email = email;
        }
    }
}
