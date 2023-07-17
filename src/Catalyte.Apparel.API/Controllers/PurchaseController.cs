using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Catalyte.Apparel.API.DTOMappings;
using Catalyte.Apparel.DTOs.Purchases;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalyte.Apparel.API.Controllers
{
    /// <summary>
    /// The PurchasessController exposes endpoints for purchase related actions.
    /// </summary>
    [ApiController]
    [Route("/purchases")]
    public class PurchaseController : ControllerBase
    {
        private readonly ILogger<PurchaseController> _logger;
        private readonly IPurchaseProvider _purchaseProvider;
        private readonly IMapper _mapper;

        public PurchaseController(
            ILogger<PurchaseController> logger,
            IPurchaseProvider purchaseProvider,
            IMapper mapper
        )
        {
            _logger = logger;
            _purchaseProvider = purchaseProvider;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<PurchaseResponseDTO>>> GetAllPurchasesAsync()
        {
            _logger.LogInformation("Request received for GetAllPurchasesAsync");

            var purchases = await _purchaseProvider.GetAllPurchasesAsync();
            var purchaseResponseDTOs = _mapper.MapPurchasesToPurchaseResponseDTOs(purchases);
            return Ok(purchaseResponseDTOs);
        }

        [HttpPost]
        public async Task<ActionResult<List<PurchaseResponseDTO>>> CreatePurchaseAsync([FromBody] PurchaseRequestDTO model)
        {
            _logger.LogInformation("Request received for CreatePurchase");

            var newPurchase = _mapper.MapCreatePurchaseDTOToPurchase(model);

            try
            {
                var savedPurchase = await _purchaseProvider.CreatePurchaseAsync(newPurchase);
                if (savedPurchase == null)
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
                var purchaseResponseDTO = _mapper.MapPurchaseToPurchaseResponseDTO(savedPurchase);

                if (purchaseResponseDTO != null)
                {
                    return Created($"/purchases/", purchaseResponseDTO);
                }
                return NoContent();
            }
            catch (ServiceUnavailableException ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, ex.Message);
            }
            catch (NullReferenceException ex)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, ex.Message);
            }
        }
    }
}
