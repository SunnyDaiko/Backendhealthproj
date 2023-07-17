using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Models;
using Catalyte.Apparel.Providers.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Providers.Providers
{
    public class PromoCodeProvider : IPromoCodeProvider
    {
        private readonly ILogger _logger;
        private readonly IPromoCodeRepository _promoCodeRepository;

        public PromoCodeProvider(IPromoCodeRepository promoRepository, ILogger<PromoCodeProvider> logger)
        {
            _logger = logger;
            _promoCodeRepository = promoRepository;
        }

        /// <summary>
        /// Persists a new promocode to the database.
        /// </summary>
        /// <param name="promoCode">promocode model used to build the promocode.</param>
        /// <returns>The persisted promocode with IDs.</returns>
        public async Task<PromoCode> CreatePromoCodeAsync(PromoCode promoCode)
        {
            PromoCode promo;
            try
            {
                if (!Regex.IsMatch(promoCode.Title, "^[A-Z0-9]{3,20}$"))
                {

                    throw new AggregateException("Promotional code name must be 3-20 characters long and only contain capital letters and numbers.");
                }
                if (promoCode.Type != "percent" && promoCode.Type != "flat")
                {
                    throw new AggregateException("Promocode type must be either 'percent' or 'flat'.");
                }
                if (promoCode.Rate <= 0)
                {
                    throw new AggregateException("Promocode rate must be a positive number.");
                }
                promo = await _promoCodeRepository.CreatePromoCodesAsync(promoCode);
                return promo;
            }
            catch (AggregateException ex)
            {
                throw new AggregateException(ex.Message);
            }

        }
    }
}