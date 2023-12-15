using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Questao5.Models;
using Questao5.Services;

namespace Questao5.Domain.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimentacaoController : ControllerBase
    {
        private readonly MovimentacaoService _movimentacaoService;

        public MovimentacaoController(MovimentacaoService movimentacaoService)
        {
            _movimentacaoService = movimentacaoService;
        }

        [HttpPost]
        public IActionResult RealizarMovimentacao(MovimentacaoContaCorrente movimentacao)
        {
            try
            {
                int idMovimentoGerado = _movimentacaoService.RealizarMovimentacao(movimentacao);
                return Ok(new { IdMovimento = idMovimentoGerado });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Tipo = "Bad Request", Mensagem = ex.Message });
            }
        }
    }
}