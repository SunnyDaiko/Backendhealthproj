using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Models;
using Catalyte.Apparel.Providers.Providers;
using Microsoft.Extensions.Logging;
using Moq;


namespace Catalyte.Apparel.Test.Unit
{

    public class PromoCodeUnitTests
    {
        private Mock<IPromoCodeRepository>? _promoCodeRepositoryMock;
        private Mock<ILogger<PromoCodeProvider>>? _loggerMock;

        private PromoCodeProvider _promoCodeProvider;
        public PromoCodeUnitTests()
        {
            _promoCodeRepositoryMock = new Mock<IPromoCodeRepository>();
            _loggerMock = new Mock<ILogger<PromoCodeProvider>>();
            _promoCodeProvider = new PromoCodeProvider(_promoCodeRepositoryMock.Object, _loggerMock.Object);
        }
        [Fact]
        public async Task CreatePromoCodeAsync_ValidPromoCode_ReturnsPromoCode()
        {
            PromoCode promoCode = new PromoCode
            {
                Title = "ABC123",
                Type = "percent",
                Rate = 10
            };
            _promoCodeRepositoryMock?.Setup(x => x.CreatePromoCodesAsync(promoCode)).ReturnsAsync(promoCode);
            var result = await _promoCodeProvider.CreatePromoCodeAsync(promoCode);
            Assert.Equal(promoCode, result);
        }

        [Fact]
        public async Task CreatePromoCodeAsync_InvalidType_ThrowsAggregateException()
        {
            var promoCode = new PromoCode
            {
                Title = "ABC123",
                Type = "invalid",
                Rate = 10
            };
            _promoCodeRepositoryMock?.Setup(x => x.CreatePromoCodesAsync(promoCode)).ReturnsAsync(promoCode);
            await Assert.ThrowsAsync<AggregateException>(() => _promoCodeProvider.CreatePromoCodeAsync(promoCode));
        }

        [Fact]
        public async Task CreatePromoCodeAsync_InvalidRate_ThrowsAggregateException()
        {
            var promoCode = new PromoCode
            {
                Title = "ABC123",
                Type = "percent",
                Rate = -10
            };
            _promoCodeRepositoryMock?.Setup(x => x.CreatePromoCodesAsync(promoCode)).ReturnsAsync(promoCode);
            await Assert.ThrowsAsync<AggregateException>(() => _promoCodeProvider.CreatePromoCodeAsync(promoCode));
        }

        [Fact]
        public async Task CreatePromoCodeAsync_NullPromoCode_ThrowsArgumentNullException()
        {
            var promoCode = new PromoCode
            {
                Title = null,
                Type = null,
                Rate = 10
            };
            _promoCodeRepositoryMock?.Setup(x => x.CreatePromoCodesAsync(promoCode)).ReturnsAsync(promoCode);
            await Assert.ThrowsAsync<ArgumentNullException>(() => _promoCodeProvider.CreatePromoCodeAsync(promoCode));
        }

        [Fact]
        public async Task CreatePromoCodeAsync_ServiceUnavailable_ThrowsInvalidOperationException()
        {
            var exceptionMessage = "There was a problem connecting to the database.";
            var promoCode = new PromoCode
            {
                Title = "ABC123",
                Type = "percent",
                Rate = 10
            };
            _promoCodeRepositoryMock?.Setup(x => x.CreatePromoCodesAsync(promoCode)).ThrowsAsync(new InvalidOperationException(exceptionMessage));
            await Assert.ThrowsAsync<InvalidOperationException>(() => _promoCodeProvider.CreatePromoCodeAsync(promoCode));
        }
    }
}