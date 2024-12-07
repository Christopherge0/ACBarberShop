using System;
using System.Collections.Generic;

namespace ACBarberShop.Infraestructure.Models;

public partial class Direccion
{
    public int IdDireccion { get; set; }

    public string? Provincia { get; set; }

    public string? Canton { get; set; }

    public string? Distrito { get; set; }

    public string? DireccionExacta { get; set; }

    public virtual ICollection<Sucursal> Sucursal { get; set; } = new List<Sucursal>();

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
