class Artista
{
    public string Nome { get; set; }
    private List<Album> albums = new List<Album>();


    public Artista(string nome)
    {
        Nome = nome;
    }

    public void AddAlbum(Album album)
    {
        albums.Add(album);
    }

    public int QuantAlbums()
    {
        return albums.Count;
    }

    public void ExibirCadaAlbum()
    {
        foreach (Album album in albums)
        {
            Console.WriteLine($"- {album.Titulo}");
        }
    }

    public List<Album> RetornarAlbums()
    {
        return albums;
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia do {Nome}");
        if(albums.Count == 0)
        {
            Console.WriteLine("Nenhum álbum salvo para este artista...");
        }
        else
        {
            foreach (Album album in albums)
            {
                Console.WriteLine($"Album: {album.Titulo}");
            }
        }
            
    }
}