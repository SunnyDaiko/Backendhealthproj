﻿using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Providers.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Catalyte.Apparel.Providers
{
    /// <summary>
    /// This class provides configuration options for provider services.
    /// </summary>
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddProviders(this IServiceCollection services)
        {
            services.AddScoped<IPatientProvider, PatientProvider>();
            services.AddScoped<IPurchaseProvider, PurchaseProvider>();
            services.AddScoped<IUserProvider, UserProvider>();
            services.AddScoped<IPromoCodeProvider, PromoCodeProvider>();
            services.AddScoped<IReviewProvider, ReviewProvider>();
            services.AddScoped<ILineItemProvider, LineItemProvider>();

            return services;
        }
    }
}
