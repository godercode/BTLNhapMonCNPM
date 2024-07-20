using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLNhapMonCNPM.Models;

public class Drink
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }

    [Required]
    [StringLength(255)]
    public string? Name { get; set; }

    [Required]
    [Range(0.1, Double.MaxValue)]
    public double? Price { get; set; }

    [Required]
    [Range(0.1, Double.MaxValue)]
    public double? ComparedPrice { get; set; }

    [Required]
    [StringLength(255)]
    public string? Description { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public Category Category = null!;

    public ICollection<DrinkImage> Images { get; set; } = new List<DrinkImage>();

    public List<BillDetail> BillDetails { get; } = [];

    public List<Bill> Bills { get; } = [];
}
