using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio_S08.Models
{
    public class PessoaFisica : Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }

        public PessoaFisica(string email, string telefone, string endereco, int numeroConta, List<Transacao> extrato,
            string nome, string cpf, DateTime dataNascimento) : base(email, telefone, endereco, numeroConta, extrato)
        {
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
            NumeroConta = numeroConta;
            Extrato = extrato;
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNascimento;
        }

        public int Idade
        {
            get {return (int)(Math.Floor((DateTime.Now - DataNascimento).TotalDays / 365.25)); }
            private set {}
        }
                
        public override string ResumoCliente()
        {
            return $"{NumeroConta}  |  {Nome}  | {CPF}  |  {DataNascimento}  | {Endereco}  |  {Telefone}";
        }
        public bool EhMaior()
        {
            return Idade >= 18;
        }
    }
}