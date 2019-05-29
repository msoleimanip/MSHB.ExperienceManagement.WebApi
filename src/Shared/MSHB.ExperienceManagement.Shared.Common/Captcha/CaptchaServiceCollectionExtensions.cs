﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MSHB.ExperienceManagement.Shared.Common.Captcha.Contracts;
using MSHB.ExperienceManagement.Shared.Common.Captcha.Providers;

namespace MSHB.ExperienceManagement.Shared.Common.Captcha
{
    /// <summary>
    ///  Captcha ServiceCollection Extensions
    /// </summary>
    public static class CaptchaServiceCollectionExtensions
    {
        
        public static void AddCaptcha(this IServiceCollection services)
        {
            services.CheckArgumentNull(nameof(services));

            services.TryAddSingleton<ICaptchaStorageProvider, CookieCaptchaStorageProvider>();
            services.TryAddSingleton<IHumanReadableIntegerProvider, HumanReadableIntegerProvider>();
            services.TryAddSingleton<IRandomNumberProvider, RandomNumberProvider>();
            services.TryAddSingleton<ICaptchaImageProvider, CaptchaImageProvider>();
            services.TryAddSingleton<ICaptchaProtectionProvider, CaptchaProtectionProvider>();
            services.AddTransient<CaptchaTagHelper>();
        }
    }
}