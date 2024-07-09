using System;
using System.Collections.Generic;

namespace ACBarberShop.Infraestructure.Models;

public partial class Cita
{
    public int IdCita { get; set; }

    public int IdCliente { get; set; }

    public int IdSucursal { get; set; }

    public int IdServicio { get; set; }

    public int IdEstado { get; set; }

    public DateTime FechaHora { get; set; }

    public DateTime? FechaHoraReprogramada { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Usuario IdClienteNavigation { get; set; } = null!;

    public virtual EstadosCita IdEstadoNavigation { get; set; } = null!;

    public virtual Servicio IdServicioNavigation { get; set; } = null!;

    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
}
