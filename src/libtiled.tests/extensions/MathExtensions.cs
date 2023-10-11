namespace Org.Mapeditor.Extensions
{
    public static class MathExtensions
    {
        public static double ToRadians(this double angleIn10thofaDegree)
        {
            // Angle in 10th of a degree
            return (angleIn10thofaDegree * System.Math.PI) / 1800;
        }
    }
}
