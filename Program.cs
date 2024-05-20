
using Modelos;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        TimeSpan horaInicial;
        TimeSpan horaFinal;
        TimeSpan limite;
        Trilhas trilha;
        Sessao isessao;
        List<Evento> eventoPalestraSessao;
        char periodo;
        int maxMinutos;
        EventoPalestra eventoP;

        var almoco = new Evento("Almoço");
        almoco.SetHoraInicial(TimeSpan.FromHours(12));
        almoco.SetDuracao(60);
        var networking = new Evento("Networking");
        ListaPalestra? palestras;
        string? json;
        string? nomeArquivo;
        List<Palestra> listaPalestrasOrder;
        var trilhas = new List<Trilhas>();
        var sessao = new List<Sessao>();
        var eventoPalestra = new List<Evento>();

        try
        {
            //Leitura do arquivo json
            nomeArquivo = "palestras.json";
            json = File.ReadAllText(nomeArquivo);
            palestras = JsonSerializer.Deserialize<ListaPalestra>(json);

            listaPalestrasOrder = palestras.listaPalestras.OrderByDescending(p => p.Duracao).ToList();

            for (int i = 1; i<=2; i++) //loop de trilhas
            {
                trilha = new Trilhas(i);
                trilhas.Add(trilha);
                for (int p = 1; p <= 2; p++) //loop de sessões
                {
                    if (p==1)
                    {
                        periodo = 'M';
                        maxMinutos = 180;
                        limite = TimeSpan.FromHours(12);
                        horaInicial = TimeSpan.FromHours(9);

                    }
                    else
                    {
                        periodo = 'V';
                        maxMinutos = 240;
                        limite = TimeSpan.FromHours(17);
                        horaInicial = TimeSpan.FromHours(13);

                    }
                    isessao = new Sessao(trilha, periodo);
                    eventoPalestraSessao = new List<Evento>();

                    isessao.SetMaximoMinutos(maxMinutos);

                    foreach (Palestra palestra in listaPalestrasOrder) //loop de palestras
                    {
                        horaFinal = horaInicial + TimeSpan.FromMinutes(palestra.Duracao);
                        if (horaFinal <= limite)
                        {
                            eventoP = new EventoPalestra(palestra.Nome, palestra.Duracao, horaInicial, palestra);
                            if (!eventoPalestra.Any(item => item.GetNome() == eventoP.GetNome()))
                            {
                                eventoPalestra.Add(eventoP); //Controle de Eventos adicionados
                                eventoPalestraSessao.Add(eventoP); //Palestras da Sessao
                                horaInicial += TimeSpan.FromMinutes(palestra.Duracao);
                                isessao.SetMinutos(palestra.Duracao);
                            }
                        }

                        if (horaInicial == TimeSpan.FromHours(12) && p==1)
                        {
                            eventoPalestraSessao.Add(almoco);
                            break;
                        }

                    }
                    if (p== 2)
                    {
                        networking.SetHoraInicial(horaInicial);
                        networking.SetDuracao(60);
                        eventoPalestraSessao.Add(networking);
                    }
                    isessao.SetEventos(eventoPalestraSessao);
                    sessao.Add(isessao);

                }

            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("Um erro inesperado ocorreu : " + ex.Message);
        }
        
        //Exibe saida de ordenação
        foreach (Sessao sessao1 in sessao)
        {
            Console.WriteLine("Trilha " + sessao1.GetTrilha().GetId().ToString() + " - Sessão " + sessao1.GetTipo());
            Console.WriteLine();
            foreach (Evento evento in sessao1.GetEventos())
            {
                Console.WriteLine(string.Format("{0:hh\\:mm}", evento.GetHoraInicial()) + " - " + evento.GetNome() + " - " + (evento.GetDuracao() == 5 ? "Relâmpago" : evento.GetDuracao()));
            }
            Console.WriteLine();
        }
    }
}