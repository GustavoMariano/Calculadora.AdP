using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.POO
{
    class Calculos
    {
        public double primeiroElemento, segundoElemento, resultado;
        public string operacao;
        public string[] historicoOperacoes = new string[10];

        public void ValidaOperacaoSair()
        {
            if(operacao == "s")
            {
                Environment.Exit(0);
            }
        }

        public void Soma()
        {
            resultado = primeiroElemento + segundoElemento;
        }

        public void Subtracao()
        {
            resultado = primeiroElemento - segundoElemento;

        }

        public void Multiplicacao()
        {
            resultado = primeiroElemento * segundoElemento;
        }

        public void Divisao()
        {
            resultado = primeiroElemento / segundoElemento;
        }

        public void AdicionaHistorico(int contador)
        {
            historicoOperacoes[contador] = $"{primeiroElemento} {operacao} {segundoElemento} = {resultado}";
        }

        public bool ValidaSegundoElementoDivisao()
        {
            if (operacao == "/" && segundoElemento == 0)
            {                
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
