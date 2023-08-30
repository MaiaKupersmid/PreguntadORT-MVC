namespace TP7_PreguntadORT.Models;
public static class Juego 
{
    private static string _username {get; set;}
    private static string _correct {get; set;}
    private static int _cont {get; set;}
    private static int _puntajeActual {get; set;}
    private static int _cantidadPreguntasCorrectas {get; set;}
    private static List<Preguntas> _preguntas {get; set;}
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
        
    }

    public static Preguntas ObtenerProximaPregunta()
    {
        return _preguntas[_cont];
    }

    public static List<Respuestas> ObtenerRespuestas(int idPregunta)
    {
        return BD.ObtenerRespuestas(idPregunta);
    }

    public static bool VeriRespuesta(int idPregunta, int idRespuesta, string _correct) 
    {
       /// respuestasMatch = BD.ObtenerPreguntas(dificultad, categoria);

        foreach (Respuestas r in respuestasMatch)
        {
            if(r.Correcta)
            {
                _puntajeActual ++;
                _cantidadPreguntasCorrectas ++;
                _cont ++;
                return true;
            }
            else
            {
                foreach (Respuestas c in respuestasMatch)
                {
                    if(c.Correcta)
                    {
                        _correct = c.Contenido;
                    }
                }
                return false;
            }
        }
        return false;
    }

    /// TIENE QUE IR A LA BASE DE DATOS A CHEQUEAR LAS RESP Y VOLVER CON LA CORRECTA 
}