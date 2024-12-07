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
    public class RepositoryDireccion: IRepositoryDireccion
    {
        private BarberShopContext _context;

        public RepositoryDireccion(BarberShopContext context)
        {
            _context = context;
        }

        public async Task<Direccion> FindByIdAsync(int id)
        {
            var @object = await _context.Set<Direccion>().FindAsync(id);

            return @object!;
        }

        public async Task<ICollection<Direccion>> ListAsync()
        {
            var collection = await _context.Set<Direccion>().AsNoTracking().ToListAsync();
            return collection;
        }
    }
}
