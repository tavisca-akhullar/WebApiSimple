﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Exceptions
{
    public class InvalidIdException:Exception
    {
        public InvalidIdException(): base("Invalid Id")
        {

        }
    }
}