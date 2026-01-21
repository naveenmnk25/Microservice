using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganizationService.DTO;
using OrganizationService.Models;

namespace OrganizationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController(OrganizationServiceDbContext context) : ControllerBase
    {
        private readonly OrganizationServiceDbContext _context = context;

        [HttpGet]
        public async Task<IActionResult> Get() =>
            Ok(await _context.Teams.ToListAsync());

        [HttpPost]
        public async Task<IActionResult> Create(TeamDTO teamDto)
        {
            var team = new Team
            {
                TeamId = Guid.NewGuid(),
                TeamName = teamDto.TeamName,
                Description = teamDto.Description,
                CreatedAt = DateTime.UtcNow
            };

            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return Ok(team);
        }
    }
}
