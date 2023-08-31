namespace TP7_PreguntadORT.Models;
public static class Juego 
{
    private static string _username {get; set;}
    private static int _correct {get; set;}
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
        _correct= 0;
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

    public static bool VeriRespuesta(int idPregunta, int idRespuesta, ref int _correct) 
    {
        bool si= false;
        foreach (Respuestas c in BD.ObtenerRespuestas(idPregunta))
        {
            if(c.IdRespuesta == idRespuesta)
            {
                if(c.Correcta == true)
                {
                    _puntajeActual ++;
                    _cantidadPreguntasCorrectas ++;
                    _cont ++;
                    _correct= c.IdRespuesta;
                    si=true;
                }else{si=false;}
            }
        }
        return si;
    }
}