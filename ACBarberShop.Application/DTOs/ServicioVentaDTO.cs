using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.DTOs
{
    public record ServicioVentaDTO
    {
        public string NombreServicio { get; set; } = null!;
        public int TotalCantidad { get; set; }
    }

}
