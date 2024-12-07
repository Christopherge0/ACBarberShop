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
    public class RepositoryProducto : IRepositoryProducto
    {
        private BarberShopContext _context;

        public RepositoryProducto(BarberShopContext context)
        {
            this._context = context;
        }

        public async Task<ICollection<Producto>> ListAsync()
        {
            var collection = await _context.Set<Producto>().ToListAsync();
            return collection;
        }

        public async Task<Producto> FindByIdAsync(int id)
        {
            var @object = await _context.Set<Producto>()
                            .Include(x => x.IdCategoriaNavigation)
                            .Where(x => x.IdProducto == id)
                            .FirstOrDefaultAsync();
            return @object!;
        }

        public Task<Producto> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddAsync(Producto entity)
        {
            await _context.Set<Producto>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.IdProducto;
        }

        public async Task UpdateAsync(Producto entity)
        {
            entity.IdCategoriaNavigation = _context.Categoria.Find(entity.IdCategoria);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Producto>> ListByCategoryAsync(int categoryId)
        {
            return await _context.Producto
                             .Where(p => p.IdCategoria == categoryId)
                             .ToListAsync();
        }
    }
}
