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
    public class RepositoryRol: IRepositoryRol
    {
        private BarberShopContext _context;

        public RepositoryRol(BarberShopContext context)
        {
            _context = context;
        }

        public async Task<Rol> FindByIdAsync(int id)
        {
            var @object = await _context.Set<Rol>().FindAsync(id);

            return @object!;
        }

        public async Task<ICollection<Rol>> ListAsync()
        {
            var collection = await _context.Set<Rol>().AsNoTracking().ToListAsync();
            return collection;
        }
    }
}
