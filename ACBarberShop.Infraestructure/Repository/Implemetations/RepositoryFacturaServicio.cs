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
    public class RepositoryFacturaServicio: IRepositoryFacturaServicio
    {
        private BarberShopContext _context;

        public RepositoryFacturaServicio(BarberShopContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(FacturaServicio entity)
        {
            await _context.Set<FacturaServicio>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.IdFacturaServicio;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<FacturaServicio> FindByIdAsync(int id)
        {
            var @object = await _context.Set<FacturaServicio>()
                            .Include(x => x.IdFacturaNavigation)
                            .Include(x => x.IdServicioNavigation)
                            .Where(x => x.IdFacturaServicio == id)
                            .FirstOrDefaultAsync();
            return @object!;
        }

        public Task<FacturaServicio> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<FacturaServicio>> ListAsync()
        {
            var collection = await _context.Set<FacturaServicio>().ToListAsync();
            return collection;
        }

        public async Task UpdateAsync(FacturaServicio entity)
        {
            entity.IdFacturaNavigation = _context.Factura.Find(entity.IdFactura);
            entity.IdServicioNavigation = _context.Servicio.Find(entity.IdServicio);
            await _context.SaveChangesAsync();
        }
    }
}
