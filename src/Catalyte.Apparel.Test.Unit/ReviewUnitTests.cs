using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Models;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Providers.Providers;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Microsoft.Extensions.Logging;
using Moq;

namespace Catalyte.Apparel.Test.Unit
{
    public class ReviewUnitTests
    {
        private readonly IReviewProvider reviewProvider;
        private readonly Mock<IReviewRepository> reviewRepo;
        private readonly Mock<ILogger<ReviewProvider>> logger;

        public ReviewUnitTests()
        {
            reviewRepo = new Mock<IReviewRepository>();
            logger = new Mock<ILogger<ReviewProvider>>();
            reviewProvider = new ReviewProvider(reviewRepo.Object, logger.Object);
        }

        [Fact]
        public async void GetReviews_ValidRequest_ReturnsReviews()
        {
            var expectedReviews = new List<Review>
            {
                new Review { Id = 1 },
                new Review { Id = 2 }
            };
            reviewRepo.Setup(r => r.GetReviewsAsync()).ReturnsAsync(expectedReviews);
            var result = await reviewProvider.GetReviewsAsync();
            Assert.NotNull(result);
            Assert.IsType<List<Review>>(result);
            Assert.Equal(expectedReviews, result);
        }

        [Fact]
        public async void GetReviews_DatabaseException_Returns503()
        {
            reviewRepo.Setup(r => r.GetReviewsAsync()).ThrowsAsync(new Exception("test message"));

            await Assert.ThrowsAsync<ServiceUnavailableException>(() => reviewProvider.GetReviewsAsync());
        }

        [Fact]
        public async void GetReviewsByPatientId_ValidProductId_ReturnsReviews()
        {
            int patientId = 1;
            var expectedReviews = new List<Review>
            {
                new Review
                {
                    Id = 1,
                    PatientId = patientId,
                },
                new Review
                {
                Id = 2,
                PatientId = patientId,
                }
            };

            reviewRepo.Setup(r => r.GetReviewsByPatientIdAsync(patientId)).ReturnsAsync(expectedReviews);
            var result = await reviewProvider.GetReviewsByPatientIdAsync(patientId);
            Assert.NotNull(result);
            Assert.IsType<List<Review>>(result);
            Assert.Equal(expectedReviews, result);
        }

        [Fact]
        public async void GetReviewsByPatientId_DatabaseException_Returns503()
        {
            int patientId = 1;
            reviewRepo.Setup(r => r.GetReviewsByPatientIdAsync(patientId)).ThrowsAsync(new Exception("test message"));
            await Assert.ThrowsAsync<ServiceUnavailableException>(() => reviewProvider.GetReviewsByPatientIdAsync(patientId));
        }

        [Fact]
        public async void GetReviewsByPatientId_NoResult_Returns404()
        {
            int patientId = 1;
            reviewRepo.Setup(r => r.GetReviewsByPatientIdAsync(patientId)).ReturnsAsync((IEnumerable<Review>)null);
            await Assert.ThrowsAsync<NotFoundException>(() => reviewProvider.GetReviewsByPatientIdAsync((patientId)));
        }
    }
}
