using ScreenSound.Modelos;

namespace ScreenSound_POO.Menus;

internal class MenuRegistrarAlbum : Menu
{
    public override void Executar(Dictionary<string, Artista> artistasRegistrados)
    {
        base.Executar(artistasRegistrados);
        ExibirTituloDaOpcao("Registro de álbuns");
        Console.Write("Digite o artista cujo álbum deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (artistasRegistrados.ContainsKey(nomeDaBanda))
        {
            Console.Write("Agora digite o título do álbum: ");
            string tituloAlbum = Console.ReadLine()!;
            Artista artista = artistasRegistrados[nomeDaBanda];
            artista.AdicionarAlbum(new Album(tituloAlbum));
            Console.WriteLine($"O álbum {tituloAlbum} de {nomeDaBanda} foi registrado com sucesso!");
            Thread.Sleep(4000);
            Console.Clear();
        }
    }
}
