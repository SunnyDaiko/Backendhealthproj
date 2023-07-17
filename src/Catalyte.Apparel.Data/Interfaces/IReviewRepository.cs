using Catalyte.Apparel.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for review repository methods.
    /// </summary>
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetReviewsByPatientIdAsync(int patientId);

        Task<IEnumerable<Review>> GetReviewsAsync();
    }
}