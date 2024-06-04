using Clases;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
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
            string nombre = "Guidolautarojuanmartin";
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
            string nombre = "Martin!!#$%&";
            Assert.AreEqual(game.setName(nombre), "Nombre invalido");
        }

    }
}