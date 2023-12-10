using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using System.Reflection;
using System.Text;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private DiverRepository divers;
        private FishRepository fish;

        public Controller()
        {
            divers = new DiverRepository();
            fish = new FishRepository();
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            if (!divers.Models.Any(m => m.Name == diverName))
            {
                return $"{nameof(DiverRepository)} has no {diverName} registered for the competition.";
            }

            if (!fish.Models.Any(m => m.Name == fishName))
            {
                return $"{fishName} is not allowed to be caught in this competition.";
            }

            IDiver currentDiver = divers.Models.First(d => d.Name == diverName);
            IFish currentFish = fish.Models.First(f => f.Name == fishName);

            if (currentDiver.HasHealthIssues)
            {
                return $"{diverName} will not be allowed to dive, due to health issues.";
            }

            if (currentDiver.OxygenLevel < currentFish.TimeToCatch)
            {
                currentDiver.Miss(currentFish.TimeToCatch);

                if (currentDiver.OxygenLevel <= 0)
                {
                    currentDiver.UpdateHealthStatus();
                }

                return $"{diverName} missed a good {fishName}.";
            }
            else if (currentDiver.OxygenLevel == currentFish.TimeToCatch)
            {
                if (isLucky == true)
                {
                    currentDiver.Hit(currentFish);
                    if (currentDiver.OxygenLevel <= 0)
                    {
                        currentDiver.UpdateHealthStatus();
                    }
                    return $"{diverName} hits a {currentFish.Points}pt. {fishName}.";
                }
                else
                {
                    currentDiver.Miss(currentFish.TimeToCatch);
                    if (currentDiver.OxygenLevel <= 0)
                    {
                        currentDiver.UpdateHealthStatus();
                    }
                    return $"{diverName} missed a good {fishName}.";
                }
            }
            else if (currentDiver.OxygenLevel > currentFish.TimeToCatch)
            {
                currentDiver.Hit(currentFish);
            }
            return $"{diverName} hits a {currentFish.Points}pt. {fishName}.";
        }

        public string CompetitionStatistics()
        {
            StringBuilder sb = new();

            sb.AppendLine("**Nautical-Catch-Challenge**");

            foreach (IDiver currentDiver in divers.Models
                .OrderByDescending(d => d.CompetitionPoints)
                .ThenByDescending(d => d.Catch.Count)
                .ThenBy(d => d.Name)
                .Where(d => d.HasHealthIssues == false))
            {
                sb.AppendLine(currentDiver.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            var subclassTypes = Assembly
                .GetAssembly(typeof(Diver))
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Diver)));

            bool isValid = false;

            foreach (var diver in subclassTypes)
            {
                if (diver.Name == diverType)
                {
                    isValid = true;
                }
            }

            if (!isValid)
            {
                return $"{diverType} is not allowed in our competition.";
            }

            if (divers.Models.Any(m => m.Name == diverName))
            {
                return $"{diverName} is already a participant -> {nameof(DiverRepository)}.";
            }

            IDiver currentDiver = new FreeDiver(diverName);

            if (diverType == "ScubaDiver")
            {
                currentDiver = new ScubaDiver(diverName);
            }

            divers.AddModel(currentDiver);

            return $"{diverName} is successfully registered for the competition -> {nameof(DiverRepository)}.";
        }

        public string DiverCatchReport(string diverName)
        {
            IDiver currentDiver = divers.Models.First(m => m.Name == diverName);

            StringBuilder sb = new();

            sb.AppendLine($"Diver [ Name: {diverName}, Oxygen left: {currentDiver.OxygenLevel}, Fish caught: {currentDiver.Catch.Count}, Points earned: {currentDiver.CompetitionPoints} ]");

            foreach (var fishName in currentDiver.Catch)
            {
                var currentFish = fish.Models.First(m => m.Name == fishName);

                sb.AppendLine(currentFish.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string HealthRecovery()
        {
            var diversWithIssues = divers.Models.Where(d => d.HasHealthIssues == true);

            int countDiversWithIssues = diversWithIssues.Count();

            foreach (var diver in diversWithIssues)
            {
                diver.UpdateHealthStatus();
                diver.RenewOxy();
            }
            return $"Divers recovered: {countDiversWithIssues}";
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            var subclassTypes = Assembly
                .GetAssembly(typeof(Fish))
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Fish)));

            bool isValid = false;

            foreach (var fish in subclassTypes)
            {
                if (fish.Name == fishType)
                {
                    isValid = true;
                }
            }

            if (!isValid)
            {
                return $"{fishType} is forbidden for chasing in our competition.";
            }

            if (fish.Models.Any(m => m.Name == fishName))
            {
                return $"{fishName} is already allowed -> {nameof(FishRepository)}.";
            }

            IFish currentFIsh = new DeepSeaFish(fishName, points);

            if (fishType == "PredatoryFish")
            {
                currentFIsh = new PredatoryFish(fishName, points);
            }
            else if (fishType == "PredatoryFish")
            {
                currentFIsh = new ReefFish(fishName, points);
            }

            fish.AddModel(currentFIsh);

            return $"{fishName} is allowed for chasing.";
        }
    }
}
