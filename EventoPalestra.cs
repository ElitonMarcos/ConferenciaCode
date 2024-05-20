using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    internal class EventoPalestra : Evento
    {
        private Palestra palestra;
        
        private Palestra PalestraN { get => palestra; set => palestra=value; }
        public EventoPalestra(string nome) : base(nome)
        {
            this.SetNome(nome);
        }
        public EventoPalestra(string nome, int duracao, TimeSpan horaInicial,Palestra palestra ) : base(nome, duracao, horaInicial)
        {
            this.SetNome(nome);
            this.SetDuracao(duracao);
            this.SetHoraInicial(horaInicial);
            this.PalestraN = palestra;
        }

    }
}
