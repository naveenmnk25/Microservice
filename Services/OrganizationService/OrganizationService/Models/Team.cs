using System;
using System.Collections.Generic;

namespace OrganizationService.Models;

public partial class Team
{
    public Guid TeamId { get; set; }

    public string TeamName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();
}
