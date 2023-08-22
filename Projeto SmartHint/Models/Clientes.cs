using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projeto_SmartHint.Models
{
    public class ClientesModel
    {
        [Display(Name = "Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Nome ou Razão Social")]
        [Column("NomeRazaoSocial")]
        public string NomeRazaoSocial { get; set; }

        [Display(Name = "Email")]
        [Column("Email")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        [Column("Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "Data do Cadastro")]
        [Column("DataCadastro")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Bloqueado")]
        [Column("Bloqueado")]
        public int Bloqueado { get; set; }

        [Display(Name = "Tipo Pessoa")]
        [Column("Tipo Pessoa")]
        public int TipoPessoa { get; set; }

        [Display(Name = "CPF/CNPJ")]
        [Column("CpfCnpj")]
        public string CpfCnpj { get; set; }

        [Display(Name = "Inscrição Estadual")]
        [Column("IncricaoEstadual")]
        public string? IncricaoEstadual { get; set; }

        [Display(Name = "Isento")]
        [Column("Isento")]
        public int Isento { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Column("DataNascimento")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Gênero")]
        [Column("Genero")]
        public int Genero { get; set; }

        [Display(Name = "Senha")]
        [Column("Senha")]
        public string Senha { get; set; }

        public void AlterarCadastro(ClientesModel clientes)
        {
            this.NomeRazaoSocial = clientes.NomeRazaoSocial;
            this.Email = clientes.Email;
            this.Telefone = clientes.Telefone;
            this.Bloqueado = clientes.Bloqueado;
            this.TipoPessoa = clientes.TipoPessoa;
            this.CpfCnpj = clientes.CpfCnpj;
            this.IncricaoEstadual = clientes.IncricaoEstadual;
            this.Isento = clientes.Isento;
            this.DataNascimento = clientes.DataNascimento;
            this.Genero = clientes.Genero;
            this.Senha = clientes.Senha;
        }
    }
}
