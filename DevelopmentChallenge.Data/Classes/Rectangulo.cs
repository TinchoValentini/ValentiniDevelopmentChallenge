using DevelopmentChallenge.Data.MensajesIdiomas;

namespace DevelopmentChallenge.Data.Classes
{
    public class Rectangulo : FormaGeometricaBase
    {
        private decimal _base;
        private decimal _altura;
        public Rectangulo(decimal baseRectagulo, decimal altura)
        {
            _base = baseRectagulo;
            _altura = altura;
        }

        public override decimal CalcularArea()
        {
            return _base * _altura;
        }

        public override decimal CalcularPerimetro()
        {
            return 2 * (_base + _altura);
        }

        public override string TraducirForma(int cantidad)
        {
            return cantidad == 1 ? Mensajes.Rectangulo : Mensajes.Rectangulo + "s";
        }
    }
}
