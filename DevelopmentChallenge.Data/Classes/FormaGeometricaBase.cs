using DevelopmentChallenge.Data.MensajesIdiomas;

namespace DevelopmentChallenge.Data.Classes
{
    public abstract class FormaGeometricaBase : IFormaGeometrica
    {
        public abstract decimal CalcularArea();

        public abstract decimal CalcularPerimetro();

        public abstract string TraducirForma(int cantidad);

        public string ObtenerLinea(int cantidad, decimal area, decimal perimetro)
        {
            if (cantidad > 0)
            {
                return $"{cantidad} {this.TraducirForma(cantidad)} | {Mensajes.Area} {area:#.##} | {Mensajes.Perimetro} {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }
    }
}
