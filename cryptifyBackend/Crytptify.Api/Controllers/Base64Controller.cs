using Cryptify.Application.Contracts.Services;
using Cryptify.Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Crytptify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Base64Controller : ControllerBase
    {
        private readonly IBase64Service _base64Service;
        public Base64Controller(IBase64Service base64Service)
        {
            _base64Service = base64Service;
        }

        [HttpPost("encode")]
        public IActionResult EncodeToBase64([FromBody]Base64EncodingDto model)
        {
            try
            {
                var response = _base64Service.EncodeToBase64(model.TextToEncode);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new GenericResponseDto(false, "Error encoding to Base64: " + ex.GetBaseException().Message, null));
            }
        }

        [HttpPost("decode")]
        public IActionResult DecodeBase64String([FromBody] Base64DecodingDto model)
        {
            try
            {
                var response = _base64Service.DecodeBase64String(model.Base64Text);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new GenericResponseDto(false, "Error decoding from Base64: " + ex.GetBaseException().Message, null));
            }
        }
    }
}
