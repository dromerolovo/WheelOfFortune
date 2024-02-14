namespace WheelOfFortune.Shared.Utils.Colors
{
    public static class Colors
    {
        public static byte ColorClamp(byte color, int number)
        {
            if (number > 0)
            {
                if ((int)color + number > 255)
                {
                    return (byte)255;
                }
                else
                {
                    return (byte)(color + number);
                }
            }

            else
            {
                if ((int)color + number < 0)
                {
                    return (byte)0;
                }
                else
                {
                    return (byte)(color + number);
                }
            }
        }
    }
}
