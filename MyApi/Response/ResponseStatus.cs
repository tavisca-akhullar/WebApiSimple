using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Response
{
    public class ResponseStatus
    {
        public ResponseStatus()
        {
            Status = new Status();
        }
        public Object Model { get; set; }
        public Status Status { get; set; }
    }
}
