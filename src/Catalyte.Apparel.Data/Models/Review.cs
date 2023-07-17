using System.ComponentModel.DataAnnotations;

namespace Catalyte.Apparel.Data.Models
{
    /// <summary>
    /// Describes a review object.
    /// </summary>
    public class Review : BaseEntity
    {
        public int PatientId { get; set; }
        public double Rating { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public string Username { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
