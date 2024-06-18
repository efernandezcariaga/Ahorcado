using Clases;

namespace UnitTests
{
    [TestClass]
    public class UnitTest
    {
        //TEST DE INGRESAR NOMBRE
        [TestMethod]
        public void IngresarNombreVacio()
        {
            Juego game = new();
            string nombre = "";
            Assert.AreEqual(game.setName(nombre), "Nombre invalido");
        }

        [TestMethod]
        public void IngresarNombreLargo()
        {
            Juego game = new();
            string nombre = "GinoGallinaEzequielFernandezCariaga";
            Assert.AreEqual(game.setName(nombre), "Nombre invalido");
        }

        [TestMethod]
        public void IngresarNombreConEspacios()
        {
            Juego game = new();
            string nombre = "Tigre Bengala";
            Assert.AreEqual(game.setName(nombre), "Nombre invalido");
        }

        [TestMethod]
        public void IngresarNombreConCaracEspeciales()
        {
            Juego game = new();
            string nombre = "Gino!!#$%&";
            Assert.AreEqual(game.setName(nombre), "Nombre invalido");
        }

        //Test de validar palanbra elegida
        [TestMethod]
        public void ValidarPalabraElegidaIncorrecta()
        {
            Juego game = new Juego("Hola");
            game.setName("Gino");
            Assert.AreEqual(game.validarSecretWord(), "Valida");
        }

        [TestMethod]
        public void ValidarPalabraElegidaCorrecta()
        {
            Juego game = new Juego("Hola!!**");
            game.setName("Gino");
            Assert.AreEqual(game.validarSecretWord(), "Palabra secreta invalida");
        }

        // Test de Arriesgar palabra
        [TestMethod]
        public void ArriesgarPalabraIncorrecta()
        {
            Juego game = new Juego("Hola");
            Assert.AreEqual(game.arriesgarPalabra("derrota"), "Palabra incorrecta");
        }

        [TestMethod]
        public void ArriesgarPalabraVacia()
        {
            Juego game = new Juego("Hola");
            Assert.AreEqual(game.arriesgarPalabra(""), "Palabra invalida");
        }

        [TestMethod]
        public void ArriesgarPalabraCorrecta()
        {
            Juego game = new Juego("Hardcoded");
            Assert.AreEqual(game.arriesgarPalabra("Hardcoded"), "Palabra correcta");
        }

        // Test de Validar Letra (Que sea una letra válida)
        [TestMethod]
        public void ValidarEspacioBlanco()
        {
            Juego game = new Juego("Adios");
            Assert.AreEqual(game.validarLetra(' '), false);
        }

        [TestMethod]
        public void ValidarNumero()
        {
            Juego game = new Juego("Adios");
            Assert.AreEqual(game.validarLetra('3'), false);
        }

        [TestMethod]
        public void ValidarLetraValida()
        {
            Juego game = new Juego("Adios");
            Assert.AreEqual(game.validarLetra('d'), true);
        }

        // Test de Arriesgar Letra 
        [TestMethod]
        public void ArriesgarLetraIncorrecta()
        {
            Juego game = new Juego("Adios");
            Assert.AreEqual(game.arriesgarLetra('z'), "Letra incorrecta");
        }

        [TestMethod]
        public void ArriesgarLetraCorrecta()
        {
            Juego game = new Juego("Adios");
            Assert.AreEqual(game.arriesgarLetra('d'), "Acierto");
        }


        [TestMethod]
        public void ArriesgarLetraCorrectaNoCaseSensitive()
        {
            Juego game = new Juego("Adios");
            Assert.AreEqual(game.arriesgarLetra('D'), "Acierto");
        }


        //En vez de los de Validar letra podriamos poner
        [TestMethod]
        public void ArriesgarLetraEspacioBlanco()
        {
            Juego game = new Juego("Adios");
            Assert.AreEqual(game.arriesgarLetra(' '), "Letra invalida");
        }

        [TestMethod]
        public void ArriesgarLetraNumero()
        {
            Juego game = new Juego("Adios");
            Assert.AreEqual(game.arriesgarLetra('3'), "Letra invalida");
        }

        // Test de resta de intentos
        [TestMethod]
        public void UnIntentoMenos()
        {
            Juego game = new Juego("Adios");
            game.arriesgarLetra('e');
            Assert.AreEqual(game.intentosRestantes, 4);
        }

        [TestMethod]
        public void NoRestaIntento()
        {
            Juego game = new Juego("Adios");
            game.validarLetra('d');
            Assert.AreEqual(game.intentosRestantes, 5);
        }

        //Test de estados de letras
        [TestMethod]
        public void ValidarEstadoLetra()
        {
            Juego game = new Juego("Adios");
            game.arriesgarLetra('d');
            Assert.AreEqual(game.mostrarEstado(), "_d___");
        }

        [TestMethod]
        public void EstadoLetraDistintoLugar()
        {
            Juego game = new Juego("Adios");
            game.arriesgarLetra('l');
            Assert.AreNotEqual(game.mostrarEstado(), "_d___");
        }

        // Test verificar estado de juego
        [TestMethod]
        public void EstadoDeJuegoNoGanado()
        {
            Juego game = new Juego("Hola");
            Assert.AreEqual(game.checkearEstadoActual(), false);
        }

        [TestMethod]
        public void EstadoDeJuegoGanado()
        {
            Juego game = new Juego("Hola");
            game.arriesgarPalabra("Hola");
            Assert.AreEqual(game.checkearEstadoActual(), true);
        }

    }
}