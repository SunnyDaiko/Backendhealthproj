using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Repositories
{
    /// <summary>
    /// This class handles methods for making requests to the review repository.
    /// </summary>
    public class ReviewRepository : IReviewRepository
    {
        private readonly ILogger<ReviewRepository> _logger;
        private readonly IApparelCtx _ctx;

        public ReviewRepository(ILogger<ReviewRepository> logger, IApparelCtx ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        public async Task<IEnumerable<Review>> GetReviewsByPatientIdAsync(int patientId)
        {
            return await _ctx.Reviews
                .Where(r => r.PatientId == patientId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetReviewsAsync()
        {
            return await _ctx.Reviews
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
