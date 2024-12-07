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

    public DateOnly FechaCita { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public DateOnly? FechaReprogramada { get; set; }

    public DateOnly FechaCreacion { get; set; }

    public string? Pregunta1 { get; set; }

    public string? Pregunta2 { get; set; }

    public string? Pregunta3 { get; set; }

    public virtual Usuario IdClienteNavigation { get; set; } = null!;

    public virtual EstadosCita IdEstadoNavigation { get; set; } = null!;

    public virtual Servicio IdServicioNavigation { get; set; } = null!;

    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
}
