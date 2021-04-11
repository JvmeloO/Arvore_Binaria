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

        private No NoEncontrado { get; set; }

        public Arvore_Binaria()
        {
            Raiz = new No();
            NoEncontrado = new No();
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
            if (NoEncontrado.GetValor() == valor)
            {
                Console.WriteLine("O Nó a ser inserido já existe!");
                return;
            }

            Buscar(Pai.Value);
            if (TipoFilho == 'E' && NoEncontrado.TemFilhoEsq())
            {
                Console.WriteLine("Já possui filho esquerdo!");
                return;
            }
            if (TipoFilho == 'D' && NoEncontrado.TemFilhoDir())
            {
                Console.WriteLine("Já possui filho direito!");
                return;
            }

            if (TipoFilho == 'E')
            {
                NoEncontrado.InserirFilhoEsq(new No(valor, NoEncontrado));
                Console.WriteLine("Filho esquerdo inserido!");
            }
            if (TipoFilho == 'D')
            {
                NoEncontrado.InserirFilhoDir(new No(valor, NoEncontrado));
                Console.WriteLine("Filho direito inserido!");
            }

            NoEncontrado = new No();
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
                    NoEncontrado = Inicio;
                }

                Buscar(Inicio.GetFilhoEsq(), NoProcurado);
                Buscar(Inicio.GetFilhoDir(), NoProcurado);
            }
        }

        public void Remover(int NoRemover)
        {
            Buscar(NoRemover);
            if (NoEncontrado != null)
            {
                if (NoEncontrado.GetFilhoEsq() == null && NoEncontrado.GetFilhoDir() == null)
                {
                    NoEncontrado = null;
                    return;
                }

                if (NoEncontrado.GetFilhoEsq() != null && NoEncontrado.GetFilhoDir() != null)
                {
                    Console.WriteLine("O nó não pode ser removido!");
                    return;
                }

                var noPai = NoEncontrado.GetPai();
                No filhoExistente;
                if (NoEncontrado.GetFilhoEsq() != null)
                {
                    filhoExistente = NoEncontrado.GetFilhoEsq();
                }
                else
                {
                    filhoExistente = NoEncontrado.GetFilhoDir();
                }

                if (noPai.GetFilhoEsq() == NoEncontrado)
                {
                    noPai.InserirFilhoEsq(filhoExistente);
                }
                else
                {
                    noPai.InserirFilhoDir(filhoExistente);
                }

                NoEncontrado = new No();
            }
        }

        public int Grau(int No)
        {
            Buscar(No);
            if (NoEncontrado.GetFilhoEsq() != null && NoEncontrado.GetFilhoDir() != null)
            {
                return 2;
            }
            if (NoEncontrado.GetFilhoEsq() != null || NoEncontrado.GetFilhoDir() != null)
            {
                return 1;
            }

            NoEncontrado = new No();
            return 0;
        }

        //public int Profundidade(int No)
        //{
        //}

        public void NumeroNos()
        {
            Console.WriteLine("Quantidade de nós: " + NumeroNos(Raiz));
        }

        private int NumeroNos(No Inicio)
        {
            if (Inicio == null)
                return 0;
            else
                return (1 + NumeroNos(Inicio.GetFilhoEsq()) + NumeroNos(Inicio.GetFilhoDir()));
        }

        public void AlturaNo(int NoAltura)
        {
            Buscar(NoAltura);
            Console.WriteLine("Altura do nó: " + AlturaNo(NoEncontrado));
            NoEncontrado = new No();
        }

        private int AlturaNo(No NoAltura) 
        {
            if (NoAltura == null || (NoAltura.GetFilhoDir() == null && NoAltura.GetFilhoEsq() == null))
                return 0;
            else 
            {
                if (AlturaNo(NoAltura.GetFilhoEsq()) > AlturaNo(NoAltura.GetFilhoDir()))
                    return (1 + AlturaNo(NoAltura.GetFilhoEsq()));
                else
                    return (1 + AlturaNo(NoAltura.GetFilhoDir()));
            }
        }
    }
}