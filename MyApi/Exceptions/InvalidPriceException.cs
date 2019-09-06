using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Exceptions
{
    public class InvalidPriceException:Exception
    {
        public InvalidPriceException():base("Invalid Price")
        {

        }
    }
}
