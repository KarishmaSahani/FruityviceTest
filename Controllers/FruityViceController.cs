using FruityviceTest.Interfaces;
using FruityviceTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace FruityviceTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruityViceController : ControllerBase
    {
        IFruitService _fruitService;
        ILogger _logger;
       
        public FruityViceController(IFruitService fruitService,ILogger<FruityViceController> logger)
        {
            _fruitService = fruitService;
            _logger = logger;
        }

        [HttpGet(Name = "All")]
        public async Task<IActionResult> GetFruits()
        {
            try {
                var fruits = await _fruitService.GetAllFruits();
                return Ok(fruits);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Error occurred while retrieving data");
                return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected error occurred");
            }
            
        }
        [HttpPost(Name = "FruitFamily")]
        
        public async Task<IActionResult> GetFruitsByFamily([FromBody]FruitFamilyRequest fruitFamilyRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError( "GetFruitsByFamily : Bad Request");
                    return BadRequest();
                }
                var fruits = await _fruitService.GetFruitsByFamily( fruitFamilyRequest.FruitFamily);
                return Ok(fruits);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "GetFruitsByFamily : Error occurred while retrieving data");
                return StatusCode(StatusCodes.Status500InternalServerError, "Unexpected error occurred");
            }

        }
    }
}