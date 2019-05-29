using ExperienceManagement.WebUI.Layers.L00_BaseModels.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;


namespace MSHB.ExperienceManagement.Layers.L03.Services.Logger
{
    public static class GlobalExceptionHandler
    {
        private static ILoggerFactory _loggerFactory;

        public static void UseGlobalExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {

                    context.Response.ContentType = "application/json";
                    var ex = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
                    if (ex != null)
                        switch (ex.Error.GetType().Name)
                        {
                            case "ExperienceManagementGlobalException":
                                ExperienceManagementGlobalExceptionHandler(ex, context);
                                break;
                            case "System.AccessViolationException":
                                break;
                            default:
                                DefaultExceptionHandler(ex, context);
                                break;
                        }
                });
            });
        }


        private static async void ExperienceManagementGlobalExceptionHandler(IExceptionHandlerFeature ex, HttpContext context)
        {
            ExperienceManagementGlobalException exception = (ExperienceManagementGlobalException)ex.Error;
            var logger = _loggerFactory.CreateLogger($"{exception.ErrorCode} - GlobalExceptionHandler");
            logger.LogError(context.User.Identity.Name, GetLogMessage(new List<Exception> { exception }));
            List<ExperienceManagementErrorMessage> detailErrorList = GetExceptionErrors(exception.ExceptionList);

            RequestResultViewModel result = new RequestResultViewModel
            {
                Data = null,
                ErrorCode = exception.ErrorCode,
                ErrorMessage = exception.UserMessage,
                DetailErrorList = detailErrorList

            };
            var serializerSetting = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var jsonResult = JsonConvert.SerializeObject(result, serializerSetting);
            context.Response.StatusCode = 501;
            await context.Response.WriteAsync(jsonResult);
        }

        private static async void DefaultExceptionHandler(IExceptionHandlerFeature ex, HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var err = JsonConvert.SerializeObject(new
            {
                ex.Error.StackTrace,
                ex.Error.Message
            });
            await
                context.Response.Body.WriteAsync(Encoding.ASCII.GetBytes(err), 0, err.Length)
                    .ConfigureAwait(false);
        }


        private static List<ExperienceManagementErrorMessage> GetExceptionErrors(List<Exception> exceptions)
        {

            List<ExperienceManagementErrorMessage> detailErrorList = new List<ExperienceManagementErrorMessage>();
            if (exceptions != null && exceptions.Count > 0)
            {
                foreach (Exception ex in exceptions)
                {
                    if (ex is ExperienceManagementGlobalException exception)
                    {
                        detailErrorList.Add(new ExperienceManagementErrorMessage(exception.ErrorCode, exception.UserMessage));

                        detailErrorList.AddRange(GetExceptionErrors(exception.ExceptionList));

                    }
                    else
                    {
                        detailErrorList.Add(new ExperienceManagementErrorMessage("EXC-500", ex.Message));
                    }
                }


            }
            return detailErrorList;
        }

        private static string GetLogMessage(List<Exception> exceptions)
        {

            string logMessage = "";
            if (exceptions != null && exceptions.Count > 0)
            {

                foreach (Exception ex in exceptions)
                {
                    if (ex is ExperienceManagementGlobalException exception)
                    {
                        logMessage = logMessage + exception.ErrorCode + " - " + exception.UserMessage + Environment.NewLine;
                        logMessage = logMessage + exception;
                        logMessage = logMessage + GetLogMessage(exception.ExceptionList);

                    }
                    else
                    {

                        logMessage = logMessage + ex + Environment.NewLine;
                    }
                }

            }
            return logMessage;
        }
    }

}
