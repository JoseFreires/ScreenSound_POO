using ScreenSound.Modelos;
using ScreenSound_POO.Menus;

Artista yungLi = new("Yung Li");
yungLi.AdicionarNota(new Avaliacao(10));
yungLi.AdicionarNota(new Avaliacao(9));
yungLi.AdicionarNota(new Avaliacao(10));
Artista joji = new("Joji");

Dictionary<string, Artista> artistasRegistrados = new ();
artistasRegistrados.Add(yungLi.Nome, yungLi);
artistasRegistrados.Add(joji.Nome, joji);

Dictionary<int, Menu> opcoes = new();
opcoes.Add(1, new MenuRegistrarArtista());
opcoes.Add(2, new MenuRegistrarAlbum());
opcoes.Add(3, new MenuMostrarArtistasRegistrados());
opcoes.Add(4, new MenuAvaliarUmArtista());
opcoes.Add(5, new MenuExibirDetalhes());
opcoes.Add(-1, new MenuSair());

void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine("Boas vindas ao Screen Sound 2.0!");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar um artista");
    Console.WriteLine("Digite 2 para registrar o álbum de um artista");
    Console.WriteLine("Digite 3 para mostrar todos os artistas");
    Console.WriteLine("Digite 4 para avaliar uma banda");
    Console.WriteLine("Digite 5 para exibir os detalhes de um artista");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    if (opcoes.ContainsKey(opcaoEscolhidaNumerica))
    {
        Menu menuEscolhido = opcoes[opcaoEscolhidaNumerica];
        menuEscolhido.Executar(artistasRegistrados);
        if(opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
    } else
    {
        Console.WriteLine("Opção inválida");
    }
}

ExibirOpcoesDoMenu();