// Crie duas Rotas POST :

// Pessoa Fisica
// Uma para cadastrar pessoas fisicas POST /Clientes/pessoafisica 
//para criar uma nova conta (Cliente), a rota deve receber no BODY o objeto PessoaFisica 
//que será cadastrado.
// ‌

// Pessoa Jurídica
// Uma para cadastrar pessoas juridicas POST /Clientes/pessoaJuridica 
//para criar uma nova conta (Cliente), a rota deve receber no BODY o objeto PessoaJurídica 
//que será cadastrado.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Exercicio_S08.Controllers
{
    [Route("[controller]")]
    public class ClientesController : Controller
    {
        private object _clienteServices;

        [HttpPost] [Route("pessoafisica")]
        public ActionResult PostPessoaFisica([FromBody] PessoaFisica pessoaFisica)
    {
        _clienteServices.CriarConta(pessoaFisica);
        return Created(Request.Path, pessoaFisica);
    }


    [HttpPost] [Route("pessoajuridica")]
        public ActionResult PostPessoaJuridica([FromBody] PessoaJuridica pessoaJuridica)
    {
        _clienteServices.CriarConta(pessoaJuridica);
        return Created(Request.Path, pessoaJuridica);
    }
    }
}