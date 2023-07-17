using System;
using System.Threading.Tasks;
using AutoMapper;
using Catalyte.Apparel.API.DTOMappings;
using Catalyte.Apparel.DTOs.PromoCodes;
using Catalyte.Apparel.Providers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalyte.Apparel.API.Controllers
{
    [ApiController]
    [Route("/promocodes")]
    public class PromoCodeController : ControllerBase
    {
        private readonly ILogger<PromoCodeController> _logger;
        private readonly IPromoCodeProvider _promoCodeProvider;
        private readonly IMapper _mapper;

        /// <summary>
        /// The PromoCodeController exposes endpoints for promocode related actions.
        /// </summary>
        public PromoCodeController(IPromoCodeProvider promoCodeProvider, ILogger<PromoCodeController> logger, IMapper mapper)
        {
            _logger = logger;
            _promoCodeProvider = promoCodeProvider;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<PromoCodeDTO>> CreatePromoCodeAsync([FromBody] PromoCodeDTO promoCode)
        {
            _logger.LogInformation("Request received for CreatePromoCode");
            var newPromoCode = _mapper.MapCreatePromoCodeDTOToPromoCode(promoCode);
            try
            {
                var createdPromoCode = await _promoCodeProvider.CreatePromoCodeAsync(newPromoCode);
                return StatusCode(201, createdPromoCode);
            }
            catch (InvalidOperationException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "There was a problem connecting to the database.");
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (AggregateException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
