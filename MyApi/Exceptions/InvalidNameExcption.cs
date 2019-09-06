using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Exceptions
{
    public class InvalidNameExcption:Exception
    {
        public InvalidNameExcption():base("Invalid Name")
        {

        }
    }
}
