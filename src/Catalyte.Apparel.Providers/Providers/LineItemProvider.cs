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
    /// This class provides the implementation of the ILineItemProvider interface, providing service methods for line items.
    /// </summary>
    public class LineItemProvider : ILineItemProvider
    {
        private readonly ILogger<LineItemProvider> _logger;
        private readonly ILineItemRepository _lineItemRepository;

        public LineItemProvider(ILineItemRepository lineItemRepository, ILogger<LineItemProvider> logger)
        {
            _logger = logger;
            _lineItemRepository = lineItemRepository;
        }

        /// <summary>
        /// Asynchronously retrieves line items with the provided product id from the database.
        /// </summary>
        /// <param name="productId">The id of the product used to retrieve line items.</param>
        /// <returns>The line items.</returns>
        public async Task<IEnumerable<LineItem>> GetLineItemsByPatientIdAsync(int patientId)
        {
            IEnumerable<LineItem> lineItems;

            try
            {
                lineItems = await _lineItemRepository.GetLineItemsByPatientIdAsync(patientId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (lineItems == null || lineItems == default)
            {
                _logger.LogInformation($"Line items with product id: {patientId} could not be found.");
                throw new NotFoundException($"Line items with product id: {patientId} could not be found.");
            }
            return lineItems;
        }

        /// <summary>
        /// Asynchronously retrieves all line items from the database.
        /// </summary>
        /// <returns>All line items in the database.</returns>
        public async Task<IEnumerable<LineItem>> GetLineItemsAsync()
        {
            IEnumerable<LineItem> lineItems;

            try
            {
                lineItems = await _lineItemRepository.GetLineItemsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            return lineItems;
        }
    }
}
