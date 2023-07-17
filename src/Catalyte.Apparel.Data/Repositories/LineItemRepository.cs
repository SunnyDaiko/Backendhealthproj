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
    /// This class handles methods for making requests to the line item repository.
    /// </summary>
    public class LineItemRepository : ILineItemRepository
    {
        private readonly ILogger<LineItemRepository> _logger;
        private readonly IApparelCtx _ctx;

        public LineItemRepository(ILogger<LineItemRepository> logger, IApparelCtx ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        public async Task<IEnumerable<LineItem>> GetLineItemsByPatientIdAsync(int patientId)
        {
            return await _ctx.LineItems
                .Where(x => x.PatientId == patientId)
                .ToListAsync();
        }

        public async Task<IEnumerable<LineItem>> GetLineItemsAsync()
        {
            return await _ctx.LineItems
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
