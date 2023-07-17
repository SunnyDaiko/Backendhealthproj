using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Catalyte.Apparel.DTOs.Purchases;
using Catalyte.Apparel.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalyte.Apparel.API.Controllers
{
    /// <summary>
    /// The LineItemController exposes endpoints for line item related actions.
    /// </summary>
    [ApiController]
    [Route("/lineitems")]
    public class LineItemController : ControllerBase
    {
        private readonly ILogger<LineItemController> _logger;
        private readonly ILineItemProvider _lineItemProvider;
        private readonly IMapper _mapper;

        public LineItemController(
            ILogger<LineItemController> logger, ILineItemProvider lineItemProvider, IMapper mapper)
        {
            _logger = logger;
            _lineItemProvider = lineItemProvider;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LineItemDTO>>> GetLineItemsAsync()
        {
            _logger.LogInformation("Request received for GetLineItemsAsync");

            var lineItems = await _lineItemProvider.GetLineItemsAsync();
            var lineItemDTOs = _mapper.Map<IEnumerable<LineItemDTO>>(lineItems);

            return Ok(lineItemDTOs);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<IEnumerable<LineItemDTO>>> GetLineItemsByPatientIdAsync(int patientId)
        {
            _logger.LogInformation($"Request received for GetLineItemsByProductIdAsync for product id: {patientId}");

            var lineItems = await _lineItemProvider.GetLineItemsByPatientIdAsync(patientId);
            var lineItemDTOs = _mapper.Map<IEnumerable<LineItemDTO>>(lineItems);

            return Ok(lineItemDTOs);
        }

    }
}
