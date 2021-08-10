using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FilmsAboutBack.Helpers
{
    public class GenericResponse<TValue>
    {
        public TValue Value { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsSucceeded => StatusCode == HttpStatusCode.OK;

        public GenericResponse(TValue response, HttpStatusCode statusCode)
        {
            Value = response;
            StatusCode = statusCode;
        }

        public GenericResponse(string message, HttpStatusCode statusCode)
        {
            ErrorMessage = message;
            StatusCode = statusCode;
        }
    }
}
