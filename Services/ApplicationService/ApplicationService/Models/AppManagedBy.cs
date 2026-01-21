using System;
using System.Collections.Generic;

namespace ApplicationService.Models;

public partial class AppManagedBy
{
    public Guid AppManagedById { get; set; }

    public Guid ApplicationId { get; set; }

    public Guid MemberId { get; set; }

    public DateTime? AssignedAt { get; set; }

    public virtual Application Application { get; set; } = null!;
}
