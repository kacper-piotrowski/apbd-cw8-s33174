using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PCsAPI.Entities;

public class ComponentTypes
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(30)]
    public string Abbreviation { get; set; } = String.Empty;
    
    [MaxLength(150)]
    public string Name { get; set; } = String.Empty;

    public ICollection<Components> Components { get; set; } = [];
}