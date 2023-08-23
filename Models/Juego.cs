namespace TP7_PreguntadORT.Models;
public static class Juego 
{
    private static string _username {get; set;}
    private static string correct {get; set;}
    private static int _cont {get; set;}
    private static int _puntajeActual {get; set;}
    private static int _cantidadPreguntasCorrectas {get; set;}
    private static List<Preguntas> _preguntas {get; set;}
    private static List<Respuestas> _respuestas {get; set;}
    private static List<Respuestas> respuestasMatch = new List<Respuestas>();


    public static void InicializarJuego()
    {
        _username= "";
        _puntajeActual= 0;
        _cantidadPreguntasCorrectas= 0;
        _cont = 0;
        _correct= "";
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
        _preguntas = BD.ObtenerPreguntas(dificultad, categoria);
        _respuestas = BD.ObtenerRespuestas(_preguntas[_cont]);
    }

    public static Preguntas ObtenerProximaPregunta()
    {
        return _preguntas[_cont];
    }

    public static List<Respuestas> ObtenerProximasRespuestas(int idPregunta)
    {
        foreach (Respuestas r in _respuestas)
        {
            if(r.IdPregunta == idPregunta)
            {
                respuestasMatch.Add(r);
            }
        }
        return respuestasMatch;
    }

    public static int VerificarRespuesta(int idPregunta, int idRespuesta, ref string _correct) 
    {
        foreach (Respuestas r in respuestasMatch)
        {
            if(r.Correcta)
            {
                _puntajeActual ++;
                _cantidadPreguntasCorrectas ++;
                _cont ++;
                return true;
            }
        }
        _correct = r.Correcta;
        return false;
    }
}