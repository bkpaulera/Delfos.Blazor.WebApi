using Delfos.Aplication.Service.Request;
using Delfos.Aplication.Service.Response;
using Delfos.Domain.Abstractions.Service;
using Microsoft.AspNetCore.Mvc;

namespace Delfos.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private IPlayerService _playerService;
        public PlayerController(IPlayerService service)
        {
            _playerService = service;
        }

        [HttpGet("GetAll", Name = "GetPlayers")]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(PlayerResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<PlayerResponse>> GetAllPlayers()
        {
            var response = await _playerService.GetAll();

            if (response.Message == "200")
            {
                return StatusCode(int.Parse(response.Message), response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet("GetById/{id}", Name = "GetPlayerById")]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(PlayerResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<PlayerResponse>> GetPlayerById(int id)
        {
            var response = await _playerService.GetById(id);

            if (response.Message == "200")
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost("Create", Name = "CreatePlayer")]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(PlayerResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<PlayerResponse>> CreatePlayer(PlayerRequest request)
        {

            var response = await _playerService.Create(request);

            if (response.Message == "200")
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpDelete("Delete", Name = "DeletePlayer")]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(PlayerResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<PlayerResponse>> DeletePlayer(PlayerRequest request)
        {

            var response = await _playerService.Delete(request);

            if (response.Message == "200")
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }


        [HttpPut("Update", Name = "UpdatePlayer")]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(PlayerResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<PlayerResponse>> UpdatePlayer(PlayerRequest request)
        {

            var response = await _playerService.Update(request);

            if (response.Message == "200")
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
