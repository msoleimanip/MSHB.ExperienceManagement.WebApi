﻿

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L02_DataLayer;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;
using Newtonsoft.Json;
using System;


namespace MSHB.ExperienceManagement.Layers.L03.Services.Logger
{
    public class DbLogger : ILogger
    {
        private readonly Func<string, LogLevel, bool> _filter;
        private readonly string _loggerName;
        private readonly IServiceProvider _serviceProvider;
        private readonly IServiceScopeFactory _scopeFactory;

        

        public DbLogger(
            IServiceProvider serviceProvider,
             IServiceScopeFactory scopeFactory,
            string loggerName,
            Func<string, LogLevel, bool> filter)
        {
            _loggerName = loggerName;
            _scopeFactory = scopeFactory;
            _scopeFactory.CheckArgumentIsNull(nameof(_scopeFactory));


            _filter = filter;
            _filter.CheckArgumentIsNull(nameof(_filter));


            _serviceProvider = serviceProvider;
            _serviceProvider.CheckArgumentIsNull(nameof(_serviceProvider));
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return new NoopDisposable();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _filter(_loggerName, logLevel);
        }

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            var message = formatter(state, exception);

            if (exception != null)
            {
                message = $"{message}{Environment.NewLine}{exception}";
            }

            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            var httpContextAccessor = _serviceProvider.GetRequiredService<IHttpContextAccessor>();
            var appLogItem = new AppLogItem
            {
                Url = httpContextAccessor?.HttpContext != null ? httpContextAccessor.HttpContext.Request.Path.ToString() : string.Empty,
                EventId = eventId.Id,
                LogLevel = logLevel.ToString(),
                Logger = _loggerName,
                Message = message,
                CreatedDateTime = DateTimeOffset.Now
            };
            setStateJson(state, appLogItem);
            saveLogItem(appLogItem);
        }

        private static void setStateJson<TState>(TState state, AppLogItem appLogItem)
        {
            try
            {
                appLogItem.StateJson = JsonConvert.SerializeObject(
                    state,
                    Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        DefaultValueHandling = DefaultValueHandling.Include
                    });
            }
            catch
            {
                // don't throw exceptions from logger
            }
        }

        private void saveLogItem(AppLogItem appLogItem)
        {
            try
            {
                // We need a separate context for the logger to call its SaveChanges several times,
                // without using the current request's context and changing its internal state.
                using (var serviceScope = _scopeFactory.CreateScope())
                {
                    using (var context = serviceScope.ServiceProvider.GetService<ExperienceManagementDbContext>())
                    {
                        context.Set<AppLogItem>().Add(appLogItem);
                        context.SaveChanges();
                    }
                }
                     
            }
            catch
            {
                // don't throw exceptions from logger
            }
        }

        private class NoopDisposable : IDisposable
        {
            public void Dispose()
            {
            }
        }
    }

}
