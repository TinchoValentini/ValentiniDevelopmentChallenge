using DevelopmentChallenge.Data.Classes;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<IFormaGeometrica>(), Idiomas.Castellano));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<IFormaGeometrica>(), Idiomas.Ingles));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<IFormaGeometrica> { new Cuadrado(5) };

            var resumen = FormaGeometrica.Imprimir(cuadrados, Idiomas.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, Idiomas.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, Idiomas.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13.01 | Perimeter 18.06 <br/>3 Triangles | Area 49.64 | Perimeter 51.6 <br/>TOTAL:<br/>7 shapes Perimeter 97.66 Area 91.65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado( 2),
                new TrianguloEquilatero(9),
                new Circulo( 2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, Idiomas.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13.01 | Perimetro 18.06 <br/>3 Triángulos | Area 49.64 | Perimetro 51.6 <br/>TOTAL:<br/>7 formas Perimetro 97.66 Area 91.65",
                resumen);
        }

        [TestCase(Formas.Cuadrado, 5, 0, 0, 0, 0, "<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25")]
        [TestCase(Formas.TrianguloEquilatero, 5, 0, 0, 0, 0, "<h1>Reporte de Formas</h1>1 Triángulo | Area 10.83 | Perimetro 15 <br/>TOTAL:<br/>1 formas Perimetro 15 Area 10.83")]
        [TestCase(Formas.Circulo, 5, 0, 0, 0, 0, "<h1>Reporte de Formas</h1>1 Círculo | Area 19.63 | Perimetro 15.71 <br/>TOTAL:<br/>1 formas Perimetro 15.71 Area 19.63")]
        [TestCase(Formas.Rectangulo, 5, 4, 0, 0, 0, "<h1>Reporte de Formas</h1>1 Rectángulo | Area 20 | Perimetro 18 <br/>TOTAL:<br/>1 formas Perimetro 18 Area 20")]
        [TestCase(Formas.Trapecio, 10, 7, 4, 4, 5, "<h1>Reporte de Formas</h1>1 Trapecio | Area 42.5 | Perimetro 25 <br/>TOTAL:<br/>1 formas Perimetro 25 Area 42.5")]
        public void TestResumenListaConUnaFormaEnCastellano(Formas forma, decimal a, decimal b, decimal c, decimal d, decimal e, string resultadoEsperado)
        {
            var formas = new List<IFormaGeometrica> { CrearFormaSimplificado(forma, a, b, c, d, e) };
            var resumen = FormaGeometrica.Imprimir(formas, Idiomas.Castellano);
            Assert.AreEqual(resultadoEsperado, resumen);
        }

        [TestCase(Formas.Cuadrado, 5, 0, 0, 0, 0, "<h1>Shapes report</h1>1 Square | Area 25 | Perimeter 20 <br/>TOTAL:<br/>1 shapes Perimeter 20 Area 25")]
        [TestCase(Formas.TrianguloEquilatero, 5, 0, 0, 0, 0, "<h1>Shapes report</h1>1 Triangle | Area 10.83 | Perimeter 15 <br/>TOTAL:<br/>1 shapes Perimeter 15 Area 10.83")]
        [TestCase(Formas.Circulo, 5, 0, 0, 0, 0, "<h1>Shapes report</h1>1 Circle | Area 19.63 | Perimeter 15.71 <br/>TOTAL:<br/>1 shapes Perimeter 15.71 Area 19.63")]
        [TestCase(Formas.Rectangulo, 5, 4, 0, 0, 0, "<h1>Shapes report</h1>1 Rectangle | Area 20 | Perimeter 18 <br/>TOTAL:<br/>1 shapes Perimeter 18 Area 20")]
        [TestCase(Formas.Trapecio, 10, 7, 4, 4, 5, "<h1>Shapes report</h1>1 Trapeze | Area 42.5 | Perimeter 25 <br/>TOTAL:<br/>1 shapes Perimeter 25 Area 42.5")]
        public void TestResumenListaConUnaFormaEnIngles(Formas forma, decimal a, decimal b, decimal c, decimal d, decimal e, string resultadoEsperado)
        {
            var formas = new List<IFormaGeometrica> { CrearFormaSimplificado(forma, a, b, c, d, e) };
            var resumen = FormaGeometrica.Imprimir(formas, Idiomas.Ingles);
            Assert.AreEqual(resultadoEsperado, resumen);
        }

        [TestCase(Formas.Cuadrado, 5, 0, 0, 0, 0, "<h1>Rapporto sulle forme</h1>1 Quadrato | Area 25 | Perimetro 20 <br/>TOTALE:<br/>1 forme Perimetro 20 Area 25")]
        [TestCase(Formas.TrianguloEquilatero, 5, 0, 0, 0, 0, "<h1>Rapporto sulle forme</h1>1 Triangolo | Area 10.83 | Perimetro 15 <br/>TOTALE:<br/>1 forme Perimetro 15 Area 10.83")]
        [TestCase(Formas.Circulo, 5, 0, 0, 0, 0, "<h1>Rapporto sulle forme</h1>1 Cerchio | Area 19.63 | Perimetro 15.71 <br/>TOTALE:<br/>1 forme Perimetro 15.71 Area 19.63")]
        [TestCase(Formas.Rectangulo, 5, 4, 0, 0, 0, "<h1>Rapporto sulle forme</h1>1 Rettangolo | Area 20 | Perimetro 18 <br/>TOTALE:<br/>1 forme Perimetro 18 Area 20")]
        [TestCase(Formas.Trapecio, 10, 7, 4, 4, 5, "<h1>Rapporto sulle forme</h1>1 Trapezio | Area 42.5 | Perimetro 25 <br/>TOTALE:<br/>1 forme Perimetro 25 Area 42.5")]
        public void TestResumenListaConUnaFormaEnItaliano(Formas forma, decimal a, decimal b, decimal c, decimal d, decimal e, string resultadoEsperado)
        {
            var formas = new List<IFormaGeometrica> { CrearFormaSimplificado(forma, a, b, c, d, e) };
            var resumen = FormaGeometrica.Imprimir(formas, Idiomas.Italiano);
            Assert.AreEqual(resultadoEsperado, resumen);
        }

        [TestCase(Idiomas.Ingles, "<h1>Empty list of shapes!</h1>")]
        [TestCase(Idiomas.Castellano, "<h1>Lista vacía de formas!</h1>")]
        [TestCase(Idiomas.Italiano, "<h1>Elenco vuoto di forme!</h1>")]
        public void TestResumenListaVaciaPorIdioma(Idiomas idioma, string resultadoEsperado)
        {
            Assert.AreEqual(resultadoEsperado,
                FormaGeometrica.Imprimir(new List<IFormaGeometrica>(), idioma));
        }

        //TODO: refactorizar
        private IFormaGeometrica CrearFormaSimplificado(Formas forma, decimal a, decimal b, decimal c, decimal d, decimal e)
        {
            switch (forma)
            {
                case Formas.Cuadrado:
                    return new Cuadrado(a);
                case Formas.TrianguloEquilatero:
                    return new TrianguloEquilatero(a);
                case Formas.Circulo:
                    return new Circulo(a);
                case Formas.Trapecio:
                    return new Trapecio(a, b, c, d, e);
                case Formas.Rectangulo:
                    return new Rectangulo(a, b);
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }
    }
}
