//using DrakionTech.Crm.Business.Exceptions;
//using System.Net;
//using System.Text.Json;

//namespace DrakionTech.Crm.Web.Middlewares
//{
//    public class ExceptionHandlingMiddleware
//    {
//        private readonly RequestDelegate _next;
//        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

//        public ExceptionHandlingMiddleware(
//            RequestDelegate next,
//            ILogger<ExceptionHandlingMiddleware> logger)
//        {
//            _next = next;
//            _logger = logger;
//        }

//        public async Task InvokeAsync(HttpContext context)
//        {
//            try
//            {
//                await _next(context);
//            }
//            catch (DomainException ex)
//            {
//                _logger.LogWarning(ex, ex.Message);
//                await HandleDomainExceptionAsync(context, ex);
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error no controlado");
//                await HandleUnexpectedExceptionAsync(context);
//            }
//        }

//        private static Task HandleDomainExceptionAsync(
//            HttpContext context,
//            DomainException exception)
//        {
//            var (statusCode, message) = exception switch
//            {
//                EntidadNoEncontradaException => (HttpStatusCode.NotFound, exception.Message),
//                ReglaNegocioException => (HttpStatusCode.BadRequest, exception.Message),
//                OperacionNoPermitidaException => (HttpStatusCode.Forbidden, exception.Message),
//                _ => (HttpStatusCode.BadRequest, "Error de negocio")
//            };

//            context.Response.ContentType = "application/json";
//            context.Response.StatusCode = (int)statusCode;

//            var response = JsonSerializer.Serialize(new
//            {
//                error = message
//            });

//            return context.Response.WriteAsync(response);
//        }

//        private static Task HandleUnexpectedExceptionAsync(HttpContext context)
//        {
//            context.Response.ContentType = "application/json";
//            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

//            var response = JsonSerializer.Serialize(new
//            {
//                error = "Ha ocurrido un error inesperado"
//            });

//            return context.Response.WriteAsync(response);
//        }
//    }
//}