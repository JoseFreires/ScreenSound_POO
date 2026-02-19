

using ScreenSound.Modelos;

namespace ScreenSound_POO.Menus;

internal class MenuAvaliarUmArtista : Menu
{
    public override void Executar(Dictionary<string, Artista> artistasRegistrados)
    {
        base.Executar(artistasRegistrados);
        ExibirTituloDaOpcao("Avaliar Artista");
        Console.Write("Digite o nome do artista que deseja avaliar: ");
        string nomeDaArtista = Console.ReadLine()!;
        if (artistasRegistrados.ContainsKey(nomeDaArtista))
        {
            Artista artista = artistasRegistrados[nomeDaArtista];
            Console.Write($"Qual a nota que o artista {nomeDaArtista} merece: ");
            Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);
            artista.AdicionarNota(nota);
            Console.WriteLine($"\nA nota {nota.Nota} foi registrada com sucesso para {nomeDaArtista}");
            Thread.Sleep(2000);
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaArtista} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}