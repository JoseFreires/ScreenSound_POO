Console.WriteLine("Bem-vindo ao SoundScreen 2.0 do Zé");

List<Podcast> podcasts = new List<Podcast>();

void GeraTituloMenu(string tela)
{
    Console.WriteLine($"-x-x-x- Menu {tela}  -x-x-x-\n");
}


void MenuPrincipal()
{
    Console.WriteLine("-x-x-x- Menu Principal -x-x-x-");
    Console.WriteLine("1 - Músicas");
    Console.WriteLine("2 - Álbums");
    Console.WriteLine("3 - Artistas");
    Console.WriteLine("4 - Podcasts");
    Console.Write("Digite qual tela deseja ir: ");
    int resposta = int.Parse(Console.ReadLine()!);

    switch (resposta)
    {
        case 1:
            MenuMusicas();
            break;
        case 2:
            MenuAlbums();
            break;
        case 3:
            MenuArtistas();
            break;
        case 4:
            MenuPodcasts();
            break;

        default:
            break;
    }
}

void MenuMusicas()
{
    Console.Clear();
    GeraTituloMenu("Músicas");
    Console.WriteLine("1 - Adicionar uma nova música");
    Console.WriteLine("2 - Visualizar as músicas salvas");
    Console.Write("Resposta: ");
    int resposta = int.Parse(Console.ReadLine()!);

    switch (resposta)
    {
        case 1:
            AddMusica();
            break;
        case 2:
            ExibirMusicas();
            break;

        default:
            Console.WriteLine("Nenhuma opção foi selecionada");
            break;
    }


}

void AddMusica()
{

}

void ExibirMusicas()
{

}

void MenuAlbums()
{
    Console.Clear();
    GeraTituloMenu("Album");
    Console.WriteLine("1 - Adicionar um novo album");
    Console.WriteLine("2 - Visualizar os albums salvos");
    Console.WriteLine("3 - Visualizar músicas de um album");

}

void MenuArtistas()
{
    Console.Clear();
    GeraTituloMenu("Artista");
    Console.WriteLine("1 - Adicionar um novo artista");
    Console.WriteLine("2 - Visualizar os artistas salvos");
    Console.WriteLine("3 - Visualizar albums do artista");

}

void MenuPodcasts()
{
    Console.Clear();
    GeraTituloMenu("Podcast");
    Console.WriteLine("1 - Adicionar um novo podcast");
    Console.WriteLine("2 - Adicionar episódios do Podcast");
    Console.WriteLine("3 - Visualizar os episodios do podcast");
    Console.WriteLine("4 - Visualizar os podcast salvos");
    Console.WriteLine("0 - <- Retornar");
    Console.Write("Resposta: ");
    int resposta = int.Parse(Console.ReadLine()!);

    switch (resposta)
    {
        case 1:
            AddPodcast();
            break;
        case 2:
            AddEpsPodcasts();
            break;
        case 3:
            ExibirEpsPodcasts();
            break;
        case 4:
            ExibirPodcasts();
            break;
        case 0:
            MenuPrincipal();
            break;

        default:
            Console.WriteLine("Nenhuma opção foi selecionada");
            break;
    }
}

void AddPodcast()
{
    Console.Clear();
    Console.WriteLine("Preencha as informações abaixo: ");
    Console.Write("Nome do podcast: ");
    string nome = Console.ReadLine()!;
    Console.Write("Nome do Host do Podcast: ");
    string host = Console.ReadLine()!;
    Podcast podcast = new Podcast(host, nome);
    podcasts.Add(podcast);

    Console.WriteLine("Criado com sucesso!!!");
    Thread.Sleep(1000);

    MenuPodcasts();
}

void AddEpsPodcasts()
{
    Console.Clear();
    Console.Write("Digite o nome do Podcast que deseja adicionar o episódio: ");
    string nomePodcast = Console.ReadLine()!;

    Console.WriteLine("Preencha as informações do episodio");
    Console.Write("Titulo: ");
    string titulo = Console.ReadLine()!;
    Console.Write("Duração(minutos): ");
    int duracao = int.Parse(Console.ReadLine()!);
    Console.Write("Ordem: ");
    int ordem = int.Parse(Console.ReadLine()!);
    Console.Write("Resumo: ");
    string resumo = Console.ReadLine()!;

    Episodio episodio = new Episodio(duracao, ordem, resumo, titulo);

    VerificaAddConvidados(episodio);

    foreach (Podcast podcast in podcasts)
    {
        if (podcast.Nome == nomePodcast)
        {
            Console.Clear();
            podcast.AddEpisodio(episodio);
            Console.WriteLine($"O episódio '{episodio.Titulo}' foi adicionado com sucesso em {podcast.Nome}");
            Console.ReadKey();

        } 
    }

    MenuPodcasts();
}

void VerificaAddConvidados(Episodio episodio)
{
    Console.Write("Possui convidados? (S/N) R: ");
    char resposta = char.Parse(Console.ReadLine()!);
    if (resposta == 'S' || resposta == 's')
    {
        Console.Write("Quantidade de convidados:");
        int quantidade = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < quantidade; i++)
        {
            Console.Write($"Nome do convidado {i+1}: ");
            string convidado = Console.ReadLine()!;
            episodio.AddConvidados(convidado);
        }

        Console.WriteLine("Convidados adicionados!");
        Thread.Sleep(2000);
    }
    else if (resposta == 'N' || resposta == 'n')
    {
        Console.WriteLine("Nenhum convidado adicionado!");
        Thread.Sleep(2000);
    }
}

void ExibirEpsPodcasts()
{
    Console.Clear();
    Console.WriteLine("Digite o nome do Podcast que deseja visualizar os episódios: ");
    string nomePodcast = Console.ReadLine()!;

    foreach (Podcast podcast in podcasts)
    {
        if (podcast.Nome == nomePodcast)
        {
            podcast.ExibirEpsPodcast();
        }
    }
    Console.ReadKey();
    Console.Clear();
    MenuPodcasts();
}

void ExibirPodcasts()
{
    Console.Clear();
    if (podcasts.Count > 0)
    {
        foreach (Podcast podcast in podcasts)
        {

            podcast.ExibirDetalhes();
            Console.ReadKey();
        }
    }
    else
    {
        Console.WriteLine("Nenhum podcast foi adicionado");
    }
    Console.Clear();
    MenuPodcasts();

}

MenuPrincipal();

