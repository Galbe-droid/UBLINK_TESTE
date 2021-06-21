using System;
using System.Collections.Generic;
using System.Text;

namespace UBLINK.Model
{
    class Notas
    {
        public int Valor { get; set; }
        public int QtNoCaixa { get; set; }

        public Notas() {}

        public Notas(int valor, int qtNoCaixa)
        {
            Valor = valor;
            QtNoCaixa = qtNoCaixa;
        }
    }
}
