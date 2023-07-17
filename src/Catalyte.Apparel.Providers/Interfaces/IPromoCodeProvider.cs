using Catalyte.Apparel.Data.Models;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Providers.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for promocode related service methods.
    /// </summary>
    public interface IPromoCodeProvider
    {
        Task<PromoCode> CreatePromoCodeAsync(PromoCode promoCode);
    }
}
