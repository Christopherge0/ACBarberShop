using System;
using System.Collections.Generic;

namespace ACBarberShop.Infraestructure.Models;

public partial class EstadosCita
{
    public int IdEstadoCita { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
