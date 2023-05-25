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
            //var dados = MinhaBasedeClientes();
            return View(/*dados*/);
        }



        public List<UsuarioModel> MinhaBasedeClientes()
        {
            UsuarioModel veic = new UsuarioModel();
            List<UsuarioModel> dados = new List<UsuarioModel>();
            veic.PlacaDoCarro = "PNT5332";
            veic.Id = 3;
            veic.MarcadoCarro = "Ford";
            veic.Proprietario = "Eduardo Freitas";
            veic.DatadeCadastro = DateTime.Now;
            dados.Add(veic);
            List<UsuarioModel> dados2 = new List<UsuarioModel>();

            var array2 = new[] { "MARCA1", "MARCA2", "MARCA3", "MARCA4", "MARCA5", "MARCA6", "MARCA7", "MARCA8", "MARCA9", "MARCA10", "aaa" };
            var array = new[] { "OTAVIO", "OTAVIO2", "OTAVIO3", "OTAVIO5", "OTAVIO6", "OTAVIO7", "OTAVIO8", "OTAVIO9", "OTAVIO10", "OTAVIO10" };
            Random randNum = new Random();

            for (int i = 0; i <= 10; i++)
            {
                UsuarioModel veic2 = new UsuarioModel();
                var b = randNum.Next(10);
                var c = randNum.Next(10);
                veic2.MarcadoCarro = array2[b];
                veic2.Proprietario = array[c];
                veic2.Id = randNum.Next(20);
                veic2.DatadeCadastro = DateTime.Now;

                dados2.Add(veic2);
            }
            return dados2;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Editar(List<UsuarioModel> model, int IdParaEditar, string Nome, string Placa, string MarcaCarro)
        {
            var novaLista = model.Where(x => x.Id == IdParaEditar).ToList();

            novaLista[0].Proprietario = Nome;
            novaLista[0].MarcadoCarro = MarcaCarro;
            novaLista[0].DatadeCadastro = DateTime.Now;
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public PartialViewResult ExibirTabela()
        {
            var model2 = MinhaBasedeClientes();
            return PartialView("_PartialIndex", model2);
        }

        [HttpDelete]
        public async Task<IActionResult> Excluir(List<UsuarioModel> model, int IdDescartado)
        {
            var novaLista = model.Where(x => x.Id != IdDescartado).ToList();

            return RedirectToAction("Index", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}