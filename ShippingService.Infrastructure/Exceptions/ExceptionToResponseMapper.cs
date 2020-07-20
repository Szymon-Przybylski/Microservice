using System;
using System.Net;
using Convey.WebApi.Exceptions;
using ShippingService.Application.Exceptions;
using ShippingService.Core.Exceptions.Abstract;

namespace ShippingService.Infrastructure.Exceptions
{
    public class ExceptionToResponseMapper : IExceptionToResponseMapper
    {
        public ExceptionResponse Map(Exception exception) => exception switch
        {
            DomainException ex => new ExceptionResponse(new {code = ex.Code, reason = ex.Message}, HttpStatusCode.BadRequest),
            AppException ex => new ExceptionResponse(new {code = ex.Code, reason = ex.Message}, HttpStatusCode.BadRequest),
            _ => new ExceptionResponse(new {code = "error", reason = "There was an error"},HttpStatusCode.InternalServerError)
        };
    }
}