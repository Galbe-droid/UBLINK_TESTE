using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UBLINK.Model
{
    class Caixa
    {
        public List<Notas> NotasEmCaixa { get; set; }

        public Caixa()
        {
            NotasEmCaixa = new List<Notas>();
            NotasEmCaixa.Add(new Notas(5, 0));
            NotasEmCaixa.Add(new Notas(10, 0));
            NotasEmCaixa.Add(new Notas(20, 0));
            NotasEmCaixa.Add(new Notas(50, 0));
            NotasEmCaixa.Add(new Notas(100, 0));
        }

        void AdcionarNotas(int valor, int quantidade)
        {
            if(NotasEmCaixa.Where(obj => obj.Valor == valor) == null)
            {
                NotasEmCaixa.Add(new Notas(valor, quantidade));
            }
            else
            {
                var nota = NotasEmCaixa.Where(obj => obj.Valor == valor).FirstOrDefault();
                nota.QtNoCaixa += quantidade;

                foreach (var notas in NotasEmCaixa)
                {
                    if(notas.Valor == nota.Valor)
                    {
                        notas.QtNoCaixa = nota.QtNoCaixa;
                    }
                }
            }
        }
    }
}
