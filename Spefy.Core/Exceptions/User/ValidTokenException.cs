using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spefy.Core.Exceptions.User
{
    internal class ValidTokenException : CustomException
    {
        public ValidTokenException() : base("Token is valid")
        {

        }
    }
}
