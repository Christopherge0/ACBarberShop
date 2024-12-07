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
    public class RepositorySucursal : IRepositorySucursal
    {
        private BarberShopContext _context;

        public RepositorySucursal(BarberShopContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Sucursal entity, string[] selectedUsuarios)
        {
            modificarUsuario(selectedUsuarios, entity);
            await _context.Set<Sucursal>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.IdSucursal;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Sucursal> FindByIdAsync(int id)
        {
            var @object = await _context.Set<Sucursal>()
           .Where(x => x.IdSucursal == id)
           .Include(x => x.IdDireccionNavigation)
           .Include(x => x.Cita)
           .Include(x => x.Horario)
           .Include(x => x.Factura)
           .Include(x => x.Usuario)
           .FirstAsync();
            return @object;
        }

        public Task<Sucursal> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Sucursal>> GetAllAsync()
        {
            return await _context.Sucursal
                             .Include(s => s.IdDireccionNavigation)
                             .ToListAsync();
        }

        //En el ListAsync se debe agregar igual los includes de las tablas para que se muestre en general en este caso ocupamos la direccion exacta de la tabla direccion para mostrarla en sucursal
        //Se maneja practicamente similar que el FindByIdAsync solo que al llamarlos a todos no necesitamos el where
        public async Task<ICollection<Sucursal>> ListAsync()
        {
            var collection = await _context.Set<Sucursal>()
                .Include(x => x.IdDireccionNavigation).ToListAsync();
            return collection;
                            

        }

        public async Task UpdateAsync(Sucursal entity, string[] selectedUsuarios)
        {
            modificarUsuario(selectedUsuarios, entity);
            await _context.SaveChangesAsync();
        }

        private void modificarUsuario(string[] selectedUsuarios, Sucursal actualizarSucursal)
        {
            var listaUsuarios = _context.Usuario.ToList();
            var usuariosObject = new List<Usuario>();
            foreach (var item in selectedUsuarios)
            {
                usuariosObject.Add(
                    listaUsuarios.Where(x => x.IdUsuario.ToString() == item).First<Usuario>()
                    );
            }
            actualizarSucursal.Usuario = usuariosObject;
        }
    }
}
