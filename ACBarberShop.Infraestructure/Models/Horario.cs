using System;
using System.Collections.Generic;

namespace ACBarberShop.Infraestructure.Models;

public partial class Horario
{
    public int IdHorario { get; set; }

    public int IdSucursal { get; set; }

    public string DiaSemana { get; set; } = null!;

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public int IdEstado { get; set; }

    public virtual EstadoBloqueo IdEstadoNavigation { get; set; } = null!;

    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
}
