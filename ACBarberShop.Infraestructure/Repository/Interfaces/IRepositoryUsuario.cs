using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryUsuario
    {
        Task<ICollection<Usuario>> ListAsync(); //Llama a todos los usuarios
        Task<ICollection<Usuario>> ListUsuariosSinSucursal(); //Llama a todos los usuarios que no tienen una sucursal asignada 
        Task<Usuario> FindByIdAsync(int id);
        Task<Usuario> LoginAsync(string id, string password); //Parte del login
        Task<int> AddAsync(Usuario entity); //Crear
        Task UpdateAsync(Usuario entity); //Editar

        Task<Usuario> FindByNameAsync(string name);
    }
}
