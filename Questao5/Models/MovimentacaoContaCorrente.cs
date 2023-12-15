using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questao5.Models
{
    public class MovimentacaoContaCorrente
    {
        public string IdentificacaoRequisicao { get; set; }
        public int IdentificacaoContaCorrente { get; set; }
        public decimal Valor { get; set; }
        public char TipoMovimento { get; set; }
    }
}