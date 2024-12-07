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
    public class RepositoryFacturaProducto: IRepositoryFacturaProducto
    {
        private BarberShopContext _context;

        public RepositoryFacturaProducto(BarberShopContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(FacturaProducto entity)
        {
            await _context.Set<FacturaProducto>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.IdFacturaProducto;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<FacturaProducto> FindByIdAsync(int id)
        {
            var @object = await _context.Set<FacturaProducto>()
                            .Include(x => x.IdFacturaNavigation)
                            .Include(x => x.IdProductoNavigation)
                            .Where(x => x.IdProducto == id)
                            .FirstOrDefaultAsync();
            return @object!;
        }

        public Task<FacturaProducto> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<FacturaProducto>> ListAsync()
        {
            var collection = await _context.Set<FacturaProducto>().ToListAsync();
            return collection;
        }

        public async Task UpdateAsync(FacturaProducto entity)
        {
            entity.IdFacturaNavigation = _context.Factura.Find(entity.IdFactura);
            entity.IdProductoNavigation = _context.Producto.Find(entity.IdProducto);
            await _context.SaveChangesAsync();
        }
    }
}
