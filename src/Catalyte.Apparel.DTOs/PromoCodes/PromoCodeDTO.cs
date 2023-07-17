using System.ComponentModel.DataAnnotations;

namespace Catalyte.Apparel.DTOs.PromoCodes
{
    public class PromoCodeDTO
    {
        [MinLength(3), MaxLength(20)]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public float Rate { get; set; }
    }
}
