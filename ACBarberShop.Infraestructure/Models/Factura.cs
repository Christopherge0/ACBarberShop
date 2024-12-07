using System;
using System.Collections.Generic;

namespace ACBarberShop.Infraestructure.Models;

public partial class Factura
{
    public int IdFactura { get; set; }

    public int? IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public string? CorreoElectronico { get; set; }

    public int? IdSucursal { get; set; }

    public decimal? Total { get; set; }

    public int? IdEstado { get; set; }

    public DateOnly? Fecha { get; set; }

    public virtual ICollection<FacturaProducto> FacturaProducto { get; set; } = new List<FacturaProducto>();

    public virtual ICollection<FacturaServicio> FacturaServicio { get; set; } = new List<FacturaServicio>();

    public virtual Usuario? IdClienteNavigation { get; set; }

    public virtual EstadoFactura? IdEstadoNavigation { get; set; }

    public virtual Sucursal? IdSucursalNavigation { get; set; }
}
