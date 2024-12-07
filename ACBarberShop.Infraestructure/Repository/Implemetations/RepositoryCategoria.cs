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
    public class RepositoryCategoria: IRepositoryCategoria
    {
        private readonly BarberShopContext _context;

        public RepositoryCategoria(BarberShopContext context)
        {
            _context = context;
        }

        public async Task<Categoria> FindByIdAsync(int id)
        {
            var @object = await _context.Set<Categoria>().FindAsync(id);

            return @object!;
        }

        public async Task<ICollection<Categoria>> ListAsync() //Se utiliza para generar la lista de las categorias cargadas en la BD
        {
            var collection = await _context.Set<Categoria>().AsNoTracking().ToListAsync();
            return collection;
        }
    }
}
