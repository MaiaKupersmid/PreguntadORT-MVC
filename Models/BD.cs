using System.Data.SqlClient;
using Dapper;
namespace TP7_PreguntadORT.Models;
public static class BD
{
    public static string _connectionString = @"Server=LOCALHOST;
    Database=Preguntados;Trusted_Connection=True;";

    public static List<Categoria> ObtenerCategorias()
    {
        List<Categoria> ListadoCategorias = new List<Categoria>();
        using (SqlConnection BD = new SqlConnection(_connectionString))
        {
            string sql = "exec sp_ObtenerCategorias;";
            ListadoCategorias = BD.Query<Categoria>(sql).ToList();
        }
        return ListadoCategorias;
    }

    public static List<Dificultades> ObtenerDificultades()
    {
        List<Dificultades> ListadoDificultades = new List<Dificultades>();
        using (SqlConnection BD = new SqlConnection(_connectionString))
        {
            string sql = "exec sp_ObtenerDificultades;";
            ListadoDificultades = BD.Query<Dificultades>(sql).ToList();
        }
        return ListadoDificultades;
    }
    
    public static List<Preguntas> ObtenerPreguntas(int IdDificultad, int IdCategoria)
    {
        List<Preguntas> ListadoPreguntas = new List<Preguntas>();
        using (SqlConnection BD = new SqlConnection(_connectionString))
        {
            string sql = "exec sp_ObtenerPreguntas @idDificultd, @idCategoria;";
            ListadoPreguntas = BD.Query<Preguntas>(sql, new { idDificultd = IdDificultad, idCategoria = IdCategoria }).ToList();
        }
        return ListadoPreguntas;
    }

    public static List<Respuestas> ObtenerRespuestas(Preguntas pregunta)
    {
        List<Respuestas> ListadoRespuestas = new List<Respuestas>();
        using (SqlConnection BD = new SqlConnection(_connectionString))
        {
            string sql = "exec sp_ObtenerRespuestas @IdPregunta;";
            ListadoRespuestas = BD.Query<Respuestas>(sql, new { IdPregunta = pregunta.IdPregunta }).ToList();
        }
        return ListadoRespuestas; 
        //no se si esta bine 
    }
}
