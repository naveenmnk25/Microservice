using ApplicationService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController(OrganizationServiceDbContext context) : ControllerBase
    {
        private readonly OrganizationServiceDbContext _context = context;

        [HttpPost]
        public async Task<IActionResult> Create(Application app)
        {
            _context.Applications.Add(app);
            await _context.SaveChangesAsync();
            return Ok(app);
        }
    }
}
