namespace WheelOfFortune
{
    public static class GetRandomService
    {
        public static int ComputeRotation()
        {
            var random = new Random();
            var number = (int)Math.Ceiling(random.NextDouble() * 3500);
            var numberClamp = Math.Clamp(number, 1500, int.MaxValue);
            return numberClamp;
        }
    }
}
