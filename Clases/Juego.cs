namespace Clases
{
    public class Juego
    {
     
        public string nombreJugador;
        private string palabraSecreta;
        private string estadoPalabra;
        public int intentosRestantes;

        public Juego()
        {
            this.nombreJugador = "";
            this.palabraSecreta = "";
            this.estadoPalabra = "";
            this.intentosRestantes = 5;
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

    }
}
