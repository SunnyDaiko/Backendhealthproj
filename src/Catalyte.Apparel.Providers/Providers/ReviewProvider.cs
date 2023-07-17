using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Models;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Providers.Providers
{
    /// <summary>
    /// This class provides the implementation of the IReviewProvider interface, providing service methods for reviews.
    /// </summary>
    public class ReviewProvider : IReviewProvider
    {
        private readonly ILogger<ReviewProvider> _logger;
        private readonly IReviewRepository _reviewRepository;

        public ReviewProvider(IReviewRepository reviewRepository, ILogger<ReviewProvider> logger)
        {
            _logger = logger;
            _reviewRepository = reviewRepository;
        }

        /// <summary>
        /// Asynchronously retrieves reviews with the provided product id from the database.
        /// </summary>
        /// <param name="productId">The id of the product used to retrieve reviews.</param>
        /// <returns>The reviews.</returns>
        public async Task<IEnumerable<Review>> GetReviewsByPatientIdAsync(int patientId)
        {
            IEnumerable<Review> reviews;

            try
            {
                reviews = await _reviewRepository.GetReviewsByPatientIdAsync(patientId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (reviews == null || reviews == default)
            {
                _logger.LogInformation($"Reviews with product id: {patientId} could not be found.");
                throw new NotFoundException($"Reviews with product id: {patientId} could not be found.");
            }
            return reviews;
        }

        /// <summary>
        /// Asynchronously retrieves all reviews from the database.
        /// </summary>
        /// <returns>All reviews in the database.</returns>
        public async Task<IEnumerable<Review>> GetReviewsAsync()
        {
            IEnumerable<Review> reviews;

            try
            {
                reviews = await _reviewRepository.GetReviewsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return reviews;
        }
    }
}
