using ACBarberShop.Infraestructure.Data;
using ACBarberShop.Infraestructure.Models;
using ACBarberShop.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Infraestructure.Repository.Implemetations
{
    public class RepositoryFactura : IRepositoryFactura
    {
        private BarberShopContext _context;

        public RepositoryFactura(BarberShopContext context)
        {
            _context = context;
        }

        public async Task<Factura> FindByIdAsync(int id)
        {
            var @object = await _context.Set<Factura>()
           .Where(x => x.IdFactura == id)
           .Include(x => x.FacturaProducto).ThenInclude(x => x.IdProductoNavigation)
           .Include(x=> x.FacturaServicio).ThenInclude(x=>x.IdServicioNavigation)
           .Include(x => x.IdClienteNavigation)
           .Include(x => x.IdSucursalNavigation).ThenInclude(x=> x.IdDireccionNavigation)
           .Include(x=> x.IdEstadoNavigation)
           
           .FirstAsync();
            return @object;
        }

        public Task<Factura> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Factura>> ListAsync()
        {
            var collection = await _context.Set<Factura>()
              .Include(x => x.IdEstadoNavigation)
              .OrderByDescending(x => x.Fecha)
              .ToListAsync();

            return collection;
        }
    }
}
