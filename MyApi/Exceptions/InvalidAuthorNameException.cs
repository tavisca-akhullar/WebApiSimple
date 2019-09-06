using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Exceptions
{
    public class InvalidAuthorNameException:Exception
    {
        public InvalidAuthorNameException(): base("Invalid AuthorName")
        {
                
        }
    }
}
