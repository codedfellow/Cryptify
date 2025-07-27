using Cryptify.Application.Contracts.Services;
using Cryptify.Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crytptify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaesarCipherController : ControllerBase
    {
        private readonly ICaesarCipherService _caesarCipherService;
        public CaesarCipherController(ICaesarCipherService caesarCipherService)
        {
            _caesarCipherService = caesarCipherService;
        }

        [HttpPost("encrypt")]
        public IActionResult Encrypt([FromBody] EncryptCaesarCipherDto model)
        {
            try
            {
                var response = _caesarCipherService.Encrypt(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new GenericResponseDto(false, "Error encrypting: " + ex.GetBaseException().Message, null));
            }
        }

        [HttpPost("decrypt")]
        public IActionResult Decrypt([FromBody] DecryptCaesarCipherDto model)
        {
            try
            {
                var response = _caesarCipherService.Decrypt(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new GenericResponseDto(false, "Error decrypting: " + ex.GetBaseException().Message, null));
            }
        }
    }
}
