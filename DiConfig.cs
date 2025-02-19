﻿using System.Collections.Generic;
using System.Globalization;
using Localization.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;

namespace Localization
{
    public static class DiConfig
    {
        public static void UseConfiguration(this IServiceCollection services)
        {
            services.Configure<RequestLocalizationOptions>(o =>
            {
                var supportedCultures = new List<CultureInfo>()
                {
                    new CultureInfo("en"),
                    new CultureInfo("ne-NP")
                };
                o.DefaultRequestCulture = new RequestCulture("en");
                o.SupportedCultures = supportedCultures;
                o.SupportedUICultures = supportedCultures;
            });
            services.AddControllersWithViews().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(o =>
                {
                    o.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(SharedResource));
                });
        }
    }
}