using System.ComponentModel.DataAnnotations;

namespace EFlowers_Products.Implementation;

public class ProductDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é requerido")]
    [MinLength(2)]
    [MaxLength(60)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "O preço é requerido")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "A descrição é requerida")]
    [MinLength(10)]
    [MaxLength(100)]
    public string? Description { get; set; }

    [Required(ErrorMessage = "O estoque é requerida")]
    [Range(1, 1000)]
    public long Stock { get; set; }
    public string? ImgURL { get; set; }
}
