using System;
using System.Collections.Generic;

namespace ACBarberShop.Infraestructure.Models;

public partial class FacturaProducto
{
    public int IdFacturaProducto { get; set; }

    public int? IdFactura { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? SubTotal { get; set; }

    public virtual Factura? IdFacturaNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
