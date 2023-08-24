
public class Preguntas
{
    public int IdPregunta {get; set;}
    public int IdCategoria {get; set;}
    public int IdDificultad {get; set;}
    public string Enunciado {get; set;}
    public string Foto {get; set;}

    public Preguntas() { }

    public Preguntas(int idPregunta, int idCategoria, int idDificultad, string enunciado, string foto)
    {
        IdPregunta = idPregunta;
        IdCategoria = idCategoria;
        IdDificultad = idDificultad;
        Enunciado = enunciado;
        Foto = foto;
    }
}