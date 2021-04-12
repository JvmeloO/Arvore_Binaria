using System;

namespace Arvore_Binaria
{
    class Program
    {
        static void Main(string[] args)
        {
            Arvore_Binaria arvore_Binaria = new Arvore_Binaria();
            arvore_Binaria.Inserir(null, 30, 'R');
            arvore_Binaria.Inserir(30, 20, 'E');
            arvore_Binaria.Inserir(30, 28, 'D');
            arvore_Binaria.Inserir(20, 25, 'E');
            arvore_Binaria.Inserir(25, 27, 'E');
            arvore_Binaria.Inserir(20, 26, 'D');
            arvore_Binaria.NumeroNos();
            arvore_Binaria.AlturaNo(25);
            arvore_Binaria.Profundidade(25);
            //arvore_Binaria.Remover(25);
            arvore_Binaria.PrintarInOrdemPreOrdemPosOrdem();
            arvore_Binaria.InverterArvoreBinaria();
            arvore_Binaria.PrintarInOrdemPreOrdemPosOrdem();            
        }
    }
}
