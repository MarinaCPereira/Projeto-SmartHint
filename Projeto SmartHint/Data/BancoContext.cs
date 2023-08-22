using Microsoft.EntityFrameworkCore;
using Projeto_SmartHint.Models;

namespace Projeto_SmartHint.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<ClientesModel> Clientes { get; set; }
    }
}
