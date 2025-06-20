using Microsoft.AspNetCore.Mvc;
using MuseiChiese.Modelli;
using MuseiChiese.Modelli.Modelli;

namespace MuseiChieseMarche.Controllers
{
    public class PuntiController : Controller
    {
        public async Task<IActionResult> Index(string? nome, string? comune)
        {
            var punti = await FunzioniInterrogazioniServiziOsm.RicercaStrutture(nome, comune);

            ViewBag.Nome = nome;
            ViewBag.Comune = comune;

            return View(punti.ToList());
        }
    }
}
