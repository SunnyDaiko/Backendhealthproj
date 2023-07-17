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
    /// This class provides the implementation of the IPurchaseProvider interface, providing service methods for purchases.
    /// </summary>
    public class PurchaseProvider : IPurchaseProvider
    {
        private readonly ILogger<PurchaseProvider> _logger;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IPatientRepository _patientRepository;

        public PurchaseProvider(IPurchaseRepository purchaseRepository, IPatientRepository patientRepository, ILogger<PurchaseProvider> logger)
        {
            _logger = logger;
            _purchaseRepository = purchaseRepository;
            _patientRepository = patientRepository;
        }

        /// <summary>
        /// Retrieves all purchases from the database.
        /// </summary>
        /// <returns>All purchases.</returns>
        public async Task<IEnumerable<Purchase>> GetAllPurchasesAsync()
        {
            List<Purchase> purchases;

            try
            {
                purchases = await _purchaseRepository.GetAllPurchasesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return purchases;
        }

        /// <summary>
        /// Persists a purchase to the database.
        /// </summary>
        /// <param name="newPurchase">Purchase model used to build the purchase.</param>
        /// <returns>The persisted purchase with IDs.</returns>
        public async Task<Purchase> CreatePurchaseAsync(Purchase newPurchase)
        {
            try
            {
                if (newPurchase != null && newPurchase.LineItems != null && newPurchase.LineItems.Count > 0)
                {
                    List<string> inactiveProducts = new List<string>();
                    foreach (var lineItem in newPurchase.LineItems)
                    {
                        int Id = lineItem.PatientId;
                        Patient targetedPatient = await _patientRepository.GetPatientByIdAsync(Id);
                        if (targetedPatient.FirstName == "lol")
                        {
                            string TpName = targetedPatient.FirstName + " " + targetedPatient.LastName + " " + targetedPatient.Insurance;
                            _logger.LogInformation($"Product with id: {Id} is invalid.");
                            inactiveProducts.Add(TpName);

                        }
                    }
                    string Iap = string.Join(", ", inactiveProducts);
                    if (inactiveProducts.Count > 0)
                    {
                        foreach (var product in inactiveProducts)
                        {
                            throw new InvalidOperationException($"The following products are inactive: {Iap}");
                        }

                    }
                    return await _purchaseRepository.CreatePurchaseAsync(newPurchase);
                }
            }
            catch (NullReferenceException ex)
            {
                _logger?.LogError(ex.Message);
                throw new InvalidOperationException("invalid purchase data");
            }
            catch (ServiceUnavailableException ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            return null;
        }
    }
}
