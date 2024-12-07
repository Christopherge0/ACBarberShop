using System;
using System.Collections.Generic;

namespace ACBarberShop.Infraestructure.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? IdCategoria { get; set; }

    public decimal? Precio { get; set; }

    public string? Volumen { get; set; }

    public string? Marca { get; set; }

    public int? Cantidad { get; set; }

    public virtual ICollection<FacturaProducto> FacturaProducto { get; set; } = new List<FacturaProducto>();

    public virtual Categoria? IdCategoriaNavigation { get; set; }
}
