namespace OrganizationService.DTO
{
    public class MemberDTO
    {

        public Guid TeamId { get; set; }

        public string MemberName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Role { get; set; }

    }
}
