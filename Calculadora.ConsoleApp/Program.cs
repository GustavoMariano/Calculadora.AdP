using System;

namespace Calculadora.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Requisito Funcional 01 - Somar [OK]
            //Nossa calculadora deve ter a possibilidade de somar dois números
            #endregion

            #region Requisito Funcional 02 - Várias operações [OK]
            //Nossa calculadora deve ter a possibilidade fazer várias operações de soma
            #endregion

            #region Requisito Funcional 03 - Subtrair [OK]
            //Nossa calculadora deve ter a possibilidade fazer várias operações de soma e de subtração
            #endregion

            #region Requisito Funcional 04 - Quatro operações matemáticas [OK]
            //Nossa calculadora deve ter a possibilidade fazer as quatro operações básicas da matemática
            #endregion

            #region Requisito Funcional 05 - Validação do menu [OK]
            //Nossa calculadora deve validar a opções do menu [OK]
            #endregion

            #region Requisito Funcional 06 - Histórico de operações [OK]
            /** Nossa calculadora deve permitir visualizar as operações já realizadas
             *  Critérios:
             *      1 - A descrição da operação realizada deve aparecer assim, exemplo:
             *          2 + 2 = 4
             *          10 - 5 = 5
             */
            #endregion

            #region BUG 01 - Divisão  [OK]
            //Nossa calculadora deve realizar as operações com "0"
            #endregion

            #region
            //
            #endregion


            int contador = 0;
            double primeiroNumero = 0, segundoNumero = 0, resultado = 0;
            string[] historicoOperacoes = new string[10];
            string opcao = "", operacao = ""; 

            while(true)
            {
                Console.WriteLine("Digite 1 para Soma");

                Console.WriteLine("Digite 2 para Subtração");

                Console.WriteLine("Digite 3 para Multiplicação");

                Console.WriteLine("Digite 4 para Divisão");

                Console.WriteLine("Digite 5 para Exibir todos as operações já realizadas");

                Console.WriteLine("Digite S para Sair");                

                opcao = Console.ReadLine();

                if(opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "5" && opcao != "s" && opcao != "S"){

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Opção inválida, tente novamente!!");

                    Console.ResetColor();

                    Console.ReadLine();

                    Console.Clear();

                    continue;
                }

                if(opcao == "5")
                {
                    if(contador == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("Nenhuma operação foi realizada ainda, tente novamente!!");

                        Console.ResetColor();

                        Console.ReadLine();

                        Console.Clear();

                        continue;
                    }
                    for (int i = 0; i < 10; i++)
                    {
                            if (historicoOperacoes[i] != null)
                            {
                                Console.WriteLine(historicoOperacoes[i]);
                            }                        
                    }
                }

                if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();

                    break;
                }

                Console.WriteLine("Insira o primeiro número");

                primeiroNumero = Convert.ToDouble(Console.ReadLine());

                do
                {
                    Console.WriteLine("Insira o segundo número");

                    segundoNumero = Convert.ToDouble(Console.ReadLine());

                    if (opcao == "4" && segundoNumero == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("Valor inválido, tente novamente");

                        Console.ResetColor();
                    }
                } while (opcao == "4" && segundoNumero == 0);

                switch (opcao)
                {
                    case "1": resultado = primeiroNumero + segundoNumero; operacao = "+"; break;
                    case "2": resultado = primeiroNumero - segundoNumero; operacao = "-"; break;
                    case "3": resultado = primeiroNumero * segundoNumero; operacao = "*"; break;
                    case "4": resultado = primeiroNumero / segundoNumero; operacao = "/"; break;
                    default:
                        break;
                }

                historicoOperacoes[contador] = $"{primeiroNumero} {operacao} {segundoNumero} = {resultado}";

                contador++;

                Console.WriteLine("Resultado : " + resultado);

                Console.ReadLine();
            }
        }
    }
}
