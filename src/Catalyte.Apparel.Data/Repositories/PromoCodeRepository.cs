using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Models;
using Catalyte.Apparel.DTOs.PromoCodes;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Repositories
{
    /// <summary>
    /// This class handles methods for making requests to the promocode repository.
    /// </summary>
    public class PromoCodeRepository : IPromoCodeRepository
    {
        private readonly IApparelCtx _ctx;

        public PromoCodeRepository(IApparelCtx ctx)
        {
            _ctx = ctx;
        }

        public async Task<PromoCode> CreatePromoCodesAsync(PromoCode promoCode)
        {
            await _ctx.PromoCodes.AddAsync(promoCode);
            await _ctx.SaveChangesAsync();

            return promoCode;
        }

        public Task CreatePromoCodesAsync(PromoCodeDTO promoCode)
        {
            throw new System.NotImplementedException();
        }
    }
}