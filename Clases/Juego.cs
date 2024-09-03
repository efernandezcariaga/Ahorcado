namespace Clases
{
    public class Juego
    {
        public string? nombreJugador;
        private string palabraSecreta;
        private string estadoPalabra;
        public char[] estadoPalabraArray;
        public int intentosRestantes;
        public List<char> letrasErradas = [];

        // Construtor con Palabra y Nombre Hardcodeados
        public Juego()
        {
            this.nombreJugador = "Gino";
            this.palabraSecreta = "Hardcoded";
            this.estadoPalabra = "_________";
            this.estadoPalabraArray = estadoPalabra.ToCharArray();
            this.intentosRestantes = 5;
        }

        // Construtor con Palabra elegida
        public Juego(string palabraAsignada)
        {
            this.palabraSecreta = palabraAsignada.ToLower();
            this.estadoPalabra = "";
            for (int j = 0; j < palabraAsignada.Length; j++)
            {
                this.estadoPalabra += "_";
            }
            this.estadoPalabraArray = estadoPalabra.ToCharArray();
            this.intentosRestantes = 5;
        }

        public string validarSecretWord()
        {
            if (string.IsNullOrWhiteSpace(palabraSecreta) || !palabraSecreta.All(char.IsLetter))
            {
                return "Palabra secreta invalida";
            }
            else
            {
                return "Valida";
            }
        }

        public string setName(string nombre)
        {
            if (nombre == ""   || nombre.Length > 20 || !nombre.All(char.IsLetterOrDigit))
            {
                return "Nombre invalido";
            }
            else
            {
                this.nombreJugador = nombre;
                return "Nombre valido";
            }
        }

        public string arriesgarPalabra(string palabra)
        {
            if (string.IsNullOrWhiteSpace(palabra) || !palabra.All(char.IsLetterOrDigit))
            {
                return "Palabra invalida";
            }
            else if (palabra.Equals(this.palabraSecreta, StringComparison.CurrentCultureIgnoreCase))
            {
                estadoPalabra = palabraSecreta;
                estadoPalabraArray = palabraSecreta.ToCharArray();
                return "Palabra correcta";
            }
            else
            {
                // Está pensado para que pierda un intento, pero podria perder todos.
                //intentosRestantes = 0;
                intentosRestantes--;
                return "Palabra incorrecta";
            }
        }

        public bool validarLetra(char letra)
        {
            if (char.IsLetter(letra))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string arriesgarLetra(char letra)
        {
            if (validarLetra(letra))
            {
                if (palabraSecreta.Contains(char.ToLower(letra)))
                {
                    int cont = 0;
                    foreach (char c in palabraSecreta)
                    {
                        if (c == char.ToLower(letra))
                        {
                            estadoPalabraArray[cont] = char.ToLower(letra);
                        }
                        cont++;
                    }
                    return "Acierto";
                }
                else if (letrasErradas.Contains(char.ToLower(letra)))
                {
                    return "Letra ya ingresada";
                }
                else
                {
                    intentosRestantes--;
                    letrasErradas.Add(letra);
                    return "Letra incorrecta";
                }
            }
            else
            {
                return "Letra invalida";
            }
        }

        public bool checkearEstadoActual()
        {
            if (estadoPalabraArray.Contains('_')) return false;
            else return true;
        }

        public string mostrarEstado()
        {
            string estadoreturn = new(estadoPalabraArray);
            return estadoreturn;
        }

    }
}
