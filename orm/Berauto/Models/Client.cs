using System;
using System.Collections.Generic;

namespace Berauto.Models;

public partial class Client
{
    public int Id { get; set; }

    public string DrivingLicence { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
    
    public override string ToString()
    {
        return $"{Name}";
    }
}
