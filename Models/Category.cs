using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLNhapMonCNPM.Models;

public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }


    [Required]
    public string? Name { get; set; }

    public List<Drink> Drinks { get; } = [];
}
