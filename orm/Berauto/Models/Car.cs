using System;
using System.Collections.Generic;

namespace Berauto.Models;

public partial class Car
{
    public int Id { get; set; }

    public string RegNum { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int FuelId { get; set; }

    public int StatusId { get; set; }

    public int? ClientId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Fuel Fuel { get; set; } = null!;

    public virtual CarStatus Status { get; set; } = null!;
    
    public override string ToString()
    {
        return $"{Id} {RegNum} - {Brand} {Model} {Fuel}";
    }
}
