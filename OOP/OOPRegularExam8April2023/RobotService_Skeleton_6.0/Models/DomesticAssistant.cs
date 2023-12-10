namespace RobotService.Models
{
    public class DomesticAssistant : Robot
    {
        private const int _BatteryCapacity = 20000;
        private const int _ConvertionCapacityIndex = 2000;
        public DomesticAssistant(string model) : base(model, _BatteryCapacity, _ConvertionCapacityIndex)
        {
        }
    }
}
