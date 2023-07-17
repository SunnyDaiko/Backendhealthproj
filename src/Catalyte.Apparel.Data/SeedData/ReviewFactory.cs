using Catalyte.Apparel.Data.Models;
using System;
using System.Collections.Generic;

namespace Catalyte.Apparel.Data.SeedData
{
    /// <summary>
    /// This class provides tools for generating reviews for products.
    /// </summary>
    public class ReviewFactory
    {
        Random _rand = new();
        public ReviewFactory() { }

        private List<string> _title = new()
        { "Loved it!", "Great product!", "Highly recommended!", "Satisfied.", "Average quality.", "Not as described.", "Will be returning.", "Disappointed." };

        private List<string> _description = new()
        {
            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibu",
            " "
        };

        ///<summary>
        /// Generates a random review title based on rating.
        /// </summary>
        /// <param name="rating">Rating that corresponds to a title</param>
        /// <returns>A title string.</returns>
        private string GetTitle(double rating)
        {
            if (rating >= 4)
            {
                return _title[_rand.Next(0, 3)];
            }
            else if (rating <= 2)
            {
                return _title[_rand.Next(5, 8)];
            }
            else
            {
                return _title[_rand.Next(3, 5)];
            }
        }

        ///<summary>
        /// Generates a random description or an empty description.
        /// </summary>
        /// <returns>A description string.</returns>
        private string GetDescription()
        {
            return _description[_rand.Next(0, 2)];
        }

        ///<summary>
        /// Generates a random review rating.
        /// </summary>
        /// <returns>A rating double.</returns>
        private double GetRating()
        {
            return _rand.Next(1, 6) + _rand.Next(0, 2) * 0.5;
        }

        /// <summary>
        /// Generates a review for some purchases.
        /// </summary>
        /// <param name="purchases">List of purchases to generate reviews for.</param>
        /// <returns>A list of reviews.</returns>
        public List<Review> GenerateReviewsForPurchases(int numberOfReviews, List<Purchase> purchases)
        {
            List<Review> reviews = new List<Review>();

            for (int i = 0; i < numberOfReviews; i++)
            {
                var review = CreateRandomReview(i + 1, purchases[i].DeliveryFirstName + " " + purchases[i].DeliveryLastName, i + 1);
                reviews.Add(review);
            }

            return reviews;
        }

        /// <summary>
        /// Uses random generators to build a review.
        /// </summary>
        /// <param name="id">ID to assign to the review</param>
        /// <returns>A randomly generated review.</returns>
        private Review CreateRandomReview(int id, String username, int patientId)
        {
            var rating = GetRating();

            return new Review
            {
                Id = id,
                Rating = rating,
                DateCreated = DateTime.UtcNow,
                Title = GetTitle(rating),
                Username = username,
                Description = GetDescription(),
                PatientId = patientId
            };
        }
    }
}
