using ACBarberShop.Application.DTOs;
using ACBarberShop.Application.Services.Implemetations;
using ACBarberShop.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ACBarberShop.Web.Controllers
{
    public class SucursalController : Controller
    {
        private readonly IServiceSucursal serviceSucursal;
        private readonly IServiceUsuario serviceUsuario;

        public SucursalController(IServiceSucursal serviceSucursal, IServiceUsuario serviceUsuario)
        {
            this.serviceSucursal = serviceSucursal;
            this.serviceUsuario = serviceUsuario;
        }

        public async Task<ActionResult> Index()
        {
            var collection = await serviceSucursal.ListAsync();

            return View(collection);

        }
        public async Task<ActionResult> Details(int id)
        {
            var @object = await serviceSucursal.FindByIdAsync(id);
            return View(@object);
        }

        ///////////////////////////////MANTENIMIENTO CREAR/////////////////////////////////////////

        public async Task<ActionResult> Create()
        {
            //Lista de usuarios sin sucursal
            var usuarios = await serviceUsuario.ListUsuariosSinSucursal();
            ViewBag.ListUsuario = new MultiSelectList(
                    items: usuarios,
                    dataValueField: nameof(UsuarioDTO.IdUsuario),
                    dataTextField: nameof(UsuarioDTO.Nombre)
                );

            return View();
        }

        // POST: SucursalController/Create
        //Este es para guardar 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SucursalDTO dto, string[] selectedUsuarios)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("; ", ModelState.Values
                                   .SelectMany(x => x.Errors)
                                   .Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                return View();
            }
            await serviceSucursal.AddAsync(dto, selectedUsuarios);
            return RedirectToAction("Index");
        }

        ///////////////////////////////MANTENIMIENTO EDITAR/////////////////////////////////////////

        // GET: SucursalController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var @object = await serviceSucursal.FindByIdAsync(id);
            var usuarios = await serviceUsuario.ListUsuariosSinSucursal();
            var catSelected = @object.Usuario.Select(x => x.IdUsuario.ToString()).ToList();
            ViewBag.ListUsuario = new MultiSelectList(
                    items: usuarios,
                    dataValueField: nameof(UsuarioDTO.IdUsuario),
                    dataTextField: nameof(UsuarioDTO.Nombre),
                    selectedValues: catSelected
                );
            return View(@object);


        }
        // POST: SucursalController/Edit/5
        //Actualiza
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, SucursalDTO dto, string[] selectedUsuarios)
        {

            if (!ModelState.IsValid)
            {
                // Lee del ModelState todos los errores que
                // vienen para el lado del server
                string errors = string.Join("; ", ModelState.Values
                                   .SelectMany(x => x.Errors)
                                   .Select(x => x.ErrorMessage));
                ViewBag.ErrorMessage = errors;
                return View();
            }
            else
            {
                //Actualizar
                await serviceSucursal.UpdateAsync(id, dto, selectedUsuarios);
                return RedirectToAction("Index");
            }
        }
    }
}
