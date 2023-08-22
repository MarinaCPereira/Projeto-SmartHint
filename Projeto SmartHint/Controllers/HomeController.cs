using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Projeto_SmartHint.Data;
using Projeto_SmartHint.Models;
using Projeto_SmartHint.Repositorio;
using System.Diagnostics;
namespace Projeto_SmartHint.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository _repository;
        private readonly BancoContext _context;
        private INotyfService _notif { get; }


        public HomeController(ILogger<HomeController> logger, BancoContext context, INotyfService notyfService, IRepository repository)
        {
            _logger = logger;
            _context = context;
            _notif = notyfService;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var clientes = _context.Clientes;

            return View(clientes);
        }

        public IActionResult Filtrar(Filtro filtro)
        {
            var filtrados = _repository.SelecionarClientesPorFiltro(filtro);

            ViewBag.Filtro = filtro;
            
            return View("Index", filtrados);
        }        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}