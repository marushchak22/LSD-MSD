class Program
{
    static void Main(string[] args)
    {
        var familiesList = new List<Family>
        {
            new Family { Treasures = new List<int> { 1000, 500, 200, 300 } },
            new Family { Treasures = new List<int> { 1500, 800, 1200 } },
            new Family { Treasures = new List<int> { 900, 2000, 3000, 500 } },
            new Family { Treasures = new List<int> { 600, 117600, 1700 } },
            new Family { Treasures = new List<int> { 1000, 500, 200, 300 } },
            new Family { Treasures = new List<int> { 1500, 800, 120460 } },
            new Family { Treasures = new List<int> { 900, 2000, 3000, 500 } },
            new Family { Treasures = new List<int> { 600, 1100, 1750 } },
            new Family { Treasures = new List<int> { 1000, 500, 200, 38800 } },
            new Family { Treasures = new List<int> { 1500, 800, 1200 } },
            new Family { Treasures = new List<int> { 900, 24000, 3000, 5005 } },
            new Family { Treasures = new List<int> { 600, 1100, 1700 } },
            new Family { Treasures = new List<int> { 10, 500, 2300, 3 } },
            new Family { Treasures = new List<int> { 1500, 800, 1200 } },
            new Family { Treasures = new List<int> { 900, 2000, 3000, 500 } },
            new Family { Treasures = new List<int> { 600, 1, 10 } },
        };

        var totalTreasures = new List<int>();

        foreach (var family in familiesList)
        {
            var sum = family.Treasures.Sum();
            totalTreasures.Add(sum);
        }

        LSDSort(totalTreasures);

        Console.WriteLine("Список сумарних скарбів родин:");
        foreach (var treasure in totalTreasures)
        {
            Console.WriteLine(treasure);
        }

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine();
        var totalSum = totalTreasures.Sum();
        Console.WriteLine("Сума всіх скарбів родин разом: " + totalSum);
        Console.ForegroundColor = ConsoleColor.White;
    }

    static void LSDSort(List<int> numbers)
    {
        if (numbers.Count <= 1)
            return;

        int maxDigits = numbers.Max().ToString().Length;
        int[] output = new int[numbers.Count];

        for (int digit = 0; digit < maxDigits; digit++)
        {
            int[] count = new int[10];

            foreach (int number in numbers)
            {
                int digitValue = GetDigitValue(number, digit);
                count[digitValue]++;
            }

            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                int number = numbers[i];
                int digitValue = GetDigitValue(number, digit);
                count[digitValue]--;
                output[count[digitValue]] = number;
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] = output[i];
            }
        }
    }

    static int GetDigitValue(int number, int digit)
    {
        return (number / (int)Math.Pow(10, digit)) % 10;
    }
}

class Family
{
    public List<int> Treasures { get; set; }
}
