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
    public class RepositoryHorario : IRepositoryHorario
    {
        private BarberShopContext _context;

        public RepositoryHorario(BarberShopContext context)
        {
            _context = context;
        }

        public async Task<int> AddBlokeoAsync(Horario entity)
        {
            await _context.Set<Horario>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.IdHorario;
        }
        public async Task<int> AddAperturaAsync(Horario entity)
        {
            await _context.Set<Horario>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.IdHorario;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Horario> FindByIdAsync(int id)
        {
            var @object = await _context.Set<Horario>()
                .Where(x => x.IdHorario == id)
                .Include(x => x.IdEstadoNavigation)
                .Include(x => x.IdSucursalNavigation)
                .FirstAsync();
            return @object;
        }

        public Task<Horario> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Horario>> ListAsync()
        {
            var collection = await _context.Set<Horario>()
                .Include(x => x.IdEstadoNavigation)
                .Include(x => x.IdSucursalNavigation)
                .ToListAsync();
            return collection;
        }
        public async Task<IEnumerable<Horario>> GetHorariosPorFechaYSucursal(DateOnly fechaInicio, DateOnly FechaFin, int? idSucursal)
        {
            return await _context.Horario
                .Where(h => h.IdSucursal == idSucursal &&
                            (fechaInicio <= h.FechaFin && FechaFin >= h.FechaInicio))
                .ToListAsync();

        }

        public Task UpdateAsync(Horario entity)
        {

            throw new NotImplementedException();
        }

        public async Task<ICollection<Horario>> ListAsyncBySucursal(int idSucursal)
        {
                var collection = await _context.Set<Horario>()
                .Where(h => h.IdSucursal == idSucursal)
                .Include(x => x.IdEstadoNavigation)
                .Include(x => x.IdSucursalNavigation)
                .ToListAsync();
            return collection;
        }
    }
}