namespace WheelOfFortune.Shared.Models
{
    public class ImageToRender
    {
        private ImageToRender() { }
        public static ImageToRender Create
        (
            string path,
            double dx,
            double dy,
            double dWidth,
            double dHeight
        ) => new()
        {
            Path = path,
            DX = dx,
            DY = dy,
            DWidth = dWidth,
            DHeight = dHeight
        };

        public static ImageToRender CreateWithSource
        (
            string path,
            double dx,
            double dy,
            double dWidth,
            double dHeight,
            double sx,
            double sy,
            double sWidth,
            double sHeight
        ) => new()
        {
            SourceMap = true,
            Path = path,
            DX = dx,
            DY = dy,
            DWidth = dWidth,
            DHeight = dHeight,
            SX = sx,
            SY = sy,
            SWidth = sWidth,
            SHeight = sHeight
        };

        public string Path { get; set; } = null!;
        public double DX { get; set; } 
        public double DY { get; set; }
        public bool SourceMap { get; set; } = false;
        public double DWidth { get; set; }
        public double DHeight { get; set; }
        public double SX { get; set; }
        public double SY { get; set; }
        public double SWidth { get; set; }
        public double SHeight { get; set; }
    }
}
