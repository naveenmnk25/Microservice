using ApplicationService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignController(
        OrganizationServiceDbContext context,
        IHttpClientFactory factory) : ControllerBase
    {
        private readonly OrganizationServiceDbContext _context = context;
        private readonly HttpClient _httpClient = factory.CreateClient("OrgService");

        [HttpPost]
        public async Task<IActionResult> Assign(Guid applicationId, Guid memberId)
        {
            // Validate member exists
            var response = await _httpClient.GetAsync($"api/members/{memberId}");
            if (!response.IsSuccessStatusCode)
                return BadRequest("Member not found");

            _context.AppManagedBies.Add(new AppManagedBy
            {
                ApplicationId = applicationId,
                MemberId = memberId
            });

            await _context.SaveChangesAsync();
            return Ok("Assigned successfully");
        }
    }
}
