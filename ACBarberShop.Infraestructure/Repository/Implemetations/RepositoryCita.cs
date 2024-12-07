using ACBarberShop.Infraestructure.Data;
using ACBarberShop.Infraestructure.Models;
using ACBarberShop.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ACBarberShop.Infraestructure.Repository.Implemetations
{
    public class RepositoryCita : IRepositoryCita
    {
        private BarberShopContext _context;

        public RepositoryCita(BarberShopContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Cita cita)
        {
            await _context.Set<Cita>().AddAsync(cita);
            await _context.SaveChangesAsync();
            await AddAsyncProforma(cita);
            return cita.IdCita;
        }


        public async Task<int> GetNextNumberOrden()
        {
            int current = 0;

            string sql = string.Format("SELECT TOP 1 idFactura + 1 FROM Factura ORDER BY idFactura DESC;");

            System.Data.DataTable dataTable = new System.Data.DataTable();

            System.Data.Common.DbConnection connection = _context.Database.GetDbConnection();
            System.Data.Common.DbProviderFactory dbFactory = System.Data.Common.DbProviderFactories.GetFactory(connection!)!;
            using (var cmd = dbFactory!.CreateCommand())
            {
                cmd!.Connection = connection;
                cmd.CommandText = sql;
                using (System.Data.Common.DbDataAdapter adapter = dbFactory.CreateDataAdapter()!)
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataTable);
                }
            }


            current = Convert.ToInt32(dataTable.Rows[0][0].ToString());
            return await Task.FromResult(current);
        }
        public async Task<int> AddAsyncProforma(Cita cita)
        {
            var tarifa = await _context.Set<Servicio>()
             .Where(item => item.IdSevicio == cita.IdServicio)
             .Select(x => x.Tarifa)
             .FirstAsync();

            Factura factura = new Factura()
            {
                IdFactura = await GetNextNumberOrden(),
                IdCliente = cita.IdCliente,
                IdSucursal = cita.IdSucursal,
                Total = (tarifa * 0.13m)+tarifa, // Inicializar en 0, se calculará a continuación
                IdEstado = 2,
                Fecha = DateOnly.FromDateTime(DateTime.Now)

            };
            await _context.Set<Factura>().AddAsync(factura);
            await _context.SaveChangesAsync();
            await AddAsyncProformaServicio(factura.IdFactura, cita.IdServicio);
            return factura.IdFactura;
        }

        public async Task<int> AddAsyncProformaServicio(int IdFactura, int IdServicio)
        {
            var tarifa = await _context.Set<Servicio>()
              .Where(item => item.IdSevicio == IdServicio)
              .Select(x => x.Tarifa)
              .FirstAsync();
            

            FacturaServicio facturaServicio = new FacturaServicio
            {
                IdServicio = IdServicio,
                IdFactura = IdFactura,
                SubTotal = tarifa,
                Cantidad = 1
            };
            await _context.Set<FacturaServicio>().AddAsync(facturaServicio);
            await _context.SaveChangesAsync();
            return facturaServicio.IdFacturaServicio;
        }

       public async Task<Cita> FindByAsync(int id)
        {
            var @object = await _context.Set<Cita>()
           .Where(item => item.IdCita == id)
            .Include(x => x.IdClienteNavigation)
            .Include(x => x.IdEstadoNavigation)
            .Include(x => x.IdServicioNavigation)
            .Include(x => x.IdSucursalNavigation)

            .FirstAsync();
            return @object;
        }

        public async Task<ICollection<Cita>> ListIdUsuarioAsync(int id)
        {
            var collection = await _context.Set<Cita>()
            .Where(item => item.IdSucursal == id)
            .Include(x=> x.IdClienteNavigation)
            .Include(x=> x.IdEstadoNavigation)
            .Include(x => x.IdServicioNavigation)
            .Include(x=> x.IdSucursalNavigation)
            .ToListAsync();
            return collection;
        }
        public ICollection<Cita> ListFechaInvestigacionUsuario()
        {
            DateOnly fechaFutura = DateOnly.FromDateTime(DateTime.Now).AddDays(1);

            var collection = _context.Set<Cita>()
                .Where(item => item.FechaCita == fechaFutura)
                .Include(x => x.IdClienteNavigation)
                .Include(x => x.IdEstadoNavigation)
                .Include(x => x.IdServicioNavigation)
                .Include(x => x.IdSucursalNavigation)
                .ToListAsync().Result;

            return collection;
        }

        public async Task<List<Cita>> GetCitasPorSucursalHoyAsync()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            return await _context.Cita
                                 .Include(c => c.IdSucursalNavigation)
                                 .Where(c => c.FechaCita == today)
                                 .ToListAsync(); ;
        }
        public async Task<EstadosCita> ListCategriasAsync(int id)
        {
            var @object = await _context.Set<EstadosCita>()
             .Where(x => x.IdEstadoCita == id)
             .FirstAsync(); ;
            return @object;
        }

        public async Task<ICollection<Cita>> ListAsyncCita(int idSucursal)
        {
            var collection = await _context.Set<Cita>()
               .Where(x => x.IdSucursal == idSucursal)
               .Include(x => x.IdEstadoNavigation)
               .Include(x => x.IdClienteNavigation)
               .Include(x => x.IdServicioNavigation)
               .Include(x => x.IdSucursalNavigation)
               .OrderByDescending(x => x.FechaCita)
               .ToListAsync();

            return collection;
        }

        public async Task<ICollection<Cita>> ListClienteSelectAsync(int idUsuario)
        {
            var collection = await _context.Set<Cita>()
                                 .Include(x => x.IdEstadoNavigation)
                                 .Include(x => x.IdClienteNavigation)
                                 .Include(x => x.IdServicioNavigation)
                                 .Include(x => x.IdSucursalNavigation)
                                .Where(x => x.IdCliente == idUsuario)
                                .ToArrayAsync();
            return collection;
        }

        public async Task<IEnumerable<Cita>> ListFechaAsync(DateOnly fechaCita)
        {
            var @object = await _context.Set<Cita>()
                                    .Where(x => x.FechaCita == fechaCita)
                                     .Include(x => x.IdEstadoNavigation)
                                     .Include(x => x.IdClienteNavigation)
                                     .Include(x => x.IdServicioNavigation)
                                     .Include(x => x.IdSucursalNavigation)
                                    .ToListAsync();
            return @object;
        }
    }
}
