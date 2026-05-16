using Microsoft.EntityFrameworkCore;
using PCsAPI.Data;
using PCsAPI.DTOs;
using PCsAPI.Entities;

namespace PCsAPI.Services;

public class DbService : IDbService
{
    
    private readonly AppDbContext _dbContext;

    public DbService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<GetPCDto>> GetAllPCsAsync()
    {
        var result = await _dbContext.PCs.Select(pc => new GetPCDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        }).ToListAsync();
        return result;
    }

    public async Task<GetComponentForPCDto> GetComponentForPCAsync(int id)
    {
        var result = await _dbContext.PCs.Where(pc=> pc.Id == id).Select(pc=> new GetComponentForPCDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock,
            Components = pc.PcComponents.Select(pccomp => new GetPCComponentsDto
            {
                Amount = pccomp.Amount,
                Component = new GetComponentDto
                {
                    Code = pccomp.Component.Code,
                    Name = pccomp.Component.Name,
                    Description = pccomp.Component.Description,
                    Manufacturer = new GetManufacturerDto
                    {
                        Id = pccomp.Component.ComponentManufacturer.Id,
                        Abbreviation = pccomp.Component.ComponentManufacturer.Abbreviation,
                        FullName = pccomp.Component.ComponentManufacturer.FullName,
                        FoundationDate = pccomp.Component.ComponentManufacturer.FoundationDate
                    },
                    Type = new GetTypeDto
                    {
                        Id = pccomp.Component.ComponentType.Id,
                        Abbreviation = pccomp.Component.ComponentType.Abbreviation,
                        Name = pccomp.Component.ComponentType.Name
                    }
                }
            }).ToList()
        }).FirstOrDefaultAsync();
        
        return result;
    }

    public async Task AddPCAsync(CreatePCDto pcDto)
    {
        var PC = new PC()
        {
            Name = pcDto.Name,
            Weight = pcDto.Weight,
            Warranty = pcDto.Warranty,
            CreatedAt = pcDto.CreatedAt,
            Stock = pcDto.Stock
        };
        await _dbContext.PCs.AddAsync(PC);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdatePCAsync(UpdatePCDto pcDto, int id)
    {
        var PC = await _dbContext.PCs.FirstOrDefaultAsync(pc => pc.Id == id);
        if (PC == null)
        {
            throw new Exception($"PC z id {id} nie znaleziony!");
        }
        PC.Name = pcDto.Name;
        PC.Weight = pcDto.Weight;
        PC.Warranty = pcDto.Warranty;
        PC.CreatedAt = pcDto.CreatedAt;
        PC.Stock = pcDto.Stock;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeletePCAsync(int id)
    {
        var deletedRows = await _dbContext.PCs.Where(pc => pc.Id == id).ExecuteDeleteAsync();
        if (deletedRows==0)
        {
            throw new Exception($"PC z id {id} nie znaleziony!");
        }
    }
}