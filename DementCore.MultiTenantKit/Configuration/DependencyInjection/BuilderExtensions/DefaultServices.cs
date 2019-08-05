﻿using DementCore.MultiTenantKit.Configuration.Options;
using DementCore.MultiTenantKit.Core.Models;
using DementCore.MultiTenantKit.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DementCore.MultiTenantKit.Configuration.DependencyInjection.BuilderExtensions
{
    public static class DefaultServices
    {

        #region PathResolver

        public static IMultiTenantKitBuilder AddTenantRouteResolverService(this IMultiTenantKitBuilder builder)
        {
            builder.AddTenantRouteResolverService("tenant");

            return builder;
        }

        public static IMultiTenantKitBuilder AddTenantRouteResolverService(this IMultiTenantKitBuilder builder, string routeSegmentName)
        {
            builder.AddTenantRouteResolverService(options =>
            {
                options.RouteSegmentName = routeSegmentName;
            });

            return builder;
        }

        public static IMultiTenantKitBuilder AddTenantRouteResolverService(this IMultiTenantKitBuilder builder, Action<PathResolverOptions> configureOptions)
        {

            if (!builder.Services.Any(x => x.ServiceType == typeof(IConfigureOptions<PathResolverOptions>)))
            {
                builder.Services.Configure(configureOptions);
            }

            builder.Services.TryAddTransient<ITenantResolverService, TenantPathResolverService>();

            return builder;
        }

        #endregion

        #region DomainResolver

        public static IMultiTenantKitBuilder AddTenantDomainResolverService(this IMultiTenantKitBuilder builder)
        {
            builder.AddTenantRouteResolverService("{0}.midomain.com");

            return builder;
        }

        public static IMultiTenantKitBuilder AddTenantDomainResolverService(this IMultiTenantKitBuilder builder, string domainTemplate)
        {
            builder.AddTenantDomainResolverService(options =>
            {
                options.DomainTemplate = domainTemplate;
            });

            return builder;
        }

        public static IMultiTenantKitBuilder AddTenantDomainResolverService(this IMultiTenantKitBuilder builder, Action<HostResolverOptions> configureOptions)
        {

            if (!builder.Services.Any(x => x.ServiceType == typeof(IConfigureOptions<HostResolverOptions>)))
            {
                builder.Services.Configure(configureOptions);
            }

            builder.Services.TryAddTransient<ITenantResolverService, TenantHostResolverService>();

            return builder;
        }

        #endregion

        #region ClaimsResolver

        #endregion

        public static IMultiTenantKitBuilder AddDefaultTenantMapperService<TTenantSlugs>(this IMultiTenantKitBuilder builder)
            where TTenantSlugs : ITenantSlugs
        {
            builder.Services.TryAddTransient<ITenantMapperService, TenantMapperService<TTenantSlugs>>();

            return builder;
        }

        public static IMultiTenantKitBuilder AddDefaultTenantInfoService<TTenant>(this IMultiTenantKitBuilder builder)
            where TTenant : ITenant
        {
            builder.Services.TryAddTransient<ITenantInfoService<TTenant>, TenantInfoService<TTenant>>();

            return builder;
        }

        public static IMultiTenantKitBuilder AddDefaultTenantProviderService<TTenant>(this IMultiTenantKitBuilder builder)
            where TTenant : ITenant
        {
            builder.Services.TryAddScoped<ITenantProvider<TTenant>, TenantProviderService<TTenant>>();

            return builder;
        }

    }
}
