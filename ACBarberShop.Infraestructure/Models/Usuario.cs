using System;
using System.Collections.Generic;

namespace ACBarberShop.Infraestructure.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public string? CorreoElectronico { get; set; }

    public int? IdDireccion { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? Contrasenia { get; set; }

    public int? IdRol { get; set; }

    public int? IdSucursal { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Factura> Factura { get; set; } = new List<Factura>();

    public virtual Direccion? IdDireccionNavigation { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual Sucursal? IdSucursalNavigation { get; set; }
}
