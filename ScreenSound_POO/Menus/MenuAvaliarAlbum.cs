using ScreenSound.Modelos;

namespace ScreenSound_POO.Menus;

internal class MenuAvaliarAlbum : Menu
{
    public override void Executar(Dictionary<string, Artista> artistasRegistrados)
    {
        base.Executar(artistasRegistrados);
        ExibirTituloDaOpcao("Avaliar Album");
        Console.Write("Digite o nome do artista que deseja avaliar: ");
        string nomeDaArtista = Console.ReadLine()!;
        if (artistasRegistrados.ContainsKey(nomeDaArtista))
        {
            Artista artista = artistasRegistrados[nomeDaArtista];
            Console.Write("Agora digite o título do álbum: ");
            string tituloAlbum = Console.ReadLine()!;
            if (artista.Albuns.Any(a => a.Nome.Equals(tituloAlbum)))
            {
                Album album = artista.Albuns.First(a => a.Nome.Equals(tituloAlbum));
                Console.Write($"Qual a nota que o album {tituloAlbum} merece: ");
                Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);
                album.AdicionarNota(nota);
                Console.WriteLine($"\nA nota {nota.Nota} foi registrada com sucesso para o album {nomeDaArtista}");
                Thread.Sleep(2000);
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"\nO album {nomeDaArtista} não foi encontrado!");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
            }
                
            
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
