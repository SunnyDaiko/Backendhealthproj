using Catalyte.Apparel.Data.Models;
using System;
using System.Collections.Generic;

namespace Catalyte.Apparel.Data.SeedData
{
    /// <summary>
    /// This class provides tools for generating random purchases.
    /// </summary>
    public class PurchaseFactory
    {
        Random _rand = new();

        public PurchaseFactory()
        {
        }

        /// <summary>
        /// Generates a number of random products based on input.
        /// </summary>
        /// <param name="numberOfPurchases">The number of random purchases to generate.</param>
        /// <param name="users">List of users</param>
        /// <returns>A list of random products.</returns>
        public List<Purchase> GenerateRandomPurchases(int numberOfPurchases, List<User> users) 
        {
            var purchaseList = new List<Purchase>();
            for (var i = 0; i < numberOfPurchases; i++)
            {
                purchaseList.Add(CreateRandomPurchase(i+1, users));
            }
            return purchaseList;
        }

        /// <summary>
        /// Uses random generators to build a purchase.
        /// </summary>
        /// <param name="id">ID to assign to the purchase.</param>
        /// <param name="users">List of users</param>
        /// <returns>A randomly generated purchase.</returns>
        private Purchase CreateRandomPurchase(int id, List<User> users)
        {
            var user = users[_rand.Next(users.Count)];

            return new Purchase
            {
                Id = id,
                OrderDate = DateTime.UtcNow,
                BillingStreet = "Sunset Blvd",
                BillingStreet2 = "Apt 2",
                BillingCity = "Baltimore",
                BillingState = "MD",
                BillingZip = "12345",
                BillingEmail = user.Email,
                BillingPhone = "678-999-8212",
                DeliveryFirstName = user.FirstName,
                DeliveryLastName = user.LastName,
                DeliveryStreet = "Ocean Avenue",
                DeliveryStreet2 = "Apt 1",
                DeliveryCity = "Seattle",
                DeliveryState = "WA",
                DeliveryZip = 67890,
                CardNumber = "1234567843218765",
                CVV = 123,
                Expiration = "10/27",
                CardHolder = user.FirstName + " " + user.LastName
            };
        }
    };
};
