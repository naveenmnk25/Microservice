using System;
using System.Collections.Generic;

namespace ApplicationService.Models;

public partial class Application
{
    public Guid ApplicationId { get; set; }

    public string ApplicationName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<AppManagedBy> AppManagedBies { get; set; } = new List<AppManagedBy>();
}
