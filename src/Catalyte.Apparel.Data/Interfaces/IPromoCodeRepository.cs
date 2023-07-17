using Catalyte.Apparel.Data.Models;
using Catalyte.Apparel.DTOs.PromoCodes;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for promocode repository methods.
    /// </summary>
    public interface IPromoCodeRepository
    {
        Task<PromoCode> CreatePromoCodesAsync(PromoCode promoCode);
        Task CreatePromoCodesAsync(PromoCodeDTO promoCode);
    }
}
