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
    public class RepositoryUsuario: IRepositoryUsuario
    {
        private BarberShopContext _context;

        public RepositoryUsuario(BarberShopContext context)
        {
            _context = context;
        }

        public Task<int> AddAsync(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> FindByIdAsync(int id)
        {
            var @object = await _context.Set<Usuario>()
                                .Where(x => x.IdUsuario == id)
                                .Include(x => x.IdDireccionNavigation)
                                .Include(x => x.IdRolNavigation)
                                .Include(x => x.IdSucursalNavigation)
                                .FirstAsync();
            return @object;
        }

        public Task<Usuario> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Usuario>> ListAsync()
        {
            var collection = await _context.Set<Usuario>().ToListAsync();
            return collection;
        }

        public async Task<ICollection<Usuario>> ListUsuariosSinSucursal()
        {
            //CORREGIR ID PORQUE NO HABIA NINGUN PINCHE ENCARGADO SIN SUCURSAL (BESOS Y ABRAZOS) -A
            var collection = await _context.Set<Usuario>()
                .Where(x =>x.IdRol == 2 && x.IdSucursal == null)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public Task UpdateAsync(Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}
