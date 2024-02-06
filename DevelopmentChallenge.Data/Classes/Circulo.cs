using DevelopmentChallenge.Data.MensajesIdiomas;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circulo : FormaGeometricaBase
    {
        private decimal _lado;
        public Circulo(decimal lado)
        {
            _lado = lado;
        }

        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _lado;
        }

        public override string TraducirForma(int cantidad)
        {
            return cantidad == 1 ? Mensajes.Circulo : Mensajes.Circulo + "s";
        }
    }
}
