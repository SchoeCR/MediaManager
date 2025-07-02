using System.Collections.Generic;

public class TMDBResult
{
    public string Media_type { get; set; }
    public string Title { get; set; }
    public string Name { get; set; }
    public string Release_date { get; set; }
    public string First_air_date { get; set; }
    public string Overview {  get; set; }
    public string Poster_path { get; set; }
}

public class TMDBResponse
{
    public List<TMDBResult> results { get; set; }
}

