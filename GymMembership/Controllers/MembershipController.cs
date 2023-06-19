using GymMembership.BLL.Interfaces;
using GymMembership.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymMembership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController : ControllerBase
    {
        private readonly IMembershipService _membershipService;

        public MembershipController(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Membership>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetAllMemberships")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var result = await _membershipService.GetAll();

            if (result != null && result.Any()) return Ok(result);

            return NotFound();
        }

        [ProducesResponseType(StatusCodes.Status200OK,
            Type = typeof(Membership))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id == null) return BadRequest(id);

            var result = await _membershipService.GetById(id);

            if (result != null) return Ok(result);

            return NotFound();
        }

        [HttpPost("Add")]
        public async Task Add([FromBody] Membership membership)
        {
            await _membershipService.Add(membership);
        }

        [HttpPost("Update")]
        public async Task Update([FromBody] Membership membership)
        {
            await _membershipService.Update(membership);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _membershipService.Delete(id);

            return Ok();
        }
    }
}
