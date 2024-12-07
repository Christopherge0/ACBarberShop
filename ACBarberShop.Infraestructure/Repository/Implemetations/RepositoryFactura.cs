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
    public class RepositoryFactura : IRepositoryFactura
    {
        private BarberShopContext _context;

        public RepositoryFactura(BarberShopContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Factura factura)
        {
            await _context.Set<Factura>().AddAsync(factura);
            await _context.SaveChangesAsync();
            return factura.IdFactura;
        }

        public async Task<Factura> FindByIdAsync(int id)
        {
            var @object = await _context.Set<Factura>()
           .Where(x => x.IdFactura == id)
           .Include(x => x.FacturaProducto).ThenInclude(x => x.IdProductoNavigation)
           .Include(x => x.FacturaServicio).ThenInclude(x => x.IdServicioNavigation)
           .Include(x => x.IdClienteNavigation)
           .Include(x => x.IdSucursalNavigation).ThenInclude(x => x.IdDireccionNavigation)
           .Include(x => x.IdEstadoNavigation)

           .FirstAsync();
            return @object;
        }

        public async Task<ICollection<Factura>> FindByIdUsuarioSucursalAsync(int id)
        {
            var idSucursal = await _context.Set<Usuario>()
                .Where(item => item.IdUsuario == id)
                .Select(x => x.IdSucursal)
                .FirstAsync();
            var collection = await _context.Set<Factura>()
                    .Where(item => item.IdSucursal == idSucursal)
                    .Include(x => x.FacturaProducto).ThenInclude(x => x.IdProductoNavigation)
                    .Include(x => x.FacturaServicio).ThenInclude(x => x.IdServicioNavigation)
                    .Include(x => x.IdClienteNavigation)
                    .Include(x => x.IdSucursalNavigation).ThenInclude(x => x.IdDireccionNavigation)
                    .Include(x => x.IdEstadoNavigation)
                    .ToListAsync();
            return collection;
        }

        public Task<Factura> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
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



        public async Task<ICollection<Factura>> ListAsync()
        {
            var collection = await _context.Set<Factura>()
                                    .Include(x => x.IdClienteNavigation)
                                   .Include(x => x.IdEstadoNavigation)
                                   .OrderByDescending(x => x.Fecha)
                                   .ToListAsync();

            return collection;
        }

        public async Task<ICollection<Factura>> ListAsyncFactura(int idSucursal)
        {
            var collection = await _context.Set<Factura>()
               .Where(x => x.IdSucursal == idSucursal)
               .Include(x => x.IdClienteNavigation)
              .Include(x => x.IdEstadoNavigation)
              .OrderByDescending(x => x.Fecha)
              .ToListAsync();

            return collection;
        }
        public async Task UpdateAsync(Factura entity)
        {
            await _context.SaveChangesAsync();

        }
        public async Task<int> AddFacturaProductoAsync(FacturaProducto facturaProducto)
        {
            await _context.Set<FacturaProducto>().AddAsync(facturaProducto);
            await _context.SaveChangesAsync();
            return facturaProducto.IdFacturaProducto;
        }


        public async Task<ICollection<EstadoFactura>> ListEstadoAsync()
        {
            var collection = await _context.Set<EstadoFactura>()
             .Include(x => x.Factura)
             .ToListAsync();

            return collection;
        }

        public async Task<IEnumerable<Factura>> FindBySucursalIdAsync(int sucursalId)
        {
            return await _context.Factura
                             .Where(f => f.IdSucursal == sucursalId)
                             .ToListAsync();
        }

        public async Task<ICollection<Factura>> FindByClienteIdAsync(int clienteId)
        {
            return await _context.Factura.Where(f => f.IdCliente == clienteId)
                                            .OrderByDescending(x => x.Fecha)
                                            .Include(x => x.IdClienteNavigation)
                                            .Include(x => x.IdEstadoNavigation).ToListAsync();
        }
    }
}
