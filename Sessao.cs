using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    internal class Sessao
    {
        private Trilhas trilha;
        private char tipo;
        private int maximoMinutos;

        public Trilhas GetTrilha()
        {
            return trilha;
        }

        public void SetTrilha(Trilhas value)
        {
            trilha=value;
        }

        public string GetTipo()
        {
            if (tipo=='M')
                return "Matutina";
            else if (tipo=='V')
                return "Vespertina";
            else
                throw new Exception("Tipo de Sessão Inválido!");

        }

        public void SetTipo(char value)
        {
            tipo=value;
        }

        private int minutos;

        public int GetMinutos()
        {
            return minutos;
        }

        public void SetMinutos(int value)
        {
            minutos+=value;
            if (minutos > maximoMinutos)
            {
                throw new Exception("Máximo de minutos excedido!");
            }

        }

        public int GetMaximoMinutos()
        {
            return maximoMinutos;
        }

        public void SetMaximoMinutos(int value)
        {
            maximoMinutos=value;
        }

        private List<Evento> eventos;

        public List<Evento> GetEventos()
        {
            return eventos;
        }

        public void SetEventos(List<Evento> value)
        {
            eventos=value;
        }

        public Sessao(Trilhas trilha, char tipo)
        {
            this.SetTrilha(trilha);
            this.SetTipo(tipo);
        }
    }
}
