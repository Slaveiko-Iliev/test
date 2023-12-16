using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Repositories.Contracts;
using System.Text;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private IRepository<IDiver> divers;
        private IRepository<IFish> fish;

        public Controller()
        {
            divers = new DiverRepository();
            fish = new FishRepository();
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            if (divers.GetModel(diverName) == null)
            {
                return $"{nameof(DiverRepository)} has no {diverName} registered for the competition.";
            }

            if (fish.GetModel(fishName) == null)
            {
                return $"{fishName} is not allowed to be caught in this competition.";
            }

            IDiver currentDiver = divers.GetModel(diverName);
            IFish currentFish = fish.GetModel(fishName);

            if (currentDiver.HasHealthIssues)
            {
                return $"{diverName} will not be allowed to dive, due to health issues.";
            }

            if (currentDiver.OxygenLevel < currentFish.TimeToCatch)
            {
                currentDiver.Miss(currentFish.TimeToCatch);

                if (currentDiver.OxygenLevel == 0)
                {
                    currentDiver.UpdateHealthStatus();
                }

                return $"{diverName} missed a good {fishName}.";
            }
            else if (currentDiver.OxygenLevel == currentFish.TimeToCatch)
            {
                if (isLucky)
                {
                    currentDiver.Hit(currentFish);

                    if (currentDiver.OxygenLevel == 0)
                    {
                        currentDiver.UpdateHealthStatus();
                    }

                    return $"{diverName} hits a {currentFish.Points}pt. {fishName}.";
                }
                else
                {
                    currentDiver.Miss(currentFish.TimeToCatch);

                    if (currentDiver.OxygenLevel == 0)
                    {
                        currentDiver.UpdateHealthStatus();
                    }

                    return $"{diverName} missed a good {fishName}.";
                }
            }
            else
            {
                currentDiver.Hit(currentFish);

                return $"{diverName} hits a {currentFish.Points}pt. {fishName}.";
            }
        }

        public string CompetitionStatistics()
        {
            StringBuilder sb = new();

            sb.AppendLine("**Nautical-Catch-Challenge**");

            foreach (var currentDiver in divers.Models.OrderByDescending(d => d.CompetitionPoints).ThenByDescending(d => d.Catch.Count).ThenBy(d => d.Name).Where(d => d.HasHealthIssues == false))
            {
                sb.AppendLine(currentDiver.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (diverType != "FreeDiver" && diverType != "ScubaDiver")
            {
                return $"{diverType} is not allowed in our competition.";
            }

            if (divers.GetModel(diverName) != null)
            {
                return $"{diverName} is already a participant -> {nameof(DiverRepository)}.";
            }

            IDiver diver;

            if (diverType == nameof(FreeDiver))
            {
                diver = new FreeDiver(diverName);
            }
            else
            {
                diver = new ScubaDiver(diverName);
            }

            divers.AddModel(diver);

            return $"{diverName} is successfully registered for the competition -> {nameof(DiverRepository)}.";
        }

        public string DiverCatchReport(string diverName)
        {
            IDiver currentDiver = divers.GetModel(diverName);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Diver [ Name: {currentDiver.Name}, Oxygen left: {currentDiver.OxygenLevel}, Fish caught: {currentDiver.Catch.Count}, Points earned: {currentDiver.CompetitionPoints} ]");
            sb.AppendLine("Catch Report:");

            foreach (var currentFishName in currentDiver.Catch)
            {
                sb.AppendLine(fish.GetModel(currentFishName).ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string HealthRecovery()
        {
            int diversRecovered = 0;

            foreach (IDiver diver in divers.Models.Where(d => d.HasHealthIssues))
            {
                diver.UpdateHealthStatus();
                diver.RenewOxy();
                diversRecovered++;
            }

            return $"Divers recovered: {diversRecovered}";
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (fishType != "ReefFish" && fishType != "DeepSeaFish" && fishType != "PredatoryFish")
            {
                return $"{fishType} is forbidden for chasing in our competition.";
            }

            if (fish.GetModel(fishName) != null)
            {
                return $"{fishName} is already allowed -> {nameof(FishRepository)}.";
            }

            IFish currentFish;

            if (fishType == nameof(ReefFish))
            {
                currentFish = new ReefFish(fishName, points);
            }
            else if (fishType == nameof(DeepSeaFish))
            {
                currentFish = new DeepSeaFish(fishName, points);
            }
            else
            {
                currentFish = new PredatoryFish(fishName, points);
            }

            fish.AddModel(currentFish);

            return $"{fishName} is allowed for chasing.";
        }
    }
}
