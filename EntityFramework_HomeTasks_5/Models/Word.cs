using System;
using System.Collections.Generic;

namespace EntityFramework_HomeTasks_5.Models;

public partial class Word
{
    public Guid Id { get; set; }

    public string Header { get; set; } = null!;

    public string KeyWord { get; set; } = null!;

    public virtual ICollection<KeyParam> KeyParams { get; set; } = new List<KeyParam>();
}
