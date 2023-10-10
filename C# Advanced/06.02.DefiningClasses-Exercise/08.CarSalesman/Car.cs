using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine, int weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }


        public override string ToString()
        {
            string displacementAsString = string.Empty;
            if (Engine.Displacement == 0)
            {
                displacementAsString = "n/a";
            }
            else
            {
                displacementAsString = Engine.Displacement.ToString();
            }

            string efficiency = string.Empty;
            if (Engine.Efficiency == string.Empty)
            {
                efficiency = "n/a";
            }
            else
            {
                efficiency = Engine.Efficiency;
            }

            string weightAsString = string.Empty;
            if (Weight == 0)
            {
                weightAsString = "n/a";
            }
            else
            {
                weightAsString = Weight.ToString();
            }

            string color = string.Empty;
            if (Color == string.Empty)
            {
                color = "n/a";
            }
            else
            {
                color = Color;
            }


            return $"{Model}:{Environment.NewLine}" +
                $"  {Engine.Model}: {Environment.NewLine}" +
                $"    Power: {Engine.Power}{Environment.NewLine}" +
                $"    Displacement: {displacementAsString}{Environment.NewLine}" +
                $"    Efficiency: {efficiency}{Environment.NewLine}" +
                $"  Weight: {weightAsString}{Environment.NewLine}" +
                $"  Color: {color}";
        }
    }
}
