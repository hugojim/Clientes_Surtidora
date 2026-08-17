using Clientes.BusinessLogic.Common;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Service.ExcepcionesGlobales

{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "An unhandled exception occurred.");
            var errorResponse = new ErrorResponse
            {
                Mensaje = exception.Message,
            };

            switch (exception)
            {
                case BadHttpRequestException:
                    errorResponse.CodigoEstado = (int)HttpStatusCode.BadRequest;
                    errorResponse.Titulo = exception.GetType().Name;
                    break;

                case DuplicateNameException:
                    errorResponse.CodigoEstado = (int)HttpStatusCode.Conflict;
                    errorResponse.Titulo = exception.GetType().Name;
                    break;


                case InvalidDataException:
                    errorResponse.CodigoEstado = (int)HttpStatusCode.BadRequest;
                    errorResponse.Titulo = exception.GetType().Name;
                    break;

                case MissingFieldException:
                    errorResponse.CodigoEstado = (int)HttpStatusCode.NotFound;
                    errorResponse.Titulo = exception.GetType().Name;
                    break;

                default:
                    errorResponse.CodigoEstado = (int)HttpStatusCode.InternalServerError;
                    errorResponse.Titulo = "Internal Server Error";
                    break;


            }

            httpContext.Response.StatusCode = errorResponse.CodigoEstado;

            await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);

            return true;
        }
    }
}