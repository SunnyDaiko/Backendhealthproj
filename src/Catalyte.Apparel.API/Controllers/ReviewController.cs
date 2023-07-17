using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Catalyte.Apparel.DTOs.Products;
using Catalyte.Apparel.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalyte.Apparel.API.Controllers
{
    /// <summary>
    /// The ReviewController exposes endpoints for review related actions.
    /// </summary>
    [ApiController]
    [Route("/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly ILogger<ReviewController> _logger;
        private readonly IReviewProvider _reviewProvider;
        private readonly IMapper _mapper;

        public ReviewController(
            ILogger<ReviewController> logger,
            IReviewProvider reviewProvider,
            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _reviewProvider = reviewProvider;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetReviewsAsync()
        {
            _logger.LogInformation("Request received for GetProductsAsync");

            var reviews = await _reviewProvider.GetReviewsAsync();
            var reviewDTOs = _mapper.Map<IEnumerable<ReviewDTO>>(reviews);

            return Ok(reviewDTOs);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetReviewsByPatientIdAsync(int patientId)
        {
            _logger.LogInformation($"Request received for GetReviewsByProductIdAsync for product id: {patientId}");

            var reviews = await _reviewProvider.GetReviewsByPatientIdAsync(patientId);
            var reviewDTOs = _mapper.Map<IEnumerable<ReviewDTO>>(reviews);

            return Ok(reviewDTOs);
        }
    }
}
