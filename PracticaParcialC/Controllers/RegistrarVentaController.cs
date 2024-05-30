using Microsoft.AspNetCore.Mvc;
using PracticaParcialC.Models;
using PracticaParcialC.Services;

namespace PracticaParcialC.Controllers
{
    public class RegistrarVentaController : Controller
    {
        private readonly IRegistrarVentaService _ventasService;

        public RegistrarVentaController(IRegistrarVentaService ventasService)
        {
            _ventasService = ventasService;
        }
        public IActionResult RegistrarVenta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarVenta(VentaModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _ventasService.RegistrarVenta(model.MapearAEntidad());

            return RedirectToAction("Resultados");
        }

        public IActionResult Resultados()
        {
            var ventas = _ventasService.ObtenerVentas();

            var VentasModelLista = VentaModel.MapearAListaModel(ventas);

            return View(VentasModelLista);
        }
    }
}
