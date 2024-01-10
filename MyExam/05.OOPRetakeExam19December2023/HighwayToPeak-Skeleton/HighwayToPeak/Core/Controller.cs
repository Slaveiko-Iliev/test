using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Core
{
    public class Controller : IController
    {
        private PeakRepository peaks;
        private ClimberRepository climbers;
        private IBaseCamp baseCamp;

        public Controller()
        {
            peaks = new PeakRepository();
            climbers = new ClimberRepository();
            baseCamp = new BaseCamp();
        }

        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            if (peaks.All.Any(p => p.Name == name))
            {
                return $"{name} is already added as a valid mountain destination.";
            }

            if (difficultyLevel != "Extreme" && difficultyLevel != "Hard" && difficultyLevel != "Moderate")
            {
                return $"{difficultyLevel} peaks are not allowed for international climbers.";
            }

            IPeak currentPeak = new Peak(name, elevation, difficultyLevel);
            peaks.Add(currentPeak);

            return $"{name} is allowed for international climbing. See details in {peaks.GetType().Name}.";
        }

        public string AttackPeak(string climberName, string peakName)
        {
            if (!climbers.All.Any(c => c.Name == climberName))
            {
                return $"Climber - {climberName}, has not arrived at the BaseCamp yet.";
            }
            
            if (!peaks.All.Any(c => c.Name == peakName))
            {
                return $"{ peakName} is not allowed for international climbing.";
            }

            if (!baseCamp.Residents.Contains(climberName))
            {
                return $"{climberName} not found for gearing and instructions. The attack of {peakName} will be postponed.";
            }

            IClimber currentClimber = climbers.All.First(c => c.Name == climberName);
            IPeak currentPeak = peaks.All.First(p => p.Name == peakName);

            if (currentPeak.DifficultyLevel == "Extreme" &&
                currentClimber.GetType().Name == "NaturalClimber")
            {
                return $"{climberName} does not cover the requirements for climbing {peakName}.";
            }

            baseCamp.LeaveCamp(climberName);

            currentClimber.Climb(currentPeak);

            if (currentClimber.Stamina <= 0)
            {
                return $"{climberName} did not return to BaseCamp.";
            }
            else
            {
                baseCamp.ArriveAtCamp(currentClimber.Name);

                return $"{climberName} successfully conquered {peakName} and returned to BaseCamp.";
            }

        }

        public string BaseCampReport()
        {
            StringBuilder sb = new();

            sb.AppendLine("BaseCamp residents:");

            if (baseCamp.Residents.Count == 0)
            {
                sb.AppendLine("BaseCamp is currently empty.");
            }
            else
            {
                foreach (var resident in baseCamp.Residents)
                {
                    
                    
                    IClimber curremtClimber = climbers.All.First(c => c.Name == resident);

                    sb.AppendLine($"Name: {curremtClimber.Name}, Stamina: {curremtClimber.Stamina}, Count of Conquered Peaks: {curremtClimber.ConqueredPeaks.Count}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string CampRecovery(string climberName, int daysToRecover)
        {
            if (!baseCamp.Residents.Contains(climberName))
            {
                return $"{climberName} not found at the BaseCamp.";
            }

            IClimber currentClimber = climbers.All.First(c => c.Name == climberName);

            if (currentClimber.Stamina == 10)
            {
                return $"{climberName} has no need of recovery.";
            }

            currentClimber.Rest(daysToRecover);

            return $"{climberName} has been recovering for {daysToRecover} days and is ready to attack the mountain.";
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            if (climbers.All.Any(c => c.Name == name))
            {
                return $"{name} is a participant in {climbers.GetType().Name} and cannot be duplicated.";
            }

            IClimber currentClimber;

            if (isOxygenUsed)
            {
                currentClimber = new OxygenClimber(name);
            }
            else
            {
                currentClimber = new NaturalClimber(name);
            }

            climbers.Add(currentClimber);
            baseCamp.ArriveAtCamp(currentClimber.Name);

            return $"{name} has arrived at the BaseCamp and will wait for the best conditions.";
        }

        public string OverallStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***Highway-To-Peak***");

            foreach (var climber in climbers.All.OrderByDescending(c => c.ConqueredPeaks.Count).ThenBy(c => c.Name))
            {
                sb.AppendLine(climber.ToString());

                List <IPeak> climbersPeaks = new List<IPeak>();

                foreach (var peakName in climber.ConqueredPeaks)
                {
                    climbersPeaks.Add(peaks.All.First(p => p.Name == peakName));
                }

                foreach (var climbersPeak in climbersPeaks.OrderByDescending(p => p.Elevation))
                {
                    sb.AppendLine(climbersPeak.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
