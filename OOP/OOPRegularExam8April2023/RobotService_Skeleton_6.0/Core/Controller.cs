using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private SupplementRepository _supplements;
        private RobotRepository _robots;

        public Controller()
        {
            _supplements = new SupplementRepository();
            _robots = new RobotRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            var subclassTypes = Assembly
                .GetAssembly(typeof(Robot))
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Robot)));

            bool isValidType = false;

            foreach (var type in subclassTypes)
            {
                if (type.Name == typeName)
                {
                    isValidType = true;
                }
            }
            if (!isValidType)
            {
                return $"Robot type {typeName} cannot be created.";
            }

            IRobot robot = null;
            if (typeName == "DomesticAssistant")
            {
                robot = new DomesticAssistant(model);
            }
            else if (typeName == "IndustrialAssistant")
            {
                robot = new IndustrialAssistant(model);
            }

            _robots.AddNew(robot);

            return $"{typeName} {model} is created and added to the RobotRepository.";
        }

        public string CreateSupplement(string typeName)
        {
            var subclassTypes = Assembly
                .GetAssembly(typeof(Supplement))
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Supplement)));

            bool isValidType = false;

            foreach (var type in subclassTypes)
            {
                if (type.Name == typeName)
                {
                    isValidType = true;
                }
            }
            if (!isValidType)
            {
                return $"{typeName} is not compatible with our robots.";
            }

            ISupplement supplement = null;

            if (typeName == "LaserRadar")
            {
                supplement = new LaserRadar();
            }
            else if (typeName == "SpecializedArm")
            {
                supplement = new SpecializedArm();
            }

            _supplements.AddNew(supplement);

            return $"{typeName} is created and added to the SupplementRepository.";
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            List<IRobot> robotsToService = _robots.Models().Where(r => r.InterfaceStandards.Contains(intefaceStandard)).ToList();

            if (robotsToService.Count == 0)
            {
                return $"Unable to perform service, {intefaceStandard} not supported!";
            }

            robotsToService = robotsToService.OrderByDescending(r => r.BatteryLevel).ToList();

            int sumOfBatteryLevel = robotsToService.Sum(r => r.BatteryLevel);

            if (sumOfBatteryLevel < totalPowerNeeded)
            {
                return $"{serviceName} cannot be executed! {totalPowerNeeded - sumOfBatteryLevel} more power needed.";
            }

            int countofWorkedRobots = 0;

            foreach (IRobot robot in robotsToService)
            {
                if (robot.BatteryLevel >= totalPowerNeeded)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    countofWorkedRobots++;
                    break;
                }
                else
                {
                    totalPowerNeeded -= robot.BatteryLevel;
                    robot.ExecuteService(robot.BatteryLevel);
                    countofWorkedRobots++;
                }
                if (totalPowerNeeded == 0)
                {
                    break;
                }
            }

            return $"{serviceName} is performed successfully with {countofWorkedRobots} robots.";
        }

        public string Report()
        {
            StringBuilder sb = new();

            foreach (IRobot robot in _robots.Models().OrderByDescending(r => r.BatteryLevel).ThenBy(r => r.BatteryCapacity))
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RobotRecovery(string model, int minutes)
        {
            List<IRobot> feedingRobot = _robots.Models().Where(r => r.Model == model && r.BatteryLevel < r.BatteryCapacity).ToList();

            feedingRobot.ForEach(r => r.Eating(minutes));

            return $"Robots fed: {feedingRobot.Count}";
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = _supplements.Models()
                .First(s => s.GetType().Name == supplementTypeName);


            int supplementInterface = supplement.InterfaceStandard;

            List<IRobot> robotsToUpgrade = new List<IRobot>();

            foreach (var robot in _robots.Models())
            {
                if (!robot.InterfaceStandards.Contains(supplementInterface))
                {
                    robotsToUpgrade.Add(robot);
                }
            }

            robotsToUpgrade = robotsToUpgrade
                .Where(r => r.Model == model).ToList();

            if (robotsToUpgrade.Count == 0)
            {
                return $"All {model} are already upgraded!";
            }

            robotsToUpgrade.First().InstallSupplement(supplement);
            _supplements.RemoveByName(supplement.GetType().Name);

            return $"{model} is upgraded with {supplementTypeName}.";
        }
    }
}
