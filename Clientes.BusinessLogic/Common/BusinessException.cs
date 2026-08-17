using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.BusinessLogic.Common
{
    public class BusinessException : Exception
    {
        public int StatusCode { get; }

        public BusinessException(
            string message,
            int statusCode = StatusCodes.Status400BadRequest)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }

    public class ClienteNoEncontradoException : BusinessException
    {
        public ClienteNoEncontradoException(string mensaje)
            : base(
                mensaje,
                StatusCodes.Status404NotFound)
        {
        }
    }

    public class CorreoDuplicadoException : BusinessException
    {
        public CorreoDuplicadoException(string mensaje)
            : base(
                mensaje,
                 (int)HttpStatusCode.Conflict)
        {
        }
    }
}
