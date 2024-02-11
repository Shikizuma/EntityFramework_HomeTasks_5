using System;
using System.Collections.Generic;

namespace EntityFramework_HomeTasks_5.Models;

public partial class KeyParam
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public Guid WordId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Word Word { get; set; } = null!;
}
