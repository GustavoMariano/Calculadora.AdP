using System;

namespace Calculadora.ConsoleApp
{
    public class Program
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

        #region Requisito NÃO Funcional 01 - Organização do código [OK]
        /*
         */
        #endregion

        static void Main(string[] args)
        {
            int contador = 0;
            double primeiroNumero = 0, segundoNumero = 0, resultado = 0;
            string[] historicoOperacoes = new string[10];
            string opcao = "", operacao = "";

            while (true)
            {
                //Exibe o menu
                MostraMenu();

                //usuário insere a opção
                opcao = Console.ReadLine();

                //Verifica se a opção selecionada pelo usuário é válida
                if (OpcaoEhValida(opcao))
                {
                    //Retorna mensagem de erro "Opção inválida, tente novamente!!" em vermelho e repete
                    MensagemErro("Opção inválida, tente novamente!!");

                    continue;
                }

                //Verifica
                if (EhMostrarOperacoesAnteriores(opcao))
                {
                    if (ContadorEhZero(contador))
                    {
                        // Retorna mensagem de erro "Nenhuma operação foi realizada ainda, tente novamente!!" em vermelho e repete
                        MensagemErro("Nenhuma operação foi realizada ainda, tente novamente!!");

                        continue;
                    }
                    //Lista as operações anteriores (FOR)
                    MostraOperacoesAnteriores(historicoOperacoes);

                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                //Verifica se o usuário deseja encerrar a aplicação
                if (EhOpcaoParaSair(opcao))
                    break;

                //Solicita ao usuário o PRIMEIRO fator da operação
                MensagemSolicitandoFator("primeiro");
                primeiroNumero = Convert.ToDouble(Console.ReadLine());

                do
                {
                    //Solicita ao usuário o SEGUNDO fator da operação
                    MensagemSolicitandoFator("segundo");

                    segundoNumero = Convert.ToDouble(Console.ReadLine());

                    //Verifica se o segundo fator da divisão é 0 (zero)
                    if (DivisaoSegundoNumeroEhValido(segundoNumero, opcao))
                        // Retorna mensagem de erro "Valor inválido, tente novamente" em vermelho e repete
                        MensagemErro("Valor inválido, tente novamente");

                } while (DivisaoSegundoNumeroEhValido(segundoNumero, opcao));

                //Verifica qual operação foi selecionada pelo usuário
                VerificaOperacao(primeiroNumero, segundoNumero, ref resultado, opcao, ref operacao);

                //Carrega a array historicoOperacoes com a operação realizada
                historicoOperacoes[contador] = $"{primeiroNumero} {operacao} {segundoNumero} = {resultado}";

                //Gira o contador usado para carregar a Array historicoOperacoes
                contador++;

                //Exibe o resultado da operação
                Console.WriteLine("Resultado : " + resultado);
                Console.ReadLine();
                Console.Clear();
            }
        }
        #region Métodos

        private static void MensagemSolicitandoFator(string fator)
        {
            Console.WriteLine($"Insira o {fator} número");
        }

        private static bool DivisaoSegundoNumeroEhValido(double segundoNumero, string opcao)
        {
            return opcao == "4" && segundoNumero == 0;
        }

        private static bool ContadorEhZero(int contador)
        {
            return contador == 0;
        }

        private static bool OpcaoEhValida(string opcao)
        {
            return opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "5" && opcao != "s" && opcao != "S";
        }

        private static void VerificaOperacao(double primeiroNumero, double segundoNumero, ref double resultado, string opcao, ref string operacao)
        {
            switch (opcao)
            {
                case "1": resultado = primeiroNumero + segundoNumero; operacao = "+"; break;
                case "2": resultado = primeiroNumero - segundoNumero; operacao = "-"; break;
                case "3": resultado = primeiroNumero * segundoNumero; operacao = "*"; break;
                case "4": resultado = primeiroNumero / segundoNumero; operacao = "/"; break;
                default:
                    break;
            }
        }

        private static bool EhMostrarOperacoesAnteriores(string opcao)
        {
            return opcao == "5";
        }

        private static bool EhOpcaoParaSair(string opcao)
        {
            return opcao.Equals("s", StringComparison.OrdinalIgnoreCase);

            Console.Clear();
        }

        private static void MostraOperacoesAnteriores(string[] historicoOperacoes)
        {
            for (int i = 0; i < 10; i++)
                if (historicoOperacoes[i] != null)
                    Console.WriteLine(historicoOperacoes[i]);
        }

        private static void MensagemErro(String Msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(Msg);

            Console.ResetColor();

            Console.ReadLine();

            Console.Clear();
        }

        private static void MostraMenu()
        {
            Console.WriteLine("Calculadora AdP 2021 v. 1.7.1");

            Console.WriteLine("Digite 1 para Soma");

            Console.WriteLine("Digite 2 para Subtração");

            Console.WriteLine("Digite 3 para Multiplicação");

            Console.WriteLine("Digite 4 para Divisão");

            Console.WriteLine("Digite 5 para Exibir todos as operações já realizadas");

            Console.WriteLine("Digite S para Sair");
        }
        #endregion
    }
}
