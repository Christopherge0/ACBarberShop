using System;
using System.Collections.Generic;

namespace ACBarberShop.Infraestructure.Models;

public partial class Sucursal
{
    public int IdSucursal { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Telefono { get; set; }

    public int? IdDireccion { get; set; }

    public string? CorreoElectronico { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Factura> Factura { get; set; } = new List<Factura>();

    public virtual ICollection<Horario> Horario { get; set; } = new List<Horario>();

    public virtual Direccion? IdDireccionNavigation { get; set; }

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
