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
            var noPai = NoEncontrado.GetPai();
            if (NoEncontrado != null)
            {
                if (NoEncontrado.GetFilhoEsq() == null && NoEncontrado.GetFilhoDir() == null)
                {
                    if (noPai.GetFilhoEsq() == NoEncontrado)
                    {
                        noPai.InserirFilhoEsq(null);
                        Console.WriteLine("\nNó removido!");
                        return;
                    }
                    else
                    {
                        noPai.InserirFilhoDir(null);
                        Console.WriteLine("\nNó removido!");
                        return;
                    }
                }

                if (NoEncontrado.GetFilhoEsq() != null && NoEncontrado.GetFilhoDir() != null)
                {
                    Console.WriteLine("\nO nó não pode ser removido!");
                    return;
                }
                
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
                    Console.WriteLine("\nNó removido!");
                }
                else
                {                    
                    noPai.InserirFilhoDir(filhoExistente);
                    Console.WriteLine("\nNó removido!");
                }                
            }
            NoEncontrado = new No();
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

        public void Profundidade(int No)
        {
            Buscar(No);
            Console.WriteLine("\nProfundidade do nó: " + Pronfundidade(NoEncontrado));
            NoEncontrado = new No();
        }

        private int Pronfundidade(No NoProfundidade)
        {
            if (NoProfundidade == Raiz)
            {
                return 0;
            }

            return (1 + Pronfundidade(NoProfundidade.GetPai()));
        }

        public void NumeroNos()
        {
            Console.WriteLine("\nQuantidade de nós: " + NumeroNos(Raiz));
        }

        private int NumeroNos(No Inicio)
        {
            if (Inicio == null)
                return 0;

            return (1 + NumeroNos(Inicio.GetFilhoEsq()) + NumeroNos(Inicio.GetFilhoDir()));
        }

        public void AlturaNo(int NoAltura)
        {
            Buscar(NoAltura);
            Console.WriteLine("\nAltura do nó: " + AlturaNo(NoEncontrado));
            NoEncontrado = new No();
        }

        private int AlturaNo(No NoAltura) 
        {
            if (NoAltura == null || (NoAltura.GetFilhoDir() == null && NoAltura.GetFilhoEsq() == null))
                return 0;

            if (AlturaNo(NoAltura.GetFilhoEsq()) > AlturaNo(NoAltura.GetFilhoDir()))
                return (1 + AlturaNo(NoAltura.GetFilhoEsq()));
            else
                return (1 + AlturaNo(NoAltura.GetFilhoDir()));
        }

        public void PrintarInOrdemPreOrdemPosOrdem() 
        {
            Console.WriteLine("\nIn Ordem:");
            InOrdem(Raiz);
            Console.WriteLine("\nPre Ordem:");
            PreOrdem(Raiz);
            Console.WriteLine("\nPos Ordem:");
            PosOrdem(Raiz);
        }

        private void InOrdem(No Inicio)
        {
            if (Inicio != null)
            {
                InOrdem(Inicio.GetFilhoEsq());
                Console.Write(Inicio.GetValor() + " ");
                InOrdem(Inicio.GetFilhoDir());
            }
        }

        private void PreOrdem(No Inicio) 
        {
            if (Inicio != null)
            {
                Console.Write(Inicio.GetValor() + " ");
                InOrdem(Inicio.GetFilhoEsq());                
                InOrdem(Inicio.GetFilhoDir());
            }
        }

        private void PosOrdem(No Inicio) 
        {
            if (Inicio != null)
            {
                InOrdem(Inicio.GetFilhoEsq());               
                InOrdem(Inicio.GetFilhoDir());
                Console.Write(Inicio.GetValor() + " ");
            }
        }

        public void InverterArvoreBinaria() 
        {
            Console.WriteLine("\n\nInvertendo Arvore...");
            No filhoEsq = Raiz.GetFilhoEsq();
            No filhoDir = Raiz.GetFilhoDir();
            Raiz.InserirFilhoEsq(filhoDir);
            Raiz.InserirFilhoDir(filhoEsq);
        }
    }
}