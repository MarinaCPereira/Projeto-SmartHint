using Projeto_SmartHint.Models;

namespace Projeto_SmartHint.Repositorio
{
    public interface IRepository
    {
        IEnumerable<ClientesModel> SelecionarClientes();

        IEnumerable<ClientesModel> SelecionarClientesPorFiltro(Filtro filtro);

        int CadastrarCliente(ClientesModel clientes);

        int AtualizarCliente(ClientesModel clientes);
    }
}
