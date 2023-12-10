using RobotService.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private string _model;
        private int _batteryCapacity;
        private List<int> _interfaceStandards;

        protected Robot(string model, int batteryCapacity, int convertionCapacityIndex)
        {
            Model = model;
            BatteryCapacity = batteryCapacity;
            BatteryLevel = batteryCapacity;
            ConvertionCapacityIndex = convertionCapacityIndex;
            _interfaceStandards = new List<int>();
        }

        public string Model
        {
            get => _model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model cannot be null or empty.");
                }
                _model = value;
            }
        }

        public int BatteryCapacity
        {
            get => _batteryCapacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Battery capacity cannot drop below zero.");
                }
                _batteryCapacity = value;
            }
        }

        public int BatteryLevel { get; private set; }

        public int ConvertionCapacityIndex { get; private set; }

        public IReadOnlyCollection<int> InterfaceStandards => _interfaceStandards.AsReadOnly();

        public void Eating(int minutes)
        {
            BatteryLevel += minutes * ConvertionCapacityIndex;

            if (BatteryLevel > BatteryCapacity)
            {
                BatteryLevel = BatteryCapacity;
            }
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (this.BatteryLevel >= consumedEnergy)
            {
                this.BatteryLevel -= consumedEnergy;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void InstallSupplement(ISupplement supplement)
        {
            _interfaceStandards.Add(supplement.InterfaceStandard);
            this.BatteryLevel -= supplement.BatteryUsage;
            this.BatteryCapacity -= supplement.BatteryUsage;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name} {Model}:");
            sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {BatteryLevel}");
            sb.Append("--Supplements installed: ");

            if (_interfaceStandards.Count == 0)
            {
                sb.Append("none");
            }
            else
            {
                sb.Append($"{string.Join(" ", _interfaceStandards)}");
            }

            return sb.ToString();
        }
    }
}
