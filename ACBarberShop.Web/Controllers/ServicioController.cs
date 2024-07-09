using ACBarberShop.Application.DTOs;
using ACBarberShop.Application.Services.Implemetations;
using ACBarberShop.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ACBarberShop.Web.Controllers
{
    public class ServicioController : Controller
    {
        private readonly IServiceServicio serviceServicio;

        public ServicioController(IServiceServicio serviceServicio)
        {
            this.serviceServicio = serviceServicio;
        }

        public async Task<ActionResult> Index()
        {
            var collection = await serviceServicio.ListAsync();

            return View(collection);

        }
        public async Task<ActionResult> IndexAdmin()
        {
            var collection = await serviceServicio.ListAsync();

            return View(collection);

        }
        public async Task<ActionResult> Details(int id)
        {
            var @object = await serviceServicio.FindByIdAsync(id);
            return View(@object);
        }
        public async Task<ActionResult> Create()
        {
            //Lista de Categorias
            ViewBag.ListaCategoria = await serviceServicio.ListAsync();
            return View();
        }

        // POST: LibroController/Create //Este es el boton que hace la comparacion de los datos, que sean validos y los crea
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ServicioDTO dto)
        {

            //Validación del formulario
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
            //Crear
            await serviceServicio.AddAsync(dto);
            return RedirectToAction("Index");
        }

        /////////////////////////////////MANTENIMIENTO EDITAR//////////////////////////////////////////

        // GET: ProductoController/Edit/
        public async Task<ActionResult> Edit(int id)
        {
            var @object = await serviceServicio.FindByIdAsync(id);
            return View(@object);
        }

        // POST: ProductoController/Edit/N
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ServicioDTO dto)
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
                await serviceServicio.UpdateAsync(id, dto);
                return RedirectToAction("Index");
            }
        }
    }

}
