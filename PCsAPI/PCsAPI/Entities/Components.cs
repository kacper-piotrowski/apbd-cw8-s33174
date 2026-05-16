using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCsAPI.Entities;

public class Component
{
    [Column(TypeName = "char(10)")]
    [MaxLength(10)]
    [Key]
    public string Code { get; set; } = String.Empty;
    
    [MaxLength(300)]
    public string Name { get; set; } = String.Empty;
    
    public string Description { get; set; } = String.Empty;
    
    public int ComponentManufacturersId { get; set; }
    
    public int ComponentTypesId { get; set; }
    
    [ForeignKey(nameof(ComponentTypesId))]
    public ComponentType ComponentType { get; set; }
    
    [ForeignKey(nameof(ComponentManufacturersId))]
    public ComponentManufacturer ComponentManufacturer { get; set; }
    
    public ICollection<PCComponent> PcComponents { get; set; } = [];
}