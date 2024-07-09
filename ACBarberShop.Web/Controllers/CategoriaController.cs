using ACBarberShop.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ACBarberShop.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private IServiceCategoria serviceCategoria;

        public CategoriaController(IServiceCategoria serviceCategoria)
        {
            this.serviceCategoria = serviceCategoria;
        }

        public async Task<IActionResult> IndexAsync() 
        {
            var collection = await serviceCategoria.ListAsync();
            ViewData["Title"] = "Index";
            return View(collection);
        }
    }
}
