﻿using System;
using System.Collections.Generic;

namespace EntityFramework_HomeTasks_5.Models;

public partial class Cart
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
