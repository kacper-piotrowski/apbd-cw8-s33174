using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCsAPI.Entities;

public class PC
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string Name { get; set; } = String.Empty;
    
    [Column(TypeName = "float(5)")]
    public float Weight { get; set; }
    
    public int Warranty { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public int Stock { get; set; }

    public ICollection<PCComponent> PcComponents { get; set; } = [];
}