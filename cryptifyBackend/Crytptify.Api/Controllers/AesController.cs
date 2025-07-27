using Cryptify.Application.Contracts.Services;
using Cryptify.Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crytptify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AesController : ControllerBase
    {
        private readonly IAesService _aesService;
        public AesController(IAesService aesService)
        {
            _aesService = aesService;
        }
        [HttpPost("encrypt")]
        public IActionResult Encrypt([FromBody] AesEncryptDto model)
        {
            try
            {
                var response = _aesService.Encrypt(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new GenericResponseDto(false, "Error encrypting: " + ex.GetBaseException().Message, null));
            }
        }
        [HttpPost("decrypt")]
        public IActionResult Decrypt([FromBody] AesDescryptDto model)
        {
            try
            {
                var response = _aesService.Decrypt(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new GenericResponseDto(false, "Error decrypting: " + ex.GetBaseException().Message, null));
            }
        }
    }
}
