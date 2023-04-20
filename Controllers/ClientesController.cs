using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercicio_S08.Models;
using Exercicio_S08.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio_S08.Controllers
{
    [Route("clientes")]
    public class ClientesController : Controller
    {
        private IClienteServices _clienteServices;

        public ClientesController(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        [HttpGet]
        [Route("pessoafisica")]
        public ActionResult ExibirPessoasFisicas()
        {
            return Ok(_clienteServices.ExibirClientesPF());
        }

        [HttpGet]
        [Route("pessoajuridica")]
        public ActionResult ExibirPessoasJuridicas()
        {
            return Ok(_clienteServices.ExibirClientesPJ());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetPorId([FromRoute] int id)
        {
            return Ok(_clienteServices.BuscarCliente(id));
        }

        [HttpPost]
        [Route("pessoafisica")]
        public ActionResult PostPessoaFisica([FromBody] PessoaFisica pessoaFisica)
        {
            _clienteServices.CriarConta(pessoaFisica);
            return Created(Request.Path, pessoaFisica);
        }

        [HttpPost]
        [Route("pessoajuridica")]
        public ActionResult PostPessoaJuridica([FromBody] PessoaJuridica pessoaJuridica)
        {
            _clienteServices.CriarConta(pessoaJuridica);
            return Created(Request.Path, pessoaJuridica);
        }

        [HttpPut]
        [Route("pessoafisica/{id}")]
        public ActionResult AtualizarPessoaFisica([FromBody] PessoaFisica pessoaFisica, int id)
        {
            _clienteServices.AtualizarPessoaFisica(pessoaFisica, id);
            return Ok();
        }

        [HttpPut]
        [Route("pessoajuridica/{id}")]
        public ActionResult AtualizarPessoaJuridica([FromBody] PessoaJuridica pessoaJuridica, int id)
        {
            _clienteServices.AtualizarPessoaJuridica(pessoaJuridica, id);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeletarCliente([FromRoute] int id)
        {
            Cliente clienteDeletar = _clienteServices.BuscarCliente(id);

            if (clienteDeletar.Saldo != 0)
            {
                return BadRequest($"Não foi possível deletar cliente. Cliente há saldo de: {clienteDeletar.Saldo}");
            }

            _clienteServices.DeletarCliente(id);
            return Ok();
        }
    } 
}