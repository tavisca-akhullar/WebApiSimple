using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Exceptions
{
    public class InvalidCategoryException:Exception
    {
        public InvalidCategoryException():base("Invalid Category")
        {

        }
    }
}
