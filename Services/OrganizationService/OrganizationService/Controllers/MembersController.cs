using MassTransit;
using Microsoft.AspNetCore.Mvc;
using OrganizationService.DTO;
using OrganizationService.Models;
using rabbitmq_organization_service.Events;

namespace OrganizationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController(OrganizationServiceDbContext context, IPublishEndpoint publishEndpoint) : ControllerBase
    {
        private readonly OrganizationServiceDbContext _context = context;
        private readonly IPublishEndpoint _publishEndpoint= publishEndpoint;

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null) return NotFound();
            return Ok(member);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MemberDTO memberDTO)
        {
            var member = new Member
            {
                MemberId = Guid.NewGuid(),
                TeamId = memberDTO.TeamId,
                MemberName = memberDTO.MemberName,
                Email = memberDTO.Email,
                Role = memberDTO.Role,
                CreatedAt = DateTime.UtcNow
            };
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
            await _publishEndpoint.Publish(
                  new MemberCreated(member.MemberId, member.MemberName));

            return Ok(member);
        }
    }
}
