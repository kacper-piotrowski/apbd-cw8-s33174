namespace PCsAPI.DTOs;

public class CreatePCDto
{
    public string Name { get; set; } = String.Empty;
    public float Weight { get; set; }
    public int Warranty  { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
}