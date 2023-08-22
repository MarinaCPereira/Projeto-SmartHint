using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Projeto_SmartHint.Data;
using Projeto_SmartHint.Helper;
using Projeto_SmartHint.Models;
using Projeto_SmartHint.Repositorio;
using System.Diagnostics;

namespace Controle_De_Clientes.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly IRepository _repository;
        private readonly BancoContext _context;
        private INotyfService _notif { get; }

        public ClientesController(ILogger<ClientesController> logger, BancoContext context, INotyfService notyfService, IRepository repository)
        {
            _logger = logger;
            _context = context;
            _notif = notyfService;
            _repository = repository;
        }

        public IActionResult CadastrarCliente()
        {
            return View();
        }

        public IActionResult Cadastrar(ClientesModel clientes)
        {
            var cadastroValido = new DataHelper(_context).ValidarCadastro(clientes);

            if (!cadastroValido.Valido)
            {
                _notif.Warning(cadastroValido.Mensagem);
                return View("CadastrarCliente");
            }

            var cadastrado = _repository.CadastrarCliente(clientes);

            _notif.Success("Cadastrado com Sucesso!");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult EditarCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);
            return View(cliente);
        }

        public IActionResult Editar(ClientesModel clientes)
        {
            var editado = _repository.AtualizarCliente(clientes);

            _notif.Success("Atualizado com Sucesso!");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Bloquear([FromBody]int id)
        {
            var cliente = _context.Clientes.Find(id);
            cliente.Bloqueado = cliente.Bloqueado == 1 ? 0 : 1;            

            var editado = _repository.AtualizarCliente(cliente);

            return RedirectToAction("Index", "Home");
        }
    }
}
