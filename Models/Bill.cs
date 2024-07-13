using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLNhapMonCNPM.Models;

public class Bill
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public DateTime Created { set; get; }

    [Required]
    [Range(0.1, Double.MaxValue)]
    public double? Total { get; set; }

    [Required]
    [Range(0.1, Double.MaxValue)]
    public double? ComparedTotal { get; set; }

    public List<BillDetail> BillDetails { get; } = [];
    public List<Drink> Drinks { get; } = [];

    public Bill()
    {
        Created = DateTime.UtcNow;
    }
}