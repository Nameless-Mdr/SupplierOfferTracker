using System.Net;
using System.Text.Json;
using Application.Contracts.Exceptions;
using Host.Models.ErrorsModels;
using Microsoft.EntityFrameworkCore;

namespace Host.Middleware;

/// <summary>
/// Глобальный обработчик ошибок.
/// </summary>
public class ErrorHandlerMiddleware(RequestDelegate next)
{
    /// <summary>
    /// Код обработчика.
    /// </summary>
    /// <param name="context">Данные HTTP-запроса.</param>
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            var (httpStatus, result) = GetErrorStatusAndResponse(exception);

            var httpResponse = context.Response;
            httpResponse.ContentType = "application/json";
            httpResponse.StatusCode = (int)httpStatus;
            
            await httpResponse.WriteAsync(JsonSerializer.Serialize(result));
        }
    }

    /// <summary>
    /// Метод обработки различных типов исключений.
    /// </summary>
    /// <param name="exception">Переменная исключения.</param>
    /// <returns>Ответ ошибки.</returns>
    private (HttpStatusCode, ErrorResponse) GetErrorStatusAndResponse(Exception exception)
    {
        HttpStatusCode statusCode;
        ErrorResponse response;

        switch (exception)
        {
            case InvalidFilterException:
                response = new ErrorResponse { Code = "filter_error", Message = exception.Message };
                statusCode = HttpStatusCode.BadRequest;
                break;

            case DbUpdateException:
                response = new ErrorResponse { Code = "database_error", Message = exception.InnerException?.Message ?? exception.Message };
                statusCode = HttpStatusCode.InternalServerError;
                break;

            default:
                response = new ErrorResponse { Code = "error", Message = exception.InnerException?.Message ?? exception.Message };
                statusCode = HttpStatusCode.InternalServerError;
                break;
        }

        return (statusCode, response);
    }
}