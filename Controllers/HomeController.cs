using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PreguntadORT.Models;
using TP7_PreguntadORT.Models;

namespace PreguntadORT.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ConfigurarJuego()
    {
        Juego.InicializarJuego();
        ViewBag.Categorias= Juego.ObtenerCategorias();
        ViewBag.dificultades= Juego.ObtenerDificultades();
        return  View();
    }

    public IActionResult Comenzar(string username, int dificultad, int categoria)
    {
        Juego.CargarPartida(username, dificultad, categoria);
        return RedirectToAction("ConfigurarJuego", "Home");
    }

    public IActionResult Jugar()
    {
        ViewBag.Pregunta= Juego.ObtenerProximaPregunta();
        if (ViewBag.Pregunta == "NULL"){
            return RedirectToAction("Fin", "Home");
        }
        else {
        ViewBag.Respuestas= Juego.ObtenerProximasRespuestas(ViewBag.Pregunta.IdPregunta);
        return RedirectToAction("Juego", "Home");
        }
    }

    [HttpPost]
    public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta, ref string _correct)
    {
        ViewBag.CorrectaNo = Juego.VerificarRespuesta();
        ViewBag.Correcta = _correct;
        return RedirectToAction("Respuesta", "Home");
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
