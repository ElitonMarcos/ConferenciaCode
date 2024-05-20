using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    internal class Palestra
    {
        private string nome;
        private int duracao;
       

        public string Nome { get => nome; set => nome=value; }
        public int Duracao { get => duracao; set => duracao=value; }
       

        //public Palestra(string nome, int duracao)
        //{
        //    this.Nome = nome;
        //    this.Duracao = duracao;
        //}
        public Palestra()
        {
                
        }

    }
}
