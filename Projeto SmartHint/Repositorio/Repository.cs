using Projeto_SmartHint.Data;
using Projeto_SmartHint.Models;

namespace Projeto_SmartHint.Repositorio
{


    public class Repository : IRepository
    {
        private readonly BancoContext _context;
        public Repository(BancoContext context)
        {
            _context = context;
        }

        public IEnumerable<ClientesModel> SelecionarClientes()
        {
            return _context.Clientes;
        }

        public IEnumerable<ClientesModel> SelecionarClientesPorFiltro(Filtro filtro)
        {
            IQueryable<ClientesModel> clientes = _context.Clientes;

            if (!string.IsNullOrEmpty(filtro.NomeRazaoSocial))
            {
                clientes = clientes.Where(c => c.NomeRazaoSocial.ToLower().Contains(filtro.NomeRazaoSocial.ToLower()));
            }

            if (!string.IsNullOrEmpty(filtro.Email))
            {
                clientes = clientes.Where(c => c.Email.ToLower().Contains(filtro.Email.ToLower()));
            }

            if (!string.IsNullOrEmpty(filtro.Telefone))
            {
                clientes = clientes.Where(c => c.Telefone.ToLower().Contains(filtro.Telefone.ToLower()));
            }

            if (filtro.DataCadastro.ToString("ddMMyy") != "010101")
            {
                clientes = clientes.Where(c => c.DataCadastro.Date == filtro.DataCadastro);
            }

            if (filtro.Bloqueado != 2)
            {
                clientes = clientes.Where(c => c.Bloqueado == filtro.Bloqueado);
            }

            return clientes.ToList();
        }

        public int CadastrarCliente(ClientesModel clientes)
        {
            _context.Clientes.Add(clientes);

            return _context.SaveChanges();
        }

        public int AtualizarCliente(ClientesModel clientes)
        {
            var clienteExistente = _context.Clientes.Find(clientes.Id);

            if (clienteExistente != null)
                clienteExistente.AlterarCadastro(clientes);

            return _context.SaveChanges();
        }
    }
}
