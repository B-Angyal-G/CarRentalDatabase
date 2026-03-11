using System;
using System.Collections.Generic;

namespace Berauto.Models;

public partial class Admin
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;
    
    public override string ToString()
    {
        return $"{Name}";
    }
}
