using System.ComponentModel.DataAnnotations;

namespace PCsAPI.Entities;

public class ComponentManufacturers
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(30)]
    public string Abbreviation { get; set; } = String.Empty;
    
    [MaxLength(300)]
    public string FullName { get; set; } = String.Empty;
    
    public DateOnly FoundationDate { get; set; } 
    
    public ICollection<Components> Components { get; set; } = [];
}