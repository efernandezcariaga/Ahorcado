using System.ComponentModel;

namespace AhorcadoMVC.Models
{
    public class Ahorcado
    {
        [DisplayName("Letra")]
        public String LetterTyped { get; set; } = null!;

        [DisplayName("Palabra")]
        public String WordToGuess { get; set; } = null!;
        
        [DisplayName("Letras acertadas")]
        public String GuessingWord { get; set; } = null!;
        
        [DisplayName("Chances Restantes")]
        public Int32? ChancesLeft { get; set; } = null!;
        
        [DisplayName("Letras Erradas")]
        public String WrongLetters { get; set; } = null!;
        
        [DisplayName("Mensaje")]
        public String Message { get; set; } = null!;

        public Boolean Win { get; set; }

    }
}
