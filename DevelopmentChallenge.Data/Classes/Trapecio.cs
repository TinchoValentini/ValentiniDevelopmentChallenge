using DevelopmentChallenge.Data.MensajesIdiomas;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class Trapecio : FormaGeometricaBase
    {
        private decimal _baseMayor;
        private decimal _baseMenor;
        private decimal _ladoA;
        private decimal _ladoB;
        private decimal _altura;
        public Trapecio(decimal baseMayor, decimal baseMenor, decimal ladoA, decimal ladoB, decimal altura)
        {
            _baseMayor = baseMayor;
            _ladoA = ladoA;
            _ladoB = ladoB;
            _altura = altura;
            _baseMenor = baseMenor;
        }

        public override decimal CalcularArea()
        {
            return ((_baseMayor + _baseMenor) / 2) * _altura;
        }

        public override decimal CalcularPerimetro()
        {
            return _baseMayor + _baseMenor + _ladoA + _ladoB;
        }

        public override string TraducirForma(int cantidad)
        {
            return cantidad == 1 ? Mensajes.Trapecio : Mensajes.Trapecio + "s";
        }
    }
}
