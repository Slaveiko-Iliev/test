namespace RobotService.Models
{
    public class IndustrialAssistant : Robot
    {
        private const int _BatteryCapacity = 40000;
        private const int _ConvertionCapacityIndex = 5000;

        public IndustrialAssistant(string model) : base(model, _BatteryCapacity, _ConvertionCapacityIndex)
        {
        }
    }
}
