using System;
using System.Collections.Generic;

namespace ACBarberShop.Infraestructure.Models;

public partial class EstadoBloqueo
{
    public int IdEstadBlokeo { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Horario> Horario { get; set; } = new List<Horario>();
}
