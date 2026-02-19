using ScreenSound.Modelos;

namespace ScreenSound_POO.Menus;

internal class MenuRegistrarArtista : Menu
{
    public override void Executar(Dictionary<string, Artista> artistasRegistrados)
    {
        base.Executar(artistasRegistrados);
        ExibirTituloDaOpcao("Registro dos artistas");
        Console.Write("Digite o nome do artista que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        Artista artista = new(nomeDaBanda);
        artistasRegistrados.Add(nomeDaBanda, artista);
        Console.WriteLine($"O artista {nomeDaBanda} foi registrado com sucesso!");
        Thread.Sleep(4000);
        Console.Clear();

    }
}
