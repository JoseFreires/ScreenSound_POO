

using ScreenSound.Modelos;

namespace ScreenSound_POO.Menus;

internal class MenuExibirDetalhes : Menu
{

    public override void Executar(Dictionary<string, Artista> artistasRegistrados)
    {
        base.Executar(artistasRegistrados);
        ExibirTituloDaOpcao("Exibir detalhes do artista");
        Console.Write("Digite o nome do artista que deseja conhecer melhor: ");
        string nomeDaArtista = Console.ReadLine()!;
        if (artistasRegistrados.ContainsKey(nomeDaArtista))
        {
            Artista artista = artistasRegistrados[nomeDaArtista];
            Console.WriteLine($"\nA média da banda {nomeDaArtista} é {artista.Media}.");
            /**
            * ESPAÇO RESERVADO PARA COMPLETAR A FUNÇÃO
            */
            Console.WriteLine("Digite uma tecla para votar ao menu principal");
            Console.ReadKey();
            Console.Clear();

        }
        else
        {
            Console.WriteLine($"\nO artista {nomeDaArtista} não foi encontrado!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
