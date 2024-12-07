using ACBarberShop.Application.DTOs;
using ACBarberShop.Application.Services.Interfaces;
using ACBarberShop.Application.Utils;
using ACBarberShop.Infraestructure.Models;
using ACBarberShop.Infraestructure.Repository.Interfaces;
using AutoMapper;
using ACBarberShop.Application.Config;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.Services.Implemetations
{
    public class ServiceUsuario: IServiceUsuario

    {
        private readonly IRepositoryUsuario _repository;
        private readonly IMapper _mapper;
        private readonly IOptions<AppConfig> _options;

        public ServiceUsuario(IRepositoryUsuario repository, IMapper mapper, IOptions<AppConfig> options)
        {
            _repository = repository;
            _mapper = mapper;
            _options = options;
        }

        public async Task<int> AddAsync(UsuarioDTO dto)
        {
            // Llave secreta
            string secret = _options.Value.Crypto.Secret;
            // Password encriptado
            string passwordEncrypted = Cryptography.Encrypt(dto.Contrasenia!, secret);
            // Establecer password DTO
            dto.Contrasenia = passwordEncrypted;
            var objectMapped = _mapper.Map<Usuario>(dto);

            return await _repository.AddAsync(objectMapped);
        }

    

        public async Task<UsuarioDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMapped = _mapper.Map<UsuarioDTO>(@object);
            return objectMapped;
        }

        public Task<UsuarioDTO> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<UsuarioDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();
            var collection = _mapper.Map<ICollection<UsuarioDTO>>(list);
            return collection;
        }

        public async Task<UsuarioDTO> LoginAsync(string id, string password)
        {
            UsuarioDTO usuarioDTO = null!;

            // Llave secreta
            string secret = _options.Value.Crypto.Secret;
            // Password encriptado
            string passwordEncrypted = Cryptography.Encrypt(password, secret);

            var @object = await _repository.LoginAsync(id, passwordEncrypted);

            if (@object != null)
            {
                usuarioDTO = _mapper.Map<UsuarioDTO>(@object);
            }

            return usuarioDTO;
        }

        public async Task<ICollection<UsuarioDTO>> ListUsuariosSinSucursal()
        {
            var list = await _repository.ListUsuariosSinSucursal();
            var collection = _mapper.Map<ICollection<UsuarioDTO>>(list);
            return collection;
        }

        public async Task UpdateAsync(int id, UsuarioDTO dto)
        {
            
            var @object = await _repository.FindByIdAsync(id);
            var entity = _mapper.Map(dto, @object!);
            await _repository.UpdateAsync(entity);
        }
    }

}
