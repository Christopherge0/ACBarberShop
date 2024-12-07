using ACBarberShop.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.Services.Interfaces
{
    public interface IServiceUsuario
    {
        Task<ICollection<UsuarioDTO>> ListAsync(); //Trae a todos los usuarios 
        Task<ICollection<UsuarioDTO>> ListUsuariosSinSucursal(); //Trae a todos los usuarios que no tienen una sucursal asignada
        Task<UsuarioDTO> LoginAsync(string id, string password); //Esto es parte del login
        Task<UsuarioDTO> FindByIdAsync(int id);
        Task<UsuarioDTO> FindByNameAsync(string name);
        Task<int> AddAsync(UsuarioDTO dto); //Crear 
  
        Task UpdateAsync(int id, UsuarioDTO dto); //Editar
    }
}
