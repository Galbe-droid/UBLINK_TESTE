using System;
using System.Collections.Generic;
using System.Text;
using UBLINK.Model;

namespace UBLINK.Interface
{
    public interface IMainMenu
    {
        void QtdDeNotas();
        void ValorTotalEmCaixa();
        void InserirNotas();
        void RemoverNotas();
        void Sacar();
        void InserirNovoValorDeNota();
    }
}
