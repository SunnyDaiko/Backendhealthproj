using Catalyte.Apparel.Data.Models;
using System;
using System.Collections.Generic;


namespace Catalyte.Apparel.Data.SeedData
{
    /// <summary>
    /// This class provides tools for generating line items for valid purchases.
    /// </summary>
    public class LineItemFactory
    {
        /// <summary>
        /// Generates a number of line items based on input.
        /// </summary>
        /// <param name="numberOfLineItems">The number of line items to generate.</param>
        /// <returns>A list of random products.</returns>
        public List<LineItem> GenerateLineItems(int numberOfLineItems)
        {
            var lineItemList = new List<LineItem>();
            for (var i = 0; i < numberOfLineItems; i++)
            {
                lineItemList.Add(CreateLineItem(i + 1));
            }

            return lineItemList;
        }

        /// <summary>
        /// Creates a single line item.
        /// </summary>
        /// <param name="id">ID to assign to the line item.</param>
        /// <returns>A line item.</returns>
        private LineItem CreateLineItem(int id)
        {
            return new LineItem
            {
                Id = id,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                PurchaseId = id,
                PatientId = id,
                Quantity = 1,
            };
        }
    }
}

