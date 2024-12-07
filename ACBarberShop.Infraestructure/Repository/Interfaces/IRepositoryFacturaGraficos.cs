using ACBarberShop.Infraestructure.Repository.Implemetations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryFacturaGraficos
    {
        Task<List<ServicioVentaEntity>> GetTopServiciosMasVendidosAsync(int topN);
    }
}
