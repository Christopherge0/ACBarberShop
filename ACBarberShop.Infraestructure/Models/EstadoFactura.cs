using System;
using System.Collections.Generic;

namespace ACBarberShop.Infraestructure.Models;

public partial class EstadoFactura
{
    public int IdEstadoFactura { get; set; }

    public string? Descripccion { get; set; }

    public virtual ICollection<Factura> Factura { get; set; } = new List<Factura>();
}
