using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClothesMagazine
{
    public class Magazine
    {
        private List<Cloth> cloths;

        public Magazine(string magazineType, int capacity)
        {
            MagazineType = magazineType;
            Capacity = capacity;
            cloths = new List<Cloth>();
        }

        public string MagazineType { get; set; }
        public int Capacity { get; set; }
        public IReadOnlyCollection<Cloth> Cloths => cloths;

        public void AddCloth(Cloth cloth)
        {
            if (Capacity > 0)
            {
                cloths.Add(cloth);
            }
        }

        public bool RemoveCloth(string color)
        {
            Cloth cloth = cloths.FirstOrDefault(c => c.Color == color);

            return cloths.Remove(cloth);
        }

        public Cloth GetSmallestCloth()
        {
            return cloths.OrderBy(c => c.Size).First();
        }

        public Cloth GetCloth(string color)
        {
            return cloths.Find(c => c.Color == color);
        }

        public int GetClothCount()
        {
            return Cloths.Count;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{MagazineType} magazine contains:");
            foreach (var cloth in cloths.OrderBy(c => c.Size))
            {
                sb.AppendLine(cloth.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
