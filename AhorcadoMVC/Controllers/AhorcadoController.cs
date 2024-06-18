using AhorcadoMVC.Models;
using Clases;
using Microsoft.AspNetCore.Mvc;

namespace AhorcadoMVC.Controllers
{
    public class AhorcadoController : Controller
    {
        public static Juego Juego { get; set; } = null!;

        // GET: Ahorcado
        public ActionResult Index()
        {
            return View(new Ahorcado());
        }

        [HttpPost]
        public JsonResult InsertWordToGuess(Ahorcado model)
        {
            Juego = new Juego(model.WordToGuess);
            model.Message = Juego.validarSecretWord();
            if (model.Message == "Palabra secreta invalida")
            {
                Juego = null;
            }
            else
            {
                model.ChancesLeft = Juego.intentosRestantes;
                foreach (var rLetter in Juego.estadoPalabraArray)
                {
                    model.GuessingWord += rLetter + " ";
                }
                model.Message = null;
            }
            return Json(model);
        }

        [HttpPost]
        public JsonResult TryLetter(Ahorcado model)
        {
            char letra;
            try
            {
                letra = Convert.ToChar(model.LetterTyped);
                model.Message = Juego.arriesgarLetra(letra);
                model.Win = Juego.checkearEstadoActual();
                model.ChancesLeft = Juego.intentosRestantes;
                model.WrongLetters = string.Empty;
                foreach (var wLetter in Juego.letrasErradas)
                {
                    model.WrongLetters += wLetter + ",";
                }
                model.GuessingWord = string.Empty;
                foreach (var rLetter in Juego.estadoPalabraArray)
                {
                    model.GuessingWord += rLetter + " ";
                }
                model.LetterTyped = string.Empty;
            }
            catch (FormatException e)
            {
                model.Message = "Ingrese un caracter válido";
            }
            catch (ArgumentNullException e)
            {
                model.Message = "Ingrese una letra o palabra";
            }
            return Json(model);
        }

        [HttpPost]
        public JsonResult TryWord(Ahorcado model)
        {
            model.Message = Juego.arriesgarPalabra(model.LetterTyped);
            model.Win = Juego.checkearEstadoActual();
            model.ChancesLeft = Juego.intentosRestantes;
            model.WrongLetters = string.Empty;
            foreach (var wLetter in Juego.letrasErradas)
            {
                model.WrongLetters += wLetter + ",";
            }
            model.GuessingWord = string.Empty;
            foreach (var rLetter in Juego.estadoPalabraArray)
            {
                model.GuessingWord += rLetter + " ";
            }
            model.LetterTyped = string.Empty;
            return Json(model);
        }
    }
}

