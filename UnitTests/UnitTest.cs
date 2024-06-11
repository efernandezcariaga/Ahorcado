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


        // TEST DE ARRIESGAR PALABRA
        [TestMethod]
        public void ArriesgarPalabraIncorrecta()
        {
            Juego game = new Juego();
            game.setName("Gino");
            Assert.AreEqual(game.arriesgarPalabra("derrota"), "Palabra incorrecta");
        }

        [TestMethod]
        public void ArriesgarPalabraVacia()
        {
            Juego game = new Juego();
            game.setName("Gino");
            Assert.AreEqual(game.arriesgarPalabra(""), "Palabra invalida");
        }
        public void ArriesgarPalabraCorrecta()
        {
            Juego game = new Juego("Adios");
            game.setName("Gino");
            Assert.AreEqual(game.arriesgarPalabra("Adios"), "Palabra correcta");
        }

        // Test de Validar Letra (Que sea una letra válida)

        [TestMethod]
        public void ValidarEspacioBlanco()
        {
            Juego game = new Juego("Adios");
            game.setName("Gino");
            Assert.AreEqual(game.validarLetra(' '), false);
        }

        [TestMethod]
        public void ValidarNumero()
        {
            Juego game = new Juego("Adios");
            game.setName("Gino");
            Assert.AreEqual(game.validarLetra('3'), false);
        }

        [TestMethod]
        public void ValidarLetraValida()
        {
            Juego game = new Juego("Adios");
            game.setName("Gino");
            Assert.AreEqual(game.validarLetra('d'), true);
        }

        // Test de Arriesgar Letra 
        [TestMethod]
        public void ArriesgarLetraIncorrecta()
        {
            Juego game = new Juego("Adios");
            game.setName("Gino");
            Assert.AreEqual(game.arriesgarLetra('z'), "Letra incorrecta");
        }

        [TestMethod]
        public void ArriesgarLetraCorrecta()
        {
            Juego game = new Juego("Adios");
            game.setName("Gino");
            Assert.AreEqual(game.arriesgarLetra('d'), "Acierto");
        }


        [TestMethod]
        public void ArriesgarLetraCorrectaNoCaseSensitive()
        {
            Juego game = new Juego("Adios");
            game.setName("Gino");
            Assert.AreEqual(game.arriesgarLetra('D'), "Acierto");
        }


        //En vez de los de Validar letra podriamos poner
        [TestMethod]
        public void ArriesgarLetraEspacioBlanco()
        {
            Juego game = new Juego("Adios");
            game.setName("Gino");
            Assert.AreEqual(game.arriesgarLetra(' '), "Letra invalida");
        }

        [TestMethod]
        public void ArriesgarLetraNumero()
        {
            Juego game = new Juego("Adios");
            game.setName("Gino");
            Assert.AreEqual(game.arriesgarLetra('3'), "Letra invalida");
        }

    }
}