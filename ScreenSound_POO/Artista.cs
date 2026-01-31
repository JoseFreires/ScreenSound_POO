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

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia dos {Nome}");
        foreach (Album album in albums) 
        { 
            Console.WriteLine($"Album: {album.Titulo}");
        }
    }
}