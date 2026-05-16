namespace PCsAPI.DTOs;

public class GetPCComponentsDto
{
    public int Amount { get; set; }
    public GetComponentDto Component { get; set; } = new GetComponentDto();
}