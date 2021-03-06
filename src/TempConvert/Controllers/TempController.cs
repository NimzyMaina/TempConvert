using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TempConvert.Interfaces;
using TempConvert.Models;

namespace TempConvert.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempController : ControllerBase
    {
        private readonly ITempConvertRepository _temp;

        public TempController(ITempConvertRepository temp)
        {
            _temp = temp;
        }

        [HttpPost("celsius")]
        public async Task<IActionResult> Celsius(ConvertRequest model)
        {
            var res = await _temp.FahrenheitToCelsiusAsync(model.Value);

            return Ok(new
            {
                Success = true,
                Temp = $"{model.Value} degrees fahrenheit is == to {res} degrees celsius"
            });
        }
        
        [HttpPost("fahrenheit")]
        public async Task<IActionResult> Fahrenheit(ConvertRequest model)
        {
            var res = await _temp.CelsiusToFahrenheitAsync(model.Value);

            return Ok(new
            {
                Success = true,
                Temp = $"{model.Value} degrees celsius is == to {res} degrees fahrenheit"
            });
        }
        
    }
}