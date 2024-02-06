using DevelopmentChallenge.Data.MensajesIdiomas;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrianguloEquilatero : FormaGeometricaBase
    {
        private decimal _lado;
        public TrianguloEquilatero(decimal lado)
        {
            _lado = lado;
        }

        public override decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 3;
        }

        public override string TraducirForma(int cantidad)
        {
            return cantidad == 1 ? Mensajes.Triangulo : Mensajes.Triangulo + "s";
        }
    }
}
