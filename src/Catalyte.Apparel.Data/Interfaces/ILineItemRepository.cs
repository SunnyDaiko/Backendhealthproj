using Catalyte.Apparel.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Catalyte.Apparel.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for line item repository methods.
    /// </summary>
    public interface ILineItemRepository
    {
        Task<IEnumerable<LineItem>> GetLineItemsByPatientIdAsync(int patientId);

        Task<IEnumerable<LineItem>> GetLineItemsAsync();
    }
}
