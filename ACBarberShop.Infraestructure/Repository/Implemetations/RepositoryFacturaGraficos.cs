using ACBarberShop.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Infraestructure.Repository.Implemetations
{
    public class RepositoryFacturaGraficos
    {
        private readonly BarberShopContext _context;

        public RepositoryFacturaGraficos(BarberShopContext context)
        {
            _context = context;
        }

        public async Task<List<ServicioVentaEntity>> GetTopServiciosMasVendidosAsync(int topN)
        {
            var result = await _context.Set<ServicioVentaEntity>()
                .FromSqlRaw(@"
                SELECT TOP {0} 
                    s.[nombre] AS NombreServicio, 
                    SUM(fs.[cantidad]) AS TotalCantidad
                FROM 
                    [BarberShop].[dbo].[facturaServicio] fs
                JOIN 
                    [BarberShop].[dbo].[servicio] s ON fs.[idServicio] = s.[idSevicio]
                GROUP BY 
                    s.[nombre]
                ORDER BY 
                    TotalCantidad DESC", topN)
                .ToListAsync();

            return result;
        }
    }
}
