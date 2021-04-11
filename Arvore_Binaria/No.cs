using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvore_Binaria
{
    class No
    {
        private int Valor { get; set; }
        private No FilhoEsq { get; set; }
        private No FilhoDir { get; set; }
        private No Pai { get; set; }

        public No() { }

        public No(int Valor)
        {
            this.Valor = Valor;
        }

        public No(int Valor, No Pai)
        {
            this.Valor = Valor;
            this.Pai = Pai;
            FilhoDir = FilhoEsq = null;
        }

        public No GetFilhoDir() 
        {
            return FilhoDir;
        }

        public No GetFilhoEsq() 
        {
            return FilhoEsq;
        }

        public int GetValor() 
        {
            return Valor;
        }

        public No GetPai() 
        {
            return Pai;
        }

        public bool TemFilhoEsq() 
        {
            if (FilhoEsq == null)
                return false;

            return true;
        }

        public bool TemFilhoDir()
        {
            if (FilhoDir == null)
                return false;

            return true;
        }

        public void InserirFilhoEsq(No FilhoEsq) 
        {
            this.FilhoEsq = FilhoEsq;
        }

        public void InserirFilhoDir(No FilhoDir) 
        {
            this.FilhoDir = FilhoDir;
        }
    }
}
