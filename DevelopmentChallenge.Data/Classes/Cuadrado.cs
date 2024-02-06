using DevelopmentChallenge.Data.MensajesIdiomas;

namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : Rectangulo
    {
        public Cuadrado(decimal lado) : base(lado, lado)
        {
        }

        public override string TraducirForma(int cantidad)
        {
            return cantidad == 1 ? Mensajes.Cuadrado : Mensajes.Cuadrado + "s";
        }
    }
}
