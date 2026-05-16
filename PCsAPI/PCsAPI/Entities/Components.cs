using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCsAPI.Entities;

public class Components
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
    public ComponentTypes ComponentType { get; set; }
    
    [ForeignKey(nameof(ComponentManufacturersId))]
    public ComponentManufacturers ComponentManufacturer { get; set; }
    
    public ICollection<PCComponents> PcComponents { get; set; } = [];
}