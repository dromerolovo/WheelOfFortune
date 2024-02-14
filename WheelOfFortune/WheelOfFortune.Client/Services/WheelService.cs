using WheelOfFortune.Shared.Models;
using WheelOfFortune.Shared.Types;
using WheelOfFortune.Shared.Utils.WheelOperations;


namespace WheelOfFortune.Client.Services
{
    public class WheelService
    {
        private HttpClient _httpClient;
        public WheelService() 
        { 
            _httpClient = new();
        }
        private double _arcDegrees { get; set; }
        private int _segments {  get; set; }    
        public WheelSection[] WheelSections { get; set; }
        public Uri BaseAddressServer { get; set; }

        public void SetUp(double arcLength, int segments)
        {
            _arcDegrees = arcLength;
            _segments = segments;
        }

        public void SetUpHttpClientBaseAddress(Uri BaseAdress)
        {
            _httpClient.BaseAddress = BaseAdress;
        }

        public double GetArcdegrees() => _arcDegrees;
        public double GetSegments() => _segments;

        public EventHandler<WheelSelectionArgs>? WheelSelectionEvent;
        public async Task OnWheelSelection(double degrees)
        {

            var total = WheelOperations.AdjustWheelSelectedResult(degrees);
            var selected = CalculateSectionSelected(_segments, _arcDegrees, total);
            var wheelSelected = WheelSections![selected];
            var eventArgs = new WheelSelectionArgs
            {
                WheelSectionSelected = wheelSelected,
            };
            //Rotation time
            await Task.Delay(5000);
            WheelSelectionEvent?.Invoke(this, eventArgs);
        }

        public async Task<int> ComputeRotation()
        {
            var response = await _httpClient.GetAsync("/api/get-random");
            var rotation = int.Parse(await response.Content.ReadAsStringAsync());
            return rotation;
        }

        private int CalculateSectionSelected(int segments, double arcDegrees ,double degrees)
        {
            for(var i = 0; i < segments; i ++)
            {
                var start = i * arcDegrees;
                var end = (i + 1) * arcDegrees;
                var interval = new Interval
                {
                    Start = start,
                    End = end
                };
                var isInRange = interval.IsInRange(degrees);
                if(isInRange)
                {
                    return i;
                }
            }
            throw new Exception("Degree is not in range");
        }
    }

    public class WheelSelectionArgs : EventArgs
    {
        public WheelSection WheelSectionSelected { get; set; } = null!;
    }


}
