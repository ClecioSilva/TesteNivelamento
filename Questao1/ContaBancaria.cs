using System;
using System.Globalization;

namespace Questao1
{
    class ContaBancaria 
    {
        public int Numero { get; private set; }
        public string Titular { get; private set; }
        public double Saldo { get; private set; }

        public ContaBancaria(int numero, string titular, double saldoInicial = 0)
        {
            Numero = numero;
            Titular = titular;
            Saldo = saldoInicial;
        }

        public void Deposito(double valor)
        {
            Saldo += valor;
        }

        public void Saque(double valor)
        {
            Saldo -= valor + 3.50; // Taxa de saque de $3.50
        }

        public override string ToString()
        {
            return $"Conta {Numero}, Titular: {Titular}, Saldo: $ {Saldo.ToString("F2")}";
        }
    }
}