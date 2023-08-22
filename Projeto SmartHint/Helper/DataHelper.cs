using Projeto_SmartHint.Data;
using Projeto_SmartHint.Models;

namespace Projeto_SmartHint.Helper
{
    public class DataHelper
    {
        private readonly BancoContext _context;

        public DataHelper(BancoContext context)
        {
            _context = context;
        }

        public Validacao ValidarCadastro(ClientesModel clientes)
        {
            var emailJaCadastrado = EmailJaCadastrado(clientes.Email);
            var cpfCpnjJaCadastrado = CpfCpnjJaCadastrado(clientes.CpfCnpj);
            var inscricaoEstadualJaCadastrado = InscricaoEstadualJaCadastrado(clientes.IncricaoEstadual);

            if (!emailJaCadastrado.Valido)
            {
                return emailJaCadastrado;
            }
            else if (!cpfCpnjJaCadastrado.Valido)
            {
                return cpfCpnjJaCadastrado;
            }
            else if (string.IsNullOrEmpty(clientes.IncricaoEstadual) && !inscricaoEstadualJaCadastrado.Valido)
            {
                return inscricaoEstadualJaCadastrado;
            }
            else
            {
                return new Validacao
                {
                    Valido = true,
                    Mensagem = ""
                };
            }
        }

        public Validacao EmailJaCadastrado(string email)
        {
            var clienteComMesmoEmail = _context.Clientes.Any(c => c.Email == email);

            if (clienteComMesmoEmail)
            {
                return new Validacao
                {
                    Valido = false,
                    Mensagem = "Este e-mail já está cadastrado para outro Cliente"
                };
            }
            else
            {
                return new Validacao
                {
                    Valido = true,
                    Mensagem = ""
                };
            }
        }

        public Validacao CpfCpnjJaCadastrado(string cpfCnpj)
        {
            var clienteComMesmoCnpj = _context.Clientes.Any(c => c.CpfCnpj == cpfCnpj);

            if (clienteComMesmoCnpj)
            {
                return new Validacao
                {
                    Valido = false,
                    Mensagem = "Este CPF/CNPJ já está cadastrado para outro Cliente"
                };
            }
            else
            {
                return new Validacao
                {
                    Valido = true,
                    Mensagem = ""
                };
            }
        }

        public Validacao InscricaoEstadualJaCadastrado(string cpfCnpj)
        {
            var clienteComMesmoInscricao = _context.Clientes.Any(c => c.CpfCnpj == cpfCnpj);

            if (clienteComMesmoInscricao)
            {
                return new Validacao
                {
                    Valido = false,
                    Mensagem = "Esta Inscrição Estadual já está cadastrada para outro Cliente"
                };
            }
            else
            {
                return new Validacao
                {
                    Valido = true,
                    Mensagem = ""
                };
            }
        }
    }
}
