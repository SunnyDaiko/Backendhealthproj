using Catalyte.Apparel.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Providers.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for review related service methods.
    /// </summary>
    public interface IReviewProvider
    {
        Task<IEnumerable<Review>> GetReviewsByPatientIdAsync(int patientId);

        Task<IEnumerable<Review>> GetReviewsAsync();
    }
}
