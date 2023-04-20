using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Exercicio_S08.Models;
using Exercicio_S08.Interfaces;

namespace Exercicio_S08.Controllers
{
    [Microsoft.AspNetCore.Components.Route("transacao")]
    public class TransacaoController : Controller
    
    {
       private IClienteServices _clienteService;

    public TransacaoController(IClienteServices clienteServices)
    {
        _clienteService = clienteServices;
    }

    [HttpPost ("{idCliente}")]
    public ActionResult AdicionarTransacao([FromBody] Transacao transacao, [FromRoute] int idCliente)
    {
        _clienteService.AdicionarTransacao(transacao, idCliente);
        return Created(Request.Path, transacao);
    }

    [HttpGet ("{idCliente}")]
    public ActionResult ListarTransacao([FromRoute] int idCliente)
    {
        return Ok(_clienteService.ListarTransacao(idCliente));
    }
    }
}