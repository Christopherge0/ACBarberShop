using ACBarberShop.Application.Services.Implemetations;
using ACBarberShop.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ACBarberShop.Web.Controllers
{
    public class FacturaController : Controller
    {
        private IServiceFactura serviceFactura;

        public FacturaController(IServiceFactura serviceFactura)
        {
            this.serviceFactura = serviceFactura;
        }

        public async Task<ActionResult> Index()
        {
            var collection = await serviceFactura.ListAsync();

            return View(collection);
            
        }
        public async Task<ActionResult> Details(int id)
        {
            var @object = await serviceFactura.FindByIdAsync(id);
            return View(@object);
        }
    }
}
