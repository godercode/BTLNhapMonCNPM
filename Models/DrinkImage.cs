using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLNhapMonCNPM.Models;

public class DrinkImage
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }

    [StringLength(255)]
    public string? Url { get; set; }

    public int DrinkId { get; set; }

    public Drink Drink = null!;
}