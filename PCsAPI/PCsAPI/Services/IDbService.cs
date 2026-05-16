using PCsAPI.DTOs;

namespace PCsAPI.Services;

public interface IDbService
{
    Task<IEnumerable<GetPCDto>> GetAllPCsAsync();
    Task<GetComponentForPCDto> GetComponentForPCAsync(int id);
    Task AddPCAsync(CreatePCDto pcDto);
    Task UpdatePCAsync(UpdatePCDto pcDto,  int id);
    Task DeletePCAsync(int id);
}