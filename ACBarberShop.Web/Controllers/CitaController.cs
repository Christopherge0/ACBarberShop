using ACBarberShop.Application.Services.Implemetations;
using ACBarberShop.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ACBarberShop.Web.Controllers
{
    public class CitaController : Controller
    {
        private IServiceCita serviceCita;

        public CitaController(IServiceCita serviceCita)
        {
            this.serviceCita = serviceCita;
        }


        public async Task<ActionResult> Index()
        {
            int id = 3;
            var collection = await serviceCita.ListIdUsuarioAsync(id);

            return View(collection);

        }
        public async Task<ActionResult> Details(int id)
        {
            var @object = await serviceCita.FindByAsync(id);
            return View(@object);
        }
    }
}
