using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ErrorModel
{
    public class RegisterUserException : UserException
    {
        public RegisterUserException() : base("Something went wrong... Can't register.")
        {
        }
    }
}
