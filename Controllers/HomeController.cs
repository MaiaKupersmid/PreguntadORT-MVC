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
        ViewBag.Categorias= Jugar.ObtenerCategorias();
        ViewBag.dificultades= Jugar.ObtenerDificultades();
        return RedirectToAction("ConfigurarJuego", "Home");
    }

    public IActionResult Comenzar(string username, int dificultad, int categoria)
    {
        Juego.CargarPartida(username, dificultad, categoria);
        return RedirectToAction("Jugar");
    }

    public IActionResult Jugar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        return View();
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
