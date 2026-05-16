using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCsAPI.DTOs;
using PCsAPI.Entities;
using PCsAPI.Services;

namespace PCsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PCsController : ControllerBase
    {
        private readonly IDbService _dbService;
        public PCsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPCsAsync()
        {
            var result = await _dbService.GetAllPCsAsync();
            return Ok(result);
        }


        [Route("{id:int}/components")]
        [HttpGet]
        public async Task<IActionResult> GetComponentsForPCAsync(int id)
        {
            var result = await _dbService.GetComponentForPCAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePCAsync([FromBody] CreatePCDto pc)
        {
            await _dbService.AddPCAsync(pc);
            return StatusCode(StatusCodes.Status201Created);
        }

        [Route("{id:int}")]
        [HttpPut]
        public async Task<IActionResult> UpdatePCAsync(int id, [FromBody] UpdatePCDto pc)
        {
            try
            {
                await _dbService.UpdatePCAsync(pc, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> DeletePCAsync(int id)
        {
            try
            {
                await _dbService.DeletePCAsync(id);
                return NoContent();
            }catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
