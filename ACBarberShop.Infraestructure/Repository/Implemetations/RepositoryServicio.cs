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
    public class RepositoryServicio : IRepositoryServicio
    {
        private BarberShopContext _context;

        public RepositoryServicio(BarberShopContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Servicio entity)
        {
            await _context.Set<Servicio>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.IdSevicio;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Servicio> FindByIdAsync(int id)
        {
            var @object = await _context.Set<Servicio>()
                 .Where(x => x.IdSevicio == id)
                 .FirstOrDefaultAsync();
            return @object!;
        }

        public Task<Servicio> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Servicio>> ListAsync()
        {
            var collection = await _context.Set<Servicio>().ToListAsync();
            return collection;
        }

        public async Task<ICollection<Servicio>> ListByNameAsync(string name)
        {
            return await _context.Servicio
                             .Where(s => s.Nombre.Contains(name))
                             .ToListAsync();
        }

        public async Task UpdateAsync(Servicio entity)
        {
            await _context.SaveChangesAsync();
        }
    }
}
