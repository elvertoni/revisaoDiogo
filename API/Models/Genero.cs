namespace API.Models;
public class Genero
{
    public Genero() => CriadoEm = DateTime.Now;
    public int GeneroId { get; set; }
    public string? Nome { get; set; }
    public DateTime CriadoEm { get; set; }
}
