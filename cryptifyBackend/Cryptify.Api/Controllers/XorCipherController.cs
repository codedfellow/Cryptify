using Cryptify.Application.Contracts.Services;
using Cryptify.Application.DTOs;
using Cryptify.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crytptify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XorCipherController : ControllerBase
    {
        private readonly IXorCipherService _xorCipherService;

        public XorCipherController(IXorCipherService xorCipherService)
        {
            _xorCipherService = xorCipherService;
        }

        [HttpPost("encrypt")]
        public IActionResult Encrypt([FromBody] XorCipherEncryptionDto model)
        {
            try
            {
                var response = _xorCipherService.Encrypt(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new GenericResponseDto(false, "Error encrypting: " + ex.GetBaseException().Message, null));
            }
        }

        [HttpPost("decrypt")]
        public IActionResult Decrypt([FromBody] XorCipherDecryptionDto model)
        {
            try
            {
                var response = _xorCipherService.Decrypt(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new GenericResponseDto(false, "Error decrypting: " + ex.GetBaseException().Message, null));
            }
        }
    }
}
