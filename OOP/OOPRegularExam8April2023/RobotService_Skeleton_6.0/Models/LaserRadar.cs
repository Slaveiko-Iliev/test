namespace RobotService.Models
{
    public class LaserRadar : Supplement
    {
        private const int _InterfaceStandard = 20082;
        private const int _BatteryUsage = 5000;


        public LaserRadar() : base(_InterfaceStandard, _BatteryUsage)
        {
        }
    }
}
