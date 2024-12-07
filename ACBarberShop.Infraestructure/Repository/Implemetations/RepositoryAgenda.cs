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
     public class RepositoryAgenda : IRepositoryAgenda
    {
        private readonly BarberShopContext _context;

        public RepositoryAgenda(BarberShopContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Cita>> ObtenerCitasPorSemanaAsync(int idSucursal, DateTime inicioSemana)
        {
            DateTime finSemana = inicioSemana.AddDays(7);
            DateOnly inicioSemanaDateOnly = DateOnly.FromDateTime(inicioSemana);
            DateOnly finSemanaDateOnly = DateOnly.FromDateTime(finSemana);

            return await _context.Cita
                .Where(c => c.IdSucursal == idSucursal && c.FechaCita >= inicioSemanaDateOnly && c.FechaCita <= finSemanaDateOnly)
                .Include(c => c.IdEstadoNavigation)
                .Include(c => c.IdClienteNavigation)
                .ToListAsync();
        }

        public async Task<ICollection<Horario>> ObtenerHorariosPorSemanaAsync(int idSucursal, DateTime inicioSemana)
        {
            DateTime finSemana = inicioSemana.AddDays(7);
            DateOnly inicioSemanaDateOnly = DateOnly.FromDateTime(inicioSemana);
            DateOnly finSemanaDateOnly = DateOnly.FromDateTime(finSemana);

            return await _context.Horario
                .Where(h => h.IdSucursal == idSucursal && h.FechaInicio >= inicioSemanaDateOnly && h.FechaFin <= finSemanaDateOnly)
                .Include(h => h.IdEstadoNavigation)
                .ToListAsync();
        }
    }
}
