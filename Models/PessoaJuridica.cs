using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio_S08.Models
{
   public class PessoaJuridica : Cliente
    {
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        /*public List<string> Socios { get; set; } = new List<string>();*/
        public DateTime DataAbertura { get; set; }

        public PessoaJuridica(string email, string telefone, string endereco, int numeroConta, List<Transacao> extrato, string cnpj, string razaoSocial, string nomeFantasia, DateTime dataAbertura) : base(email, telefone, endereco, numeroConta, extrato)
        {
            CNPJ = cnpj;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            DataAbertura = dataAbertura;
        }
         
        public override string ResumoCliente()
        {

            string resumo = $"{NumeroConta}  |  {RazaoSocial}  |  {CNPJ}  |  {NomeFantasia}";
            
                        
            return resumo;
        }
    }
}