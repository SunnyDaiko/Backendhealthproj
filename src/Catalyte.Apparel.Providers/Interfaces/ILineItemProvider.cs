using Catalyte.Apparel.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Providers.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for line item related service methods.
    /// </summary>
    public interface ILineItemProvider
    {
        Task<IEnumerable<LineItem>> GetLineItemsByPatientIdAsync(int patientId);

        Task<IEnumerable<LineItem>> GetLineItemsAsync();
    }
}
