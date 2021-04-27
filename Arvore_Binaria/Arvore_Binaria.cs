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

        private List<No> Arvore_Percurso { get; set; }

        private No RaizEncontrada { get; set; }

        private int MediaValoresArvore = 0;
        private int SomaValoresArvore = 0;
        private bool EstritamenteBinaria = true;

        public Arvore_Binaria()
        {
            Raiz = new No();
            NoEncontrado = new No();
            Arvore_Percurso = new List<No>();
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

        public List<No> ArvorePercursoInOrdem()
        {
            Console.WriteLine("\n\nRetornando a arvore no percurso abaixo!");
            InOrdem(Raiz);
            var Arvore_Percurso_Retorno = Arvore_Percurso;
            Arvore_Percurso = new List<No>();
            return Arvore_Percurso_Retorno;
        }

        public List<No> ArvorePercursoPreOrdem()
        {
            Console.WriteLine("\n\nRetornando a arvore no percurso abaixo!");
            PreOrdem(Raiz);
            var Arvore_Percurso_Retorno = Arvore_Percurso;
            Arvore_Percurso = new List<No>();
            return Arvore_Percurso_Retorno;
        }

        public List<No> ArvorePercursoPosOrdem()
        {
            Console.WriteLine("\n\nRetornando a arvore no percurso abaixo!");
            PosOrdem(Raiz);
            var Arvore_Percurso_Retorno = Arvore_Percurso;
            Arvore_Percurso = new List<No>();
            return Arvore_Percurso_Retorno;
        }

        public void PrintInOrdemPreOrdemPosOrdem()
        {
            Console.WriteLine("\nIn Ordem:");
            InOrdem(Raiz);
            Console.WriteLine("\nPre Ordem:");
            PreOrdem(Raiz);
            Console.WriteLine("\nPos Ordem:");
            PosOrdem(Raiz);
            Arvore_Percurso = new List<No>();
        }

        private void InOrdem(No Inicio)
        {
            if (Inicio != null)
            {
                InOrdem(Inicio.GetFilhoEsq());
                Arvore_Percurso.Add(new No(Inicio.GetValor(), Inicio.GetPai(), Inicio.GetFilhoEsq(), Inicio.GetFilhoDir()));
                Console.Write(Inicio.GetValor() + " ");
                InOrdem(Inicio.GetFilhoDir());
            }
        }

        private void PreOrdem(No Inicio)
        {
            if (Inicio != null)
            {
                Arvore_Percurso.Add(new No(Inicio.GetValor(), Inicio.GetPai(), Inicio.GetFilhoEsq(), Inicio.GetFilhoDir()));
                Console.Write(Inicio.GetValor() + " ");
                PreOrdem(Inicio.GetFilhoEsq());
                PreOrdem(Inicio.GetFilhoDir());
            }
        }

        private void PosOrdem(No Inicio)
        {
            if (Inicio != null)
            {
                PosOrdem(Inicio.GetFilhoEsq());
                PosOrdem(Inicio.GetFilhoDir());
                Arvore_Percurso.Add(new No(Inicio.GetValor(), Inicio.GetPai(), Inicio.GetFilhoEsq(), Inicio.GetFilhoDir()));
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

        public void EncontrarRaiz(No Inicio)
        {
            if (Inicio != null)
            {
                if (Inicio.GetPai() == null)
                    RaizEncontrada = Inicio;

                if (RaizEncontrada == null)
                    EncontrarRaiz(Inicio.GetPai());
                EncontrarRaiz(Inicio.GetFilhoEsq());
                EncontrarRaiz(Inicio.GetFilhoDir());
            }
        }

        public void PrintArvorePercursoInOrdemPreOrdemPosOrdem(List<No> Arvore_Percurso) 
        {
            EncontrarRaiz(Arvore_Percurso.FirstOrDefault());
            Console.WriteLine("\n\nArvore Percurso In Ordem:");
            PrintArvorePercursoInOrdem(RaizEncontrada);
            Console.WriteLine("\nArvore Percurso Pre Ordem:");
            PrintArvorePercursoPreOrdem(RaizEncontrada);
            Console.WriteLine("\nArvore Percurso Pos Ordem:");
            PrintArvorePercursoPosOrdem(RaizEncontrada);
            RaizEncontrada = null;
        }

        private void PrintArvorePercursoInOrdem(No Inicio)
        {
            if (Inicio != null)
            {
                PrintArvorePercursoInOrdem(Inicio.GetFilhoEsq());
                Console.Write(Inicio.GetValor() + " ");
                PrintArvorePercursoInOrdem(Inicio.GetFilhoDir());
            }
        }

        private void PrintArvorePercursoPreOrdem(No Inicio)
        {
            if (Inicio != null)
            {
                Console.Write(Inicio.GetValor() + " ");
                PrintArvorePercursoPreOrdem(Inicio.GetFilhoEsq());
                PrintArvorePercursoPreOrdem(Inicio.GetFilhoDir());
            }
        }

        private void PrintArvorePercursoPosOrdem(No Inicio)
        {
            if (Inicio != null)
            {
                PrintArvorePercursoPosOrdem(Inicio.GetFilhoEsq());
                PrintArvorePercursoPosOrdem(Inicio.GetFilhoDir());
                Console.Write(Inicio.GetValor() + " ");
            }
        }

        public void MenoresValores()
        {
            MediaValores(Raiz);
            Console.WriteLine("\n\nMenores valores da arvore: ");
            MenoresValores(Raiz, MediaValoresArvore);            
            SomaValoresArvore = 0;
            MediaValoresArvore = 0;
        }

        private void MediaValores(No Inicio) 
        {
            if (Inicio != null)
            {
                SomaValoresArvore += Inicio.GetValor();

                MediaValores(Inicio.GetFilhoEsq());                
                MediaValores(Inicio.GetFilhoDir());
            }

            MediaValoresArvore = SomaValoresArvore / NumeroNos(Raiz);            
        }

        private void MenoresValores(No Inicio, int media) 
        {
            if (Inicio != null)
            {
                if (Inicio.GetValor() < media)
                    Console.Write(Inicio.GetValor() + " ");

                MenoresValores(Inicio.GetFilhoEsq(), media);
                MenoresValores(Inicio.GetFilhoDir(), media);
            }
        }


        public void ArvoreEstritamenteBinaria()
        {
            ArvoreEstritamenteBinaria(Raiz);
            if (EstritamenteBinaria)
                Console.WriteLine("\n\nArvore Estritamente Binaria!");
            else
                Console.WriteLine("\n\nArvore nao Estritamente Binaria!");
            EstritamenteBinaria = true;
        }

        private void ArvoreEstritamenteBinaria(No Inicio) 
        {
            if (Inicio != null)
            {
                if (Inicio.GetPai() != null)
                    if (Inicio.GetPai().GetFilhoEsq() == null || Inicio.GetPai().GetFilhoDir() == null)
                        EstritamenteBinaria = false;

                ArvoreEstritamenteBinaria(Inicio.GetFilhoEsq());
                ArvoreEstritamenteBinaria(Inicio.GetFilhoDir());
            }
        }

        public void PaisMaioresFilhos() 
        {
            Console.WriteLine("\nPais e maiores Filhos: ");
            PaisMaioresFilhos(Raiz, new List<No>());
        }

        private void PaisMaioresFilhos(No Inicio, List<No> PaisTestados) 
        {
            if (Inicio != null)
            {
                if (Inicio.GetPai() != null && !(PaisTestados.Contains(Inicio.GetPai())))
                {
                    PaisTestados.Add(Inicio.GetPai());
                    Console.Write("Pai: " + Inicio.GetPai().GetValor() + " - ");

                    if (Inicio.GetPai().GetFilhoEsq() == null && Inicio.GetPai().GetFilhoDir() != null)
                        Console.Write("Maior Filho: " + Inicio.GetPai().GetFilhoDir().GetValor() + "\n");

                    if (Inicio.GetPai().GetFilhoDir() == null && Inicio.GetPai().GetFilhoEsq() != null)
                        Console.Write("Maior Filho: " + Inicio.GetPai().GetFilhoEsq().GetValor() + "\n");

                    if (Inicio.GetPai().GetFilhoEsq() != null && Inicio.GetPai().GetFilhoDir() != null)
                        if (Inicio.GetPai().GetFilhoEsq().GetValor() > Inicio.GetPai().GetFilhoDir().GetValor())
                            Console.Write("Maior Filho: " + Inicio.GetPai().GetFilhoEsq().GetValor() + "\n");
                        else
                            Console.Write("Maior Filho: " + Inicio.GetPai().GetFilhoDir().GetValor() + "\n");
                }

                PaisMaioresFilhos(Inicio.GetFilhoEsq(), PaisTestados);
                PaisMaioresFilhos(Inicio.GetFilhoDir(), PaisTestados);
            }
        }
    }
}