using CadastroVeiculos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CadastroVeiculos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            UsuarioModel veic = new UsuarioModel();
            List<UsuarioModel> dados = new List<UsuarioModel>();
            veic.PlacaDoCarro = "PNT5332";
            veic.Id = 3;
            veic.MarcadoCarro = "Ford";
            veic.Proprietario = "Eduardo Freitas";
            veic.DatadeCadastro = DateTime.Now;
            dados.Add(veic);
            return View(dados);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}