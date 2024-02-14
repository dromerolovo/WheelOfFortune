namespace WheelOfFortune.Shared.Models
{
    public class WheelSection
    {
        public string Name { get; set; } = null!;
        public ImageToRender ImageToRender { get; set; }
        public int Weight { get; set; } = 1;
    }
}
