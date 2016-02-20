using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security_first_task
{
    class Calculator
    {
        public List<double> Values;
        public Dictionary<int, int> Sections;
        public double Interval;
        private const int DEFAULT_SECTIONS_COUNT = 10;
        private const int DEFAULT_VALUES_COUNT = 50000;
        private int _sectionsCount;

        public double MeanValue
        {
            get { return Values.Sum() / Values.Count; }
        }
        public double Dispersion
        {
            get
            {
                double summ = 0;
                foreach (var value in Values)
                {
                    summ += Math.Pow(value - MeanValue, 2);
                }
                return summ / Values.Count;
            }
        }

        public Calculator()
        {
            Values = new List<double>();
            Sections = new Dictionary<int, int>();
        }

        private double GenerateNextValue(double baseValue)
        {
            double fullNumber = 11 * baseValue + Math.PI;
            return fullNumber - Math.Truncate(fullNumber);
        }

        public int FillData(double initialValue)
        {
            Values.Add(initialValue);
            double newValue = GenerateNextValue(initialValue);
            while (!Values.Contains(newValue))
            {
                Values.Add(newValue);
                newValue = GenerateNextValue(newValue);
                if (Values.Count > DEFAULT_VALUES_COUNT)
                    return DEFAULT_VALUES_COUNT;
            }
            return Values.Count;
        }

        public void GenerateSections(int sectionsCount = DEFAULT_SECTIONS_COUNT)
        {
            _sectionsCount = sectionsCount;
            Interval = (Values.Max() - Values.Min()) / _sectionsCount;
            for (int i = 0; i <_sectionsCount; i++)
            {
                Sections.Add(i, 0);
            }
            foreach (double value in Values)
            {
                for (int i = 0; i < _sectionsCount; i++)
                {
                    if ((value >= Interval*i) && (value < Interval*(i + 1)))
                        Sections[i] += 1;
                }
            }
        }

        public double GenerateXi()
        {
            // TODO Спросить Вику как считать эту поебень

            double xi = 0.0;
            foreach (KeyValuePair<int, int> section in Sections)
            {
                xi += Math.Pow((section.Value - 1.0/_sectionsCount), 2) / (1.0/_sectionsCount);
            }
            return xi;
        }




    }
}
