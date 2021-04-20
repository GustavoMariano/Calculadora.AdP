using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.POO
{
    class Program
    {
        static void Main(string[] args)
        {
            int contador = 0;
            Calculos conta = new Calculos();
            while (true)
            {
                Console.WriteLine("O que deseja realizar? \n+ para soma \n- para subtração \n* para multiplcação \n/ para divisão" +
                    " \n. para visualizar o histórico \nS PARA SAIR)");
                conta.operacao = Console.ReadLine().ToLower();

                Console.Clear();
                conta.ValidaOperacaoSair();

                if (conta.operacao == ".")
                {
                    for (int i = 0; i < contador; i++)
                    {
                        Console.WriteLine(conta.historicoOperacoes[i]);
                    }

                    Console.ReadLine();
                }                

                Console.WriteLine("Digite o primeiro número: ");
                conta.primeiroElemento = Convert.ToDouble(Console.ReadLine());

                while (true)
                {
                    Console.WriteLine("Digite o segundo número:");
                    conta.segundoElemento = Convert.ToDouble(Console.ReadLine());
                    
                    if (conta.ValidaSegundoElementoDivisao() == false)
                    {
                        Console.WriteLine("O segundo número não pode ser 0(zero) na divisão, tente novamente");
                        continue;
                    }
                    break;
                }

                switch (conta.operacao)
                {
                    case "+": conta.Soma(); conta.AdicionaHistorico(contador); break;
                    case "-": conta.Subtracao(); conta.AdicionaHistorico(contador); break;
                    case "*": conta.Multiplicacao(); conta.AdicionaHistorico(contador); break;
                    case "/": conta.Divisao(); conta.AdicionaHistorico(contador); break;
                    default:
                        break;
                }

                Console.WriteLine("\nResultado: " + conta.resultado);
                Console.ReadLine();

                Console.Clear();
                contador++;
            }
        }
    }
}
