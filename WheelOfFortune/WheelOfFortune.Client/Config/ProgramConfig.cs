using WheelOfFortune.Client.Services;

namespace WheelOfFortune.Client
{
    public static class ProgramConfig
    {
        public static void ConfigureCommonServices(IServiceCollection servicesContainer)
        {
            servicesContainer.AddSingleton<WheelService>();
        }
    }
}
