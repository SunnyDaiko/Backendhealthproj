using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Models;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Providers.Providers;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Microsoft.Extensions.Logging;
using Moq;

namespace Catalyte.Apparel.Test.Unit
{
    public class LineItemUnitTests
    {
        private readonly ILineItemProvider lineItemProvider;
        private readonly Mock<ILineItemRepository> lineItemRepo;
        private readonly Mock<ILogger<LineItemProvider>> logger;

        public LineItemUnitTests()
        {
            lineItemRepo = new Mock<ILineItemRepository>();
            logger = new Mock<ILogger<LineItemProvider>>();
            lineItemProvider = new LineItemProvider(lineItemRepo.Object, logger.Object);
        }

        [Fact]
        public async void GetLineItems_ValidRequest_ReturnsLineItems()
        {
            var expectedLineItems = new List<LineItem>
            {
                new LineItem { Id = 1 },
                new LineItem { Id = 2 }
            };
            lineItemRepo.Setup(r => r.GetLineItemsAsync()).ReturnsAsync(expectedLineItems);
            var result = await lineItemProvider.GetLineItemsAsync();
            Assert.NotNull(result);
            Assert.IsType<List<LineItem>>(result);
            Assert.Equal(expectedLineItems, result);
        }

        [Fact]
        public async void GetProducts_DatabaseException_Returns503()
        {
            lineItemRepo.Setup(r => r.GetLineItemsAsync()).ThrowsAsync(new Exception("test message"));

            await Assert.ThrowsAsync<ServiceUnavailableException>(() => lineItemProvider.GetLineItemsAsync());
        }

        [Fact]
        public async void GetLineItemsByPatientId_ValidProductId_ReturnsLineItems()
        {
            int patientId = 1;
            var expectedLineItems = new List<LineItem>
            {
                new LineItem
                {
                    Id = 1,
                    PatientId = patientId,
                },
                new LineItem
                {
                    Id = 2,
                    PatientId = patientId,
                }
            };

            lineItemRepo.Setup(r => r.GetLineItemsByPatientIdAsync(patientId)).ReturnsAsync(expectedLineItems);
            var result = await lineItemProvider.GetLineItemsByPatientIdAsync(patientId);
            Assert.NotNull(result);
            Assert.IsType<List<LineItem>>(result);
            Assert.Equal(expectedLineItems, result);
        }

        [Fact]
        public async void GetLineItemsByPatientId_DatabaseException_Returns503()
        {
            int patientId = 1;
            lineItemRepo.Setup(r => r.GetLineItemsByPatientIdAsync(patientId)).ThrowsAsync(new Exception("test message"));
            await Assert.ThrowsAsync<ServiceUnavailableException>(() => lineItemProvider.GetLineItemsByPatientIdAsync(patientId));
        }

        [Fact]
        public async void GetLineItemsByPatientId_NoResult_Returns404()
        {
            int patientId = 1;
            lineItemRepo.Setup(r => r.GetLineItemsByPatientIdAsync(patientId)).ReturnsAsync((IEnumerable<LineItem>)null);
            await Assert.ThrowsAsync<NotFoundException>(() => lineItemProvider.GetLineItemsByPatientIdAsync((patientId)));
        }
    }
}
