using System.Text.Json;
using EDiaristas.Api.Common.Dtos;
using EDiaristas.Api.Common.NamingPolicies;
using EDiaristas.Core.Exceptions;
using EDiaristas.Core.Services.ConsultaEndereco.Exceptions;
using EDiaristas.Core.Services.GatewayPagamento;
using FluentValidation;

namespace EDiaristas.Api.Common.Middlewares;

public class ApiExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public ApiExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance
        };
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/admin"))
        {
            await _next(context);
            return;
        }
        try
        {
            await _next(context);
        }
        catch (ModelNotFoundException ex)
        {
            await handleModelNotFoundException(context, ex);
        }
        catch (CepNotFoundException ex)
        {
            await handleCepNotFoundException(context, ex);
        }
        catch (InvalidCepException ex)
        {
            await handleInvalidCepException(context, ex);
        }
        catch (ValidationException ex)
        {
            await handleValidationException(context, ex);
        }
        catch (UnauthorizedException ex)
        {
            await handleUnauthorizedException(context, ex);
        }
        catch (GatewayPagamentoServiceException ex)
        {
            await handleGatewayPagamentoServiceException(context, ex);
        }
    }

    private Task handleGatewayPagamentoServiceException(HttpContext context, GatewayPagamentoServiceException ex)
    {
        return handleException(context, 400, "Bad Request", ex.GetType().Name, ex.Message);
    }

    private Task handleUnauthorizedException(HttpContext context, UnauthorizedException ex)
    {
        return handleException(context, 403, "Unauthorized", ex.GetType().Name, ex.Message);
    }

    private Task handleValidationException(HttpContext context, ValidationException ex)
    {
        var body = new ValidationErrorResponse
        {
            Status = 400,
            Error = "Bad Request",
            Cause = ex.GetType().Name,
            Message = "Houveram erros de validação",
            Timestamp = DateTime.Now,
            Errors = ex.Errors.GroupBy(vf => vf.PropertyName)
                .ToDictionary(g => g.Key, g => g.Select(vf => vf.ErrorMessage).ToArray())
        };
        context.Response.StatusCode = body.Status;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(JsonSerializer.Serialize(body, _jsonSerializerOptions));
    }

    private Task handleInvalidCepException(HttpContext context, InvalidCepException ex)
    {
        return handleException(context, 400, "Bad Request", ex.GetType().Name, ex.Message);
    }

    private Task handleCepNotFoundException(HttpContext context, CepNotFoundException ex)
    {
        return handleException(context, 404, "Not Found", ex.GetType().Name, ex.Message);
    }

    private Task handleModelNotFoundException(HttpContext context, ModelNotFoundException ex)
    {
        return handleException(context, 404, "Not Found", ex.GetType().Name, ex.Message);
    }

    private Task handleException(HttpContext context, int status, string error, string cause, string message)
    {

        var body = new ErrorResponse
        {
            Status = status,
            Error = error,
            Cause = cause,
            Message = message,
            Timestamp = DateTime.Now
        };
        context.Response.StatusCode = body.Status;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(JsonSerializer.Serialize(body, _jsonSerializerOptions));
    }
}