using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLNhapMonCNPM.Models;

public class BillDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }

    public int BillId { get; set; }

    public int DrinkId { get; set; }

    [Required]
    [Range(0.1, int.MaxValue)]
    public int Quantity { get; set; }

    [Required]
    [Range(0.1, Double.MaxValue)]
    public double? SubTotal { get; set; }

    [Required]
    [Range(0.1, Double.MaxValue)]
    public double? SubTotalCompared { get; set; }

    public Bill Bill { get; set; } = null!;

    public Drink Drink { get; set; } = null!;
}