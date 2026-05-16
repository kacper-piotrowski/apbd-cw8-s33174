using System.ComponentModel.DataAnnotations;

namespace PCsAPI.DTOs;

public class GetComponentDto
{
    [MaxLength(10)]
    public string Code { get; set; } = String.Empty;
    
    [MaxLength(300)]
    public string Name { get; set; } = String.Empty;
    
    public string Description { get; set; } = String.Empty;
    
    public GetManufacturerDto Manufacturer  { get; set; } = new GetManufacturerDto();
    
    public GetTypeDto Type { get; set; } =  new GetTypeDto();
}