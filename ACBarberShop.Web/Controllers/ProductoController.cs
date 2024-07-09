using ACBarberShop.Application.DTOs;
using ACBarberShop.Application.Services.Implemetations;
using ACBarberShop.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ACBarberShop.Web.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IServiceProducto serviceProducto;
        private readonly IServiceCategoria serviceCategoria;
        public ProductoController(IServiceProducto serviceProducto, IServiceCategoria serviceCategoria)
        {
            this.serviceProducto = serviceProducto;
            this.serviceCategoria = serviceCategoria;
        }
        //Index general solo se visualiza sus productos y detalles
        public async Task<ActionResult> Index()
        {
            var collection = await serviceProducto.ListAsync();

            return View(collection);
             
        }
        public async Task<ActionResult> Details(int id)
        {
            var @object = await serviceProducto.FindByIdAsync(id);
            return View(@object);
        }
        //Index del administrador donde se puede visualizar los productos con los respectivos botones de: detalle, editar y crear.
        public async Task<ActionResult> IndexAdmin()
        {
            var collection = await serviceProducto.ListAsync();

            return View(collection);

        }

        /////////////////////////////////MANTENIMIENTO CREAR//////////////////////////////////////////

        // GET: ProductoController/Create  //Este primer create lo que hace es traer la lista de categorias y leer todos los datos enviados
        public async Task<ActionResult> Create()
        {
            //Lista de Categorias
            ViewBag.ListaCategoria = await serviceCategoria.ListAsync();
            return View();
        }

        // POST: LibroController/Create //Este es el boton que hace la comparacion de los datos, que sean validos y los crea
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductoDTO dto)
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
            await serviceProducto.AddAsync(dto);
            return RedirectToAction("IndexAdmin");
        }

        /////////////////////////////////MANTENIMIENTO EDITAR//////////////////////////////////////////

        // GET: ProductoController/Edit/N
        public async Task<ActionResult> Edit(int id)
        {
            var @object = await serviceProducto.FindByIdAsync(id);
            ViewBag.ListaCategoria = await serviceCategoria.ListAsync();
            return View(@object);
        }

        // POST: ProductoController/Edit/N
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ProductoDTO dto)
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
                await serviceProducto.UpdateAsync(id, dto);
                return RedirectToAction("Index");
            }
        }
    }
}
