
            int number = int.Parse(Console.ReadLine());

            List<double> doubles = new();

            for (int i = 0; i < number; i++)
            {
                doubles.Add(double.Parse(Console.ReadLine()));
            }

            double elementForComparison = double.Parse(Console.ReadLine());

            Console.WriteLine(CountOfLargerElements(doubles, elementForComparison));

            static int CountOfLargerElements<T>(List<T> list, T elementForComparison)
            where T : IComparable<T>
            {
                int count = 0;

                foreach (T element in list)
                {
                    if (element.CompareTo(elementForComparison) > 0)
                    {
                        count++;
                    }
                }

                return count;
            }
