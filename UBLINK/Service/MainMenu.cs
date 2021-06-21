using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UBLINK.Interface;
using UBLINK.Model;

namespace UBLINK.Service
{
    public static class MainMenu
    {
        static Caixa _caixaRepositorio = new Caixa();
        public static void InserirNotas()
        {
            var lista = _caixaRepositorio.NotasEmCaixa;
            QtdDeNotas();

            Console.Write("Qual o valor da nota que tera sua quantidade aumentada: ");
            int notaAumentarValor = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Quantas notas serão inseridas: ");
            int notaAumentarQtd = int.Parse(Console.ReadLine());

            if(lista.Where(obj => obj.Valor == notaAumentarValor) == null)
            {
                Console.WriteLine("Nota não encontrada");
            }
            else
            {
                Notas nota = lista.Where(obj => obj.Valor == notaAumentarValor).FirstOrDefault();

                nota.QtNoCaixa += notaAumentarQtd;

                foreach (Notas notasBusca in lista)
                {
                    if(notasBusca.Valor == nota.Valor)
                    {
                        notasBusca.QtNoCaixa = nota.QtNoCaixa;
                    }
                }
            }
        }

        public static void InserirNovoValorDeNota()
        {
            var lista = _caixaRepositorio.NotasEmCaixa;
            QtdDeNotas();

            Console.Write("Qual e o valor da nova nota: ");
            int novaNotaValor = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Quantas notas sera inserida no caixa: ");
            int novaNotaQtd = int.Parse(Console.ReadLine());

            if (lista.Where(obj => obj.Valor == novaNotaValor).FirstOrDefault() == null)
            {
                lista.Add(new Notas(novaNotaValor, novaNotaQtd));
            }
            else
            {
                Console.WriteLine("Ja existe uma nova com esse valor.");
            }
        }

        public static void QtdDeNotas()
        {
            bool semNotas = true;
            Console.WriteLine("Quantidade de Notas");

            var lista = _caixaRepositorio.NotasEmCaixa;

            foreach (Notas notas in lista)
            {
                if(notas.QtNoCaixa >= 1)
                {
                    semNotas = false;
                }
            }

            if (lista.Count <= 0)
            {
                Console.WriteLine("Nenhuma Nota cadastrada.");
                return;
            }
            else if(semNotas == true)
            {
                Console.WriteLine("Não ha notas nesse caixa");
                return;
            }
            else
            {
                foreach (Notas nota in lista)
                {
                    Console.WriteLine("Nota de {0} : Quantidade de Cedulas {1} ", nota.Valor, nota.QtNoCaixa);
                }
            }
        }

        public static void RemoverNotas()
        {
            var lista = _caixaRepositorio.NotasEmCaixa;
            QtdDeNotas();

            Console.Write("Qual o valor da nota que tera sua quantidade reduzida: ");
            int notaReduzirValor = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Quantas notas serão removidas: ");
            int notaReduzirQtd = int.Parse(Console.ReadLine());

            if (lista.Where(obj => obj.Valor == notaReduzirValor) == null)
            {
                Console.WriteLine("Nota não encontrada");
            }
            else
            {
                Notas nota = lista.Where(obj => obj.Valor == notaReduzirValor).FirstOrDefault();

                nota.QtNoCaixa -= notaReduzirQtd;

                foreach (Notas notasBusca in lista)
                {
                    if (notasBusca.Valor == nota.Valor)
                    {
                        notasBusca.QtNoCaixa = nota.QtNoCaixa;
                    }
                }
            }
        }

        public static void Sacar()
        {
            var lista = _caixaRepositorio.NotasEmCaixa;
            var valorTotalEmCaixa = ValorTotalEmCaixa();
            List<Notas> notasImpressas = new List<Notas>();

            Console.Write("Quantidade para sacar: ");
            int valorSaque = int.Parse(Console.ReadLine());


            //Verificar Valor de Saque
            if(valorSaque > valorTotalEmCaixa)
            {
                Console.Write("Valor insulficiente dentro do caixa, deseja sacar um valor aproximado ha {0} [S/N]", valorTotalEmCaixa);
                string opcao = Console.ReadLine().ToUpper();
                while (opcao != "N" && opcao != "S")
                {
                    Console.WriteLine("opcao invalida.");
                    opcao = Console.ReadLine().ToUpper();
                }

                if (opcao == "S")
                {
                    valorSaque = valorTotalEmCaixa;
                }
                else if (opcao == "N")
                {
                    return;
                }
            }


            //Iniciar Saque
            int soma = 0;

            foreach (Notas notas in lista)
            {
                for (int i = 0; i < notas.QtNoCaixa; i++)
                {
                    soma += notas.Valor;
                    
                    if(notasImpressas.Contains(notas))
                    {
                        var notaSelecionada = notasImpressas.Where(obj => obj.Valor == notas.Valor).FirstOrDefault();
                        notaSelecionada.QtNoCaixa++;
                        for (int j = 0; j < notasImpressas.Count; j++)
                        {
                            if(notasImpressas[j].Valor == notaSelecionada.Valor)
                            {
                                notasImpressas[j] = notaSelecionada;
                            }
                        }
                    }
                    else
                    {
                        notasImpressas.Add(new Notas(notas.Valor, 1));
                    }
                }
            }

            foreach (Notas nota in notasImpressas)
            {
                Console.WriteLine("Entregue - Nota de {0} : Quantidade de Cedulas {1} ", nota.Valor, nota.QtNoCaixa);
            }
        }

        public static int ValorTotalEmCaixa()
        {
            var lista = _caixaRepositorio.NotasEmCaixa;

            return lista.Sum(obj => obj.Valor * obj.QtNoCaixa);
        }
    }
}
