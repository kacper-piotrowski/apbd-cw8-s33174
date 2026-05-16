using System.ComponentModel.DataAnnotations;

namespace PCsAPI.DTOs;

public class GetManufacturerDto
{
    public int Id { get; set; }
    
    [MaxLength(30)]
    public string Abbreviation { get; set; } = String.Empty;
    
    [MaxLength(300)]
    public string FullName { get; set; } = String.Empty;
    
    public DateOnly FoundationDate { get; set; } 
}