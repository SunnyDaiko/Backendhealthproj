using System;

namespace Catalyte.Apparel.DTOs.Products
{
    /// <summary>
    /// Describes a data transfer object for a review.
    /// </summary>
    public class ReviewDTO
    {
        public double Rating { get; set; }
        public DateTime DateCreated { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        public int PatientId { get; set; }
    }
}
