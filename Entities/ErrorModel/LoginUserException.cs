using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ErrorModel
{
    public class LoginUserException : UserException
    {
        public LoginUserException() : base("Incorrect login or password.")
        {
        }
    }
}
