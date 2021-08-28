using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NumberDecompose.CrossCutting.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace NumberDecompose.CrossCutting.Helper
{
    public class ExceptionHelper
    {
        private readonly RequestDelegate _next;

        public ExceptionHelper(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleException(context, e);
            }
        }

        private static Task HandleException(HttpContext context, Exception exception)
        {
            HttpStatusCode code;
            object response = exception.Message;

            switch (exception)
            {
                case EntityValidationException _:
                    code = HttpStatusCode.BadRequest;
                    response = new ErrorMessageModel($"Requisição inválida: {exception.Message}");
                    break;

                case NotFoundException _:
                    code = HttpStatusCode.NotFound;
                    response = new ErrorMessageModel("Registro não encontrado");
                    break;

                default:
                    code = HttpStatusCode.InternalServerError;
                    response = new ErrorMessageModel($"Erro: {exception.Message}");
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = Convert.ToInt32(code);

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }));
        }
    }
}