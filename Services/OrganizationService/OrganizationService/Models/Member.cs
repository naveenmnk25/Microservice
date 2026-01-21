using System;
using System.Collections.Generic;

namespace OrganizationService.Models;

public partial class Member
{
    public Guid MemberId { get; set; }

    public Guid TeamId { get; set; }

    public string MemberName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Role { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Team Team { get; set; } = null!;
}
