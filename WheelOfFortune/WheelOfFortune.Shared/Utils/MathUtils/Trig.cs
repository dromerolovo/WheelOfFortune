

namespace WheelOfFortune.Shared.Utils.MathUtils
{
    public enum TrigOutput { Degrees, Radians }
    public static class Trig
    {
        public static double GetCircumsference(double radius) => 2 * radius * Math.PI;
        public static double DegreesToRadians(double degrees) => degrees * Math.PI / 180;
        public static double RadiansToDegrees(double radians) => radians * 180 / Math.PI;
        public static double GetAngleFromArcLength(double arcLength, double c, TrigOutput outputType = TrigOutput.Radians)
        {
            var degrees = arcLength * 360 / c;
            if (outputType == TrigOutput.Radians)
            {
                return DegreesToRadians((double)degrees);
            }
            else
            {
                return degrees;
            }

        }
    }
}
