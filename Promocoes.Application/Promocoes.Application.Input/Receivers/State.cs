using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promocoes.Application.Input.Receivers
{
    public class State
    {
        public State(string statusCode, string message, object data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        public string StatusCode { get; private set; }
        public string Message { get; private set; }
        public object Data { get; private set; }
    }
}