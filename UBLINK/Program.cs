using System;
using UBLINK.Service;

namespace UBLINK
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                Escolha(opcaoUsuario);
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Hello World!");
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("\nCaixa a seu dispor !!");
            Console.WriteLine("Informe a opção desejada.\n");

            Console.WriteLine("1 - Quantidade de notas.");
            Console.WriteLine("2 - Inserir Notas.");
            Console.WriteLine("3 - Remover Notas.");
            Console.WriteLine("4 - Inserir Novo Tipo de Nota.");
            Console.WriteLine("5 - Sacar.");
            Console.WriteLine("6 - Valor Total em Caixa.");
            Console.WriteLine("C - Limpar Tela.");
            Console.WriteLine("X - Sair./n");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void Escolha(string opcao)
        {
            switch (opcao)
            {
                case "1":
                    MainMenu.QtdDeNotas();
                    break;

                case "2":
                    MainMenu.InserirNotas();
                    break;

                case "3":
                    MainMenu.RemoverNotas();
                    break;

                case "4":
                    MainMenu.InserirNovoValorDeNota();
                    break;

                case "5":
                    MainMenu.Sacar();
                    break;

                case "6":
                    Console.WriteLine(MainMenu.ValorTotalEmCaixa());
                    break;

                case "C":
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine("Opção Invalida.");
                    Console.Clear();
                    break;
            }
        }
    }
}
