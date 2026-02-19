using ScreenSound.Modelos;

namespace ScreenSound_POO.Menus;

internal class MenuSair : Menu
{
    public override void Executar(Dictionary<string, Artista> artistasRegistrados) 
    {
        Console.WriteLine("Adeus");
    }

}
