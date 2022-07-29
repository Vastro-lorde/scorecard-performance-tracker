using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using scorecard_performance_tracker.DTOs;
using scorecard_performance_tracker.Services;

namespace scorecard_performance_tracker.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceScoreController : ControllerBase
    {
        private readonly IScoreServices _scoreServices;
        public PerformanceScoreController(IScoreServices scoreServices)
        {
            _scoreServices = scoreServices;
        }

        [HttpGet("GetPerformanceById/{id}")]
        public async Task<IActionResult> GetPerformanceById(string id)
        {
            try
            {
                return Ok(await _scoreServices.GetScoreByIdAsync(id));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


        [HttpGet("GetAllPerformanceScore")]
        public async Task<IActionResult> GetAllPerformanceScore(int pageSize, int pageNumber)
        {
            try
            {
                return Ok(await _scoreServices.GetAllScoresAsync(pageSize, pageNumber));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


        [HttpGet("GetAllPerformanceScoreByName")]
        public async Task<IActionResult> GetAllPerformanceScoreByName(int pageSize, int pageNumber, string DevName)
        {
            try
            {
                return Ok(await _scoreServices.GetScoresByNameAsync(pageSize, pageNumber, DevName));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


        [HttpPost("CreatePerformanceScore")]
        public async Task<IActionResult> CreatePerformanceScore(CreateScoreDto createScore)
        {
            try
            {
                return Ok(await _scoreServices.CreateScoreAsync(createScore));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


        [HttpPut("UpdatePerformanceScore/{id}")]
        public async Task<IActionResult> UpdatePerformanceById(string id, UpdateScoreDto updateScore)
        {
            try
            {
                return Ok(await _scoreServices.UpdateScoreDetails(id, updateScore));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


        [HttpDelete("DeletePeformanceScore/{id}")]
        public async Task<IActionResult> DeletePerformanceById(string id)
        {
            try
            {
                return Ok(await _scoreServices.DeleteScoreAsync(id));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}