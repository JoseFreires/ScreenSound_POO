

using ScreenSound.Modelos;

namespace ScreenSound_POO.Menus;

internal class MenuMostrarArtistasRegistrados : Menu
{
    public override void Executar(Dictionary<string, Artista> artistasRegistrados)
    {
        base.Executar(artistasRegistrados);
        ExibirTituloDaOpcao("Exibindo todas os artistas registradas na nossa aplicação");

        foreach (string banda in artistasRegistrados.Keys)
        {
            Console.WriteLine($"Banda: {banda}");
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
