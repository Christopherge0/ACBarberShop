using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.DTOs
{
    public  record EstadosCitaDTO
    {
        public int IdEstadoCita { get; set; }

        public string Estado { get; set; } = null!;

        public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
    }
}
