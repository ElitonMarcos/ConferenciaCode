using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    internal class Evento
    {
        private string nome;

        public string GetNome()
        {
            return nome;
        }

        public void SetNome(string value)
        {
            nome=value;
        }

        private int duracao;

        public int GetDuracao()
        {
            return duracao;
        }

        public void SetDuracao(int value)
        {
            duracao=value;
        }

        private TimeSpan horaInicial;

        public TimeSpan GetHoraInicial()
        {
            return horaInicial;
        }

        public void SetHoraInicial(TimeSpan value)
        {
            horaInicial=value;
        }
        public Evento(string nome)
        {
            this.nome = nome;
        }
        public Evento(string nome, int duracao, TimeSpan horaInicial)
        {
            this.nome = nome;
            this.duracao = duracao;
            this.horaInicial = horaInicial;

        }
    }
}
