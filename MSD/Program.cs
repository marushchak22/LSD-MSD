using System;
using System.Collections.Generic;

class Family
{
    public List<int> Treasures { get; set; }
}

class TA12
{
    static int getMax(List<int> arr)
    {
        int mx = arr[0];
        foreach (int num in arr)
        {
            if (num > mx)
                mx = num;
        }
        return mx;
    }

    static void countSort(List<int> arr, int exp)
    {
        int n = arr.Count;
        List<int> output = new List<int>(new int[n]);
        int[] count = new int[10];

        for (int i = 0; i < 10; i++)
            count[i] = 0;

        foreach (int num in arr)
            count[(num / exp) % 10]++;

        for (int i = 1; i < 10; i++)
            count[i] += count[i - 1];

        for (int i = n - 1; i >= 0; i--)
        {
            output[count[(arr[i] / exp) % 10] - 1] = arr[i];
            count[(arr[i] / exp) % 10]--;
        }

        for (int i = 0; i < n; i++)
            arr[i] = output[i];
    }

    static void radixsort(List<int> arr)
    {
        int max = getMax(arr);

        for (int exp = 1; max / exp > 0; exp *= 10)
            countSort(arr, exp);
    }

    static void Main()
    {
        List<Family> families = new List<Family>
        {
            new Family { Treasures = new List<int> { 1000 } },
            new Family { Treasures = new List<int> { 1500} },
            new Family { Treasures = new List<int> { 900} },
            new Family { Treasures = new List<int> { 6 } },
            new Family { Treasures = new List<int> { 100} },
            new Family { Treasures = new List<int> { 1500 } },
            new Family { Treasures = new List<int> { 100 } },
            new Family { Treasures = new List<int> { 500} },
            new Family { Treasures = new List<int> { 9000} },
            new Family { Treasures = new List<int> { 699} },
            new Family { Treasures = new List<int> { 100} },
            new Family { Treasures = new List<int> { 0 } }
        };

        List<int> allTreasures = new List<int>();

        foreach (Family family in families)
            allTreasures.AddRange(family.Treasures);

        Console.WriteLine("Список сумарних скарбів родин:");

        radixsort(allTreasures);

        foreach (int treasure in allTreasures)
            Console.WriteLine(treasure);

        Console.ReadLine();
    }
}
