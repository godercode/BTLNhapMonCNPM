using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLNhapMonCNPM.Models;

public class Bill
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime Created { set; get; }

    [Required]
    [Range(0.1, Double.MaxValue)]
    public double? Total { get; set; }

    public List<BillDetail> BillDetails { get; } = [];
    public List<Drink> Drinks { get; } = [];
}