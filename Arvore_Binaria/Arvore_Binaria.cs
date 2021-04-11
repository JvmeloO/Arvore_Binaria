using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvore_Binaria
{
    class Arvore_Binaria
    {
        private No Raiz { get; set; }

        private No Encontrado { get; set; }

        public Arvore_Binaria() 
        {
            Raiz = new No();
            Encontrado = new No();
        }

        public No GetRaiz()
        {
            return Raiz;
        }

        public void Inserir(int? Pai, int valor, char TipoFilho)
        {

            if (Pai == null && TipoFilho == 'R')
            {
                Raiz = new No(valor);
                Console.WriteLine("Raiz inserida!");
                return;
            }

            Buscar(valor);
            if (Encontrado.GetValor() == valor)
            {
                Console.WriteLine("O Nó a ser inserido já existe!");
                return;
            }

            Buscar(Pai.Value);
            if (TipoFilho == 'E' && Encontrado.TemFilhoEsq())
            {
                Console.WriteLine("Já possui filho esquerdo!");
                return;
            }
            if (TipoFilho == 'D' && Encontrado.TemFilhoDir())
            {
                Console.WriteLine("Já possui filho direito!");
                return;
            }

            if (TipoFilho == 'E')
            {
                Encontrado.InserirFilhoEsq(new No(valor, Encontrado));
                Console.WriteLine("Filho esquerdo inserido!");
            }
            if (TipoFilho == 'D')
            {
                Encontrado.InserirFilhoDir(new No(valor, Encontrado));
                Console.WriteLine("Filho direito inserido!");
            }

            Encontrado = new No();
        }

        public void Buscar(int NoProcurado)
        {
            Buscar(Raiz, NoProcurado);
        }

        private void Buscar(No Inicio, int NoProcurado)
        {
            if (Inicio != null)
            {
                if (NoProcurado.Equals(Inicio.GetValor()))
                {
                    Encontrado = Inicio;
                }

                Buscar(Inicio.GetFilhoEsq(), NoProcurado);
                Buscar(Inicio.GetFilhoDir(), NoProcurado);
            }
        }

        public void Remover(int NoRemover)
        {
            Buscar(NoRemover);
            if (Encontrado != null)
            {
                if (Encontrado.GetFilhoEsq() == null && Encontrado.GetFilhoDir() == null)
                {
                    Encontrado = null;
                    return;
                }

                if (Encontrado.GetFilhoEsq() != null && Encontrado.GetFilhoDir() != null)
                {
                    Console.WriteLine("O nó não pode ser removido!");
                    return;
                }

                var noPai = Encontrado.GetPai();
                No filhoExistente;
                if (Encontrado.GetFilhoEsq() != null)
                {
                    filhoExistente = Encontrado.GetFilhoEsq();
                }
                else
                {
                    filhoExistente = Encontrado.GetFilhoDir();
                }

                if (noPai.GetFilhoEsq() == Encontrado)
                {
                    noPai.InserirFilhoEsq(filhoExistente);
                }
                else
                {
                    noPai.InserirFilhoDir(filhoExistente);
                }
            }
        }

        public int Grau(No No)
        {
            if (No.GetFilhoEsq() != null && No.GetFilhoDir() != null)
            {
                return 2;
            }
            if (No.GetFilhoEsq() != null || No.GetFilhoDir() != null)
            {
                return 1;
            }

            return 0;
        }

        //public int Profundidade(No No)
        //{
        //    if (Raiz == No)
        //        return 0;

        //    if (Raiz != null)
        //    {
        //        if (No.Equals(Raiz.GetValor()))
        //        {
        //            return Inicio;
        //        }

        //        Buscar(Inicio.GetFilhoEsq(), NoProcurado);
        //        Buscar(Inicio.GetFilhoDir(), NoProcurado);
        //    }
        //}
    }
}