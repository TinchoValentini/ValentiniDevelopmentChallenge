namespace DevelopmentChallenge.Data.Classes
{
    public interface IFormaGeometrica
    {
        string ObtenerLinea(int cantidad, decimal area, decimal perimetro);
        string TraducirForma(int cantidad);
        decimal CalcularArea();
        decimal CalcularPerimetro();
    }
}
