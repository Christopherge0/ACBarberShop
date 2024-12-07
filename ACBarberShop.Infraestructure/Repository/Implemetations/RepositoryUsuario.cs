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

        public async Task<int> AddAsync(Usuario entity)
        {
            await _context.Set<Usuario>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.IdUsuario;
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
                                
                                 .FirstOrDefaultAsync();
            return @object!;
        }

        public Task<Usuario> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Usuario>> ListAsync()
        {
            var collection = await _context.Set<Usuario>()
                .Include(x => x.IdDireccionNavigation)
                .Include(x => x.IdRolNavigation)
                .Include(x => x.IdSucursalNavigation)
                .ToListAsync();
            return collection;
        }

        public async Task<Usuario> LoginAsync(string id, string password)
        {
            var @object = await _context.Set<Usuario>()
                                        .Include(b => b.IdRolNavigation)
                                        .Where(p => p.CorreoElectronico == id && p.Contrasenia == password)
                                        .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<ICollection<Usuario>> ListUsuariosSinSucursal()
        {
            var collection = await _context.Set<Usuario>()
                .Where(x =>x.IdRol == 2 && x.IdSucursal == null)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public async Task UpdateAsync(Usuario entity)
        {
            await _context.SaveChangesAsync();
        }
    }
}
