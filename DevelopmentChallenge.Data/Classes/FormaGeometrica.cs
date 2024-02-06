/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using DevelopmentChallenge.Data.MensajesIdiomas;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace DevelopmentChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        public static string Imprimir(List<IFormaGeometrica> formas, Idiomas idioma)
        {
            switch (idioma)
            {
                case Idiomas.Castellano:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
                    break;
                case Idiomas.Ingles:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    break;
                case Idiomas.Italiano:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("it-IT");
                    break;
                default:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
                    break;
            }

            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append("<h1>" + Mensajes.ListaVacia + "</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                sb.Append("<h1>" + Mensajes.ReporteFormas + "</h1>");

                var agrupadasLasFormas = formas.GroupBy(f => f.GetType().Name);

                foreach (var item in agrupadasLasFormas)
                {
                    var count = item.Count();
                    var sumaAreas = item.Sum(x => x.CalcularArea());
                    var sumaPerimetros = item.Sum(x => x.CalcularPerimetro());
                    sb.Append(item.First().ObtenerLinea(count, sumaAreas, sumaPerimetros));
                }

                // FOOTER
                sb.Append(Mensajes.Total.ToUpper() + ":<br/>");
                sb.Append(formas.Count() + " " + Mensajes.Formas + " ");
                sb.Append(Mensajes.Perimetro + " " + formas.Sum(x => x.CalcularPerimetro()).ToString("#.##") + " ");
                sb.Append(Mensajes.Area + " " + formas.Sum(x => x.CalcularArea()).ToString("#.##"));
            }

            return sb.ToString();
        }
    }
}
