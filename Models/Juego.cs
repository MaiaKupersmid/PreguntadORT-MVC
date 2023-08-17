namespace TP7_PreguntadORT.Models;
public static class Juego 
{
    private static string Username {get; set;}
    private static int cont {get; set;}
    private static int puntajeActual {get; set;}
    private static int cantidadPreguntasCorrectas {get; set;}
    private static List<Preguntas> _preguntas {get; set;}
    private static List<Respuestas> _respuestas {get; set;}


    public static void InicializarJuego()
    {
        Username= "";
        puntajeActual= 0;
        cantidadPreguntasCorrectas= 0;
        cont = 0;
    }

    public static List<Categoria> ObtenerCategorias()
    {
        return BD.ObtenerCategorias();
    }

    public static List<Dificultades> ObtenerDificultades()
    {
        return BD.ObtenerDificultades();
    }

    public static void CargarPartida(string username, int dificultad, int categoria)
    {
        _preguntas = BD.ObtenerPreguntas();
        _respuestas = BD.ObtenerRespuestas();
    }

    public static List<Preguntas> ObtenerProximaPregunta()
    {
        return _preguntas[cont];
    }

    public static List<Respuestas> ObtenerProximasRespuestas(int idPregunta)
    {
        foreach (respuesta r in _respuestas)
        {
            
        }
        _respuestas
    }

    public static bool VerificarRespuesta(int idPregunta, int idRespuesta)
    {

        if ()
        {

        }
        
    }
}