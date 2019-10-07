using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using MyApi.Data;
using MyApi.Response;
using MyApi.Utility;
using Newtonsoft.Json;

namespace MyApi.MiddleWare
{
    public class Middleware
    {
        private readonly RequestDelegate _next;
        private string _content = "";
        private BookValidator _validator;
        private ResponseStatus _responseStatus;

        public Middleware(RequestDelegate next)
        {
            _next = next;
            _validator = new BookValidator();
            _responseStatus=ResponseStatus.GetResponse();
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var req = httpContext.Request;
            try
            {
                req.EnableRewind();
            }
            catch
            { }
            using (StreamReader reader
                 = new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
            {
                _content = reader.ReadToEnd();
                if (req.Method.Equals("GET"))
                {
                    string path = req.Path;
                    if (path[path.LastIndexOf("/") + 1].Equals("-"))
                    {
                        _responseStatus.Model = null;
                        _responseStatus.Status.Message = "Invalid Book Id";
                        _responseStatus.Status.StatusCode = 400;
                    }
                }

                if (req.Method.Equals("DELETE"))
                {
                    string path = req.Path;
                    if (path[path.LastIndexOf("/") + 1].Equals("-"))
                    {
                        _responseStatus.Model = null;
                        _responseStatus.Status.Message = "Invalid Book Id";
                        _responseStatus.Status.StatusCode = 400;
                    }
                }

                    if (req.Method.Equals("PUT"))
                {
                    string path = req.Path;
                    if (path[path.LastIndexOf("/") + 1].Equals("-"))
                    {
                        _responseStatus.Model = null;
                        _responseStatus.Status.Message = "Invalid Book Id";
                        _responseStatus.Status.StatusCode = 400;
                    }
                    else
                    {
                        Book book1 = JsonConvert.DeserializeObject<Book>(_content);
                        Debug.WriteLine("Book name is " + book1.Name);
                        List<String> exceptions = new List<string>();
                        if (exceptions.Count == 0)
                        {
                            _responseStatus.Model = book1;
                            _responseStatus.Status.Message = "Everything is Ok..!!";
                            _responseStatus.Status.StatusCode = 200;
                        }
                        else
                        {
                            _responseStatus.Model = null;
                            _responseStatus.Status.Message = string.Join(",", exceptions.ToArray());
                            _responseStatus.Status.StatusCode = 400;
                        }
                    }
                }
                
                 if (req.Method.Equals("POST"))
                 {
                    Debug.WriteLine(_content);
                    Book book1 = JsonConvert.DeserializeObject<Book>(_content);
                    Debug.WriteLine("Book name is " + book1.Name);
                    List<String> exceptions = new List<string>();
                    if (exceptions.Count == 0)
                    {
                        _responseStatus.Model = book1;
                        _responseStatus.Status.Message = "Everything is Ok..!!";
                        _responseStatus.Status.StatusCode = 200;
                    }
                    else
                    {
                        _responseStatus.Model = null;
                        _responseStatus.Status.Message = string.Join(",",exceptions.ToArray());
                        _responseStatus.Status.StatusCode = 400;
                    }
                 }
                req.Body.Position = 0;
                await _next(httpContext);
            }
        }
    }
}
