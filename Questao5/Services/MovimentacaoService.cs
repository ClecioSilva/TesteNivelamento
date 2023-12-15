using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Questao5.Models;

namespace Questao5.Services
{
    public class MovimentacaoService
    {

        public int RealizarMovimentacao(MovimentacaoContaCorrente movimentacao)
        {
            // Lógica de validação
            if (movimentacao.IdentificacaoContaCorrente <= 0)
            {
                throw new ArgumentException("Identificação da conta corrente inválida.", nameof(movimentacao.IdentificacaoContaCorrente));
            }
        
            if (movimentacao.Valor <= 0)
            {
                throw new ArgumentException("Valor inválido. Apenas valores positivos são aceitos.", nameof(movimentacao.Valor));
            }

            if (movimentacao.TipoMovimento != 'C' && movimentacao.TipoMovimento != 'D')
            {
                throw new ArgumentException("Tipo de movimento inválido. Apenas 'C' (Crédito) ou 'D' (Débito) são aceitos.", nameof(movimentacao.TipoMovimento));
            }

            // Lógica de persistência - Simulação de persistência retornando um ID de movimento
            int idMovimentoGerado = new Random().Next(1000, 9999);

            // Aqui você implementaria a lógica para persistir os dados na tabela MOVIMENTO

            return idMovimentoGerado;
        }

        internal object ObterTodasMovimentacoes()
        {
            throw new NotImplementedException();
        }
    }
}
    