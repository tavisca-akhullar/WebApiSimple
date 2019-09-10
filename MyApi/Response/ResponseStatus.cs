using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Response
{
    public class ResponseStatus
    {
        private static ResponseStatus Response = null;
        public static ResponseStatus GetResponse()
        {
            if (Response == null)
                Response = new ResponseStatus();
            return Response;
        }
        private ResponseStatus()
        {
            Status = new Status();
        }
        public Object Model { get; set; }
        public Status Status { get; set; }
    }
}