using System.ComponentModel.DataAnnotations;

namespace EFlowers.Web.Implementation
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public long Stock { get; set; }

        [Required]
        public string? ImgURL { get; set; }
    }
}
