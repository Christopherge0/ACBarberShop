using System;
using System.Collections.Generic;

namespace ACBarberShop.Infraestructure.Models;

public partial class FacturaServicio
{
    public int IdFacturaServicio { get; set; }

    public int? IdFactura { get; set; }

    public int? IdServicio { get; set; }

    public decimal? SubTotal { get; set; }

    public int? Cantidad { get; set; }

    public virtual Factura? IdFacturaNavigation { get; set; }

    public virtual Servicio? IdServicioNavigation { get; set; }
}
