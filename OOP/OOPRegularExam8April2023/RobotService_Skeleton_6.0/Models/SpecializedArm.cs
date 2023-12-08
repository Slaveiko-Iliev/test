namespace RobotService.Models
{
    public class SpecializedArm : Supplement
    {
        private const int _InterfaceStandard = 10045;
        private const int _BatteryUsage = 10000;


        public SpecializedArm() : base(_InterfaceStandard, _BatteryUsage)
        {
        }
    }
}
