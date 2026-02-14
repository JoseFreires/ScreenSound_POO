using System.Net;

Console.WriteLine("Bem-vindo ao SoundScreen 2.0 do Zé");

List<Podcast> podcasts = new ();
List<Artista> artistas = new();
artistas.Add(new Artista("Yung Li"));
artistas.Add(new Artista("Joji"));
artistas.Add(new Artista("Tyler The Creator"));
artistas[0].AddAlbum(new Album("Quarentapes"));



void GeraTituloMenu(string tela)
{
    Console.WriteLine($"-x-x-x- Menu {tela}  -x-x-x-\n");
}


void MenuPrincipal()
{
    Console.Clear();
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

// --------------- Parte das Músicas ---------------

void MenuMusicas()
{
    Console.Clear();
    GeraTituloMenu("Músicas");
    Console.WriteLine("1 - Adicionar uma nova música");
    Console.WriteLine("2 - Visualizar as músicas salvas");
    Console.WriteLine("0 - <- Retornar");
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
        case 0:
            MenuPrincipal();
            break;
        default:
            Console.WriteLine("Nenhuma opção foi selecionada");
            break;
    }


}

void AddMusica()
{
    Console.Clear();
    Console.WriteLine("--- Adicionar nova música ---");
    if(artistas.Count > 0)
    {
        Console.Write("A música que deseja adicionar é de qual artista? R: ");
        string respostaNomeArtista = Console.ReadLine()!;
        foreach(Artista artista in artistas)
        {
            if(artista.Nome == respostaNomeArtista)
            {
                if(artista.QuantAlbums() > 0)
                {
                    Console.WriteLine();
                    artista.ExibirDiscografia();
                    Console.WriteLine();
                    Console.Write("E ela pertence a qual album? R: ");
                    string respostaTituloAlbum = Console.ReadLine()!;
                    foreach (Album album in artista.RetornarAlbums())
                    {
                        if (album.Titulo == respostaTituloAlbum)
                        {
                            Console.Clear();
                            Console.WriteLine("--- Informações da nova música ---");
                            Console.Write("Nome: ");
                            string nome = Console.ReadLine()!;
                            Console.Write("Duração: ");
                            int duracao = int.Parse(Console.ReadLine()!);
                            Console.Write("O ano que foi lançado: ");
                            int ano = int.Parse(Console.ReadLine()!);
                            Console.Write("O genero da música: ");
                            string genero = Console.ReadLine()!;

                            Musica musica = new Musica(nome, duracao, ano, new Genero(genero));
                            album.AddMusica(musica);
                            Console.WriteLine("Música adicionada com sucesso!");
                            Thread.Sleep(3000);

                            MenuMusicas();

                        }
                    }

                    Console.Write("Nenhum album com esse nome foi encontrado, gostaria de criar o album? R: ");
                    string resposta = Console.ReadLine()!.ToUpper();
                    if (resposta == "S")
                    {
                        Console.WriteLine("Indo para o menu de Albums...");
                        Thread.Sleep(3000);
                        MenuAlbums();
                    }
                    else
                    {
                        Console.WriteLine("Retornando ao menu de Músicas...");
                        Thread.Sleep(3000);
                        MenuMusicas();
                    }
                }
                else
                {
                    Console.WriteLine("Esse artista não possui nenhum álbum, necessário criar um...");
                    Thread.Sleep(3000);
                    AddAlbum();

                }


            }
            
        }
        Console.WriteLine("Não existe esse artista registrado, necessário adiciona-lo para adicionar a música");
        Thread.Sleep(3000);
        MenuArtistas();
    }
    else
    {
        Console.WriteLine("Não existe nenhum artista registrado, necessário adicionar um para adicionar a música");
        Thread.Sleep(3000);
        MenuArtistas();
    }

}

void ExibirMusicas()
{
    Console.Clear();
    Console.WriteLine("--- Visualizar as músicas ---");

    if (artistas.Count > 0)
    {
        Console.Write("A música que deseja visualizar é de qual artista? R: ");
        string respostaNomeArtista = Console.ReadLine()!;
        foreach (Artista artista in artistas)
        {
            if (artista.Nome == respostaNomeArtista)
            {
                if (artista.QuantAlbums() > 0)
                {
                    Console.WriteLine();
                    artista.ExibirDiscografia();
                    Console.WriteLine();
                    Console.Write("E ela pertence a qual album? R: ");
                    string respostaTituloAlbum = Console.ReadLine()!;
                    foreach (Album album in artista.RetornarAlbums())
                    {
                        if (album.Titulo == respostaTituloAlbum)
                        {
                            Console.WriteLine();
                            if(album.QuantMusicas > 0)
                            {
                                album.ExibirListaMusicas();
                                Thread.Sleep(3000);
                                MenuMusicas();
                            }
                            else
                            {
                                Console.Write($"O album {album.Titulo} não possui nenhuma música, deseja adicionar? R: ");
                                string respostaAddMusica = Console.ReadLine()!.ToUpper();
                                if (respostaAddMusica == "S")
                                {
                                    Console.WriteLine("Indo para o menu de Adicionar Músicas...");
                                    Thread.Sleep(3000);
                                    AddMusica();
                                }
                                else
                                {
                                    Console.WriteLine("Retornando ao menu principal...");
                                    Thread.Sleep(3000);
                                    MenuPrincipal();
                                }
                            }
                        }
                    }

                    Console.Write("Nenhum album com esse nome foi encontrado, gostaria de criar o album? R: ");
                    string respostaCriacaoAlbum = Console.ReadLine()!.ToUpper();
                    if (respostaCriacaoAlbum == "S")
                    {
                        Console.WriteLine("Indo para o menu de Albums...");
                        Thread.Sleep(3000);
                        MenuAlbums();
                    }
                    else
                    {
                        Console.WriteLine("Retornando ao menu de Músicas...");
                        Thread.Sleep(3000);
                        MenuMusicas();
                    }
                }
                
                Console.WriteLine("Esse artista não possui nenhum álbum, necessário criar um...");
                Thread.Sleep(3000);
                AddAlbum();



            }
            
            Console.WriteLine("Não existe esse artista registrado, necessário adiciona-lo para adicionar a música");
            Thread.Sleep(3000);
            MenuArtistas();

            

        }
    }
    
    Console.WriteLine("Não existe nenhum artista registrado, necessário adicionar um para adicionar a música");
    Thread.Sleep(3000);
    MenuArtistas();

}

// --------------- Parte dos Albums ---------------

void MenuAlbums()
{
    Console.Clear();
    GeraTituloMenu("Album");
    Console.WriteLine("1 - Adicionar um novo album");
    Console.WriteLine("2 - Visualizar os albums salvos");
    Console.WriteLine("3 - Visualizar músicas de um album");
    Console.WriteLine("0 - <- Retornar");
    Console.Write("Resposta: ");
    int resposta = int.Parse(Console.ReadLine()!);

    switch (resposta)
    {
        case 1:
            AddAlbum();
            break;
        case 2:
            ExibirAlbums();
            break;
        case 3:
            ExibirMusicas();
            break;
        case 0:
            MenuPrincipal();
            break;

        default:
            Console.WriteLine("Nenhuma opção foi selecionada");
            break;
    }
}

void AddAlbum()
{
    Console.Clear();
    Console.WriteLine("--- Adicionar novo álbum ---");
    Console.Write("O álbum que deseja adicionar é de qual artista? R: ");
    string respostaNomeArtista = Console.ReadLine()!;

    foreach (Artista artista in artistas)
    {
        if (artista.Nome == respostaNomeArtista)
        {
            Console.Write("Titulo: ");
            string titulo = Console.ReadLine()!;
            Album album = new Album(titulo);
            artista.AddAlbum(album);
            Console.Write($"Album {titulo} criado com sucesso!");
            Thread.Sleep(3000);
            MenuAlbums();
            

        }
    }

    Console.Write("Nenhum album com esse nome foi encontrado, gostaria de criar o album? R: ");
    string resposta = Console.ReadLine()!.ToUpper();
    if (resposta == "S")
    {
        Console.WriteLine("Indo para o menu de Albums...");
        Thread.Sleep(3000);
        MenuAlbums();
    }
    else
    {
        Console.WriteLine("Retornando ao menu de Músicas...");
        Thread.Sleep(3000);
        MenuMusicas();
    }

}

void ExibirAlbums()
{
    Console.Clear();
    Console.WriteLine("--- Visualizar álbums salvos ---");
    Console.Write("Os álbums que deseja visualizar é de qual artista? R: ");
    string respostaNomeArtista = Console.ReadLine()!;

    foreach (Artista artista in artistas)
    {
        if (artista.Nome == respostaNomeArtista)
        {
            artista.ExibirCadaAlbum();

        }
    }

    Thread.Sleep(3000);
    MenuAlbums();
}
// --------------- Parte dos Artistas ---------------
void MenuArtistas()
{
    Console.Clear();
    GeraTituloMenu("Artista");
    Console.WriteLine("1 - Adicionar um novo artista");
    Console.WriteLine("2 - Visualizar os artistas salvos");
    Console.WriteLine("3 - Visualizar albums do artista");
    Console.WriteLine("0 - <- Retornar");
    Console.Write("Resposta: ");
    int resposta = int.Parse(Console.ReadLine()!);

    switch (resposta)
    {
        case 1:
            AddArtista();
            break;
        case 2:
            ExibirArtistas();
            break;
        case 3:
            ExibirAlbums();
            break;
        case 0:
            MenuPrincipal();
            break;

        default:
            Console.WriteLine("Nenhuma opção foi selecionada");
            break;
    }
}

void AddArtista()
{
    Console.Clear();
    Console.WriteLine("--- Adicionando Artistas ---");
    Console.Write("Qual o nome do artista que deseja adicionar? R: ");
    string respostaNomeArtista = Console.ReadLine()!;

    foreach (Artista artista in artistas)
    {
        if (artista.Nome == respostaNomeArtista)
        {
            Console.WriteLine("Esse artista já existe. Te encaminhando para o menu de lista de Artistas...");
            ExibirArtistas();
            Thread.Sleep(3000);
            MenuArtistas();

        } else
        {
            Artista artistaNovo = new Artista(respostaNomeArtista);
            Console.WriteLine("Artista adicionado com sucesso!!");
            Thread.Sleep(3000);
            MenuArtistas();

        }
    }
}

void ExibirArtistas()
{
    Console.Clear();
    Console.WriteLine("--- Visualizando Artistas ---");
    foreach(Artista artista in artistas)
    {
        artista.ExibirDiscografia();
        Console.WriteLine();
        
    }
    Thread.Sleep(3000);
    MenuArtistas();
}


// --------------- Parte dos Podcasts ---------------
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

