using ACBarberShop.Infraestructure.Data;
using ACBarberShop.Infraestructure.Models;
using ACBarberShop.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ACBarberShop.Infraestructure.Repository.Implemetations
{
    public class RepositoryCita : IRepositoryCita
    {
        private BarberShopContext _context;

        public RepositoryCita(BarberShopContext context)
        {
            _context = context;
        }
       public async Task<Cita> FindByAsync(int id)
        {
            var @object = await _context.Set<Cita>()
           .Where(item => item.IdCita == id)
            .Include(x => x.IdClienteNavigation)
            .Include(x => x.IdEstadoNavigation)
            .Include(x => x.IdServicioNavigation)
            .Include(x => x.IdSucursalNavigation)

            .FirstAsync();
            return @object;
        }

        public async Task<ICollection<Cita>> ListIdUsuarioAsync(int id)
        {
            var collection = await _context.Set<Cita>()
            .Where(item => item.IdSucursal == id)
            .Include(x=> x.IdClienteNavigation)
            .Include(x=> x.IdEstadoNavigation)
            .Include(x => x.IdServicioNavigation)
            .Include(x=> x.IdSucursalNavigation)
            .ToListAsync();
            return collection;
        }
    }
}
