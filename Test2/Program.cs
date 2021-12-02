using System.Text;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Test2;

public class Program
{
    public static void Main(string[] args)
    {
        double[] deb = GetDoubleArr(12);
        double[] cred = GetDoubleArr(12);

        CompanyStatistic(deb, cred);

        int[] arr = { 0, -4, 6, 8, 3 };
        Array.Reverse(arr);
        int[] arr2 = DeleteMaxAndMin(arr);


    }

    static string FlipCoin()
    {
        Random r = new Random();
        int flip = r.Next(0, 10);

        if (flip >= 6)
        {
            return "Орел";
        }
        else
        {
            return "Решка";
        }
    }

    static int OddSum(int[] source)
    {
        int sum = 0;

        for (int i = 0; i < source.Length; i++)
        {
            if (source[i] % 2 == 0)
            {
                sum +=source[i];
            }
        }
        return sum;
    }

    static double[] GetDoubleArr(int elements)
    {
        double[] arr = new double[elements];

        Random r = new Random();

        for (int i = 0; i < elements; i++)
        {
            arr[i] = r.NextDouble() * 5000;
        }

        return arr;
    }

    static void BestResults(int[] height, int[] length)
    {
        int top = 3;

        PrintTop(length, top);
        PrintTop(height, top); 
    }

    static void PrintTop(int[] source, int top)
    {
        if (top > source.Length)
        {
            throw new Exception();
        }

        Array.Sort(source);
        int count = 0;
        //for (int i = source.Length - 1; i >= 0; i--)
        //{
        //    Console.WriteLine(source[i]);
        //    count++;
        //    if (count == top)
        //    {
        //        count = 0;
        //        break;
        //    }
        //}

        int lastIndex = source.Length - 1;

        while (count <= top)
        {
            Console.WriteLine(source[lastIndex--]);
            count++;
        }
    }

    static void CompanyStatistic(double[] debit, double[] credit)
    {
        double[] ballance = new double[12];
        double total = 0;
        double max = double.MinValue;
        int maxMonth = 0;
        double min = double.MaxValue;
        int minMonth = 0;
        int positiveMonth = 0;

        for (int i = 0; i < 12; i++)
        {
            ballance[i] = debit[i] - credit[i];

            total += ballance[i];

            if (ballance[i] > max)
            {
                max = ballance[i];
                maxMonth = i + 1;
            }

            if (ballance[i] < min)
            {
                min = ballance[i];
                minMonth = i + 1;
            }

            if (ballance[i] > 0)
            {
                positiveMonth++;
            }
        }

        Console.WriteLine("Ballance");
        foreach (var item in ballance)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine($"Total: {total}");

        Console.WriteLine($"Min month {minMonth}, max {maxMonth}, positive {positiveMonth}");
    }

    static int[] DeleteMaxAndMin(int[] source)
    {
        int[] result = new int[source.Length - 2];

        int min = Min(source);
        int max = Max(source);

        if (max > min)
        {
            Array.Copy(source, 0, result, 0, min);
            Array.Copy(source, min + 1, result, min, max - min - 1);
            Array.Copy(source, max + 1, result, max - 1, source.Length - max - 1);
        }
        else
        {
            Array.Copy(source, 0, result, 0, max);
            Array.Copy(source, max + 1, result, max, min - max - 1);
            Array.Copy(source, min + 1, result, min - 1, source.Length - min - 1);
        }

        return result;
    }

    static int Max(int[] source)
    {
        int max = int.MinValue;
        int index = -1;

        for (int i = 0; i < source.Length; i++)
        {
            if (source[i] > max)
            {
                max = source[i];
                index = i;
            }
        }

        return index;
    }

    static int Min(int[] source)
    {
        int min = int.MaxValue;
        int index = -1;

        for (int i = 0; i < source.Length; i++)
        {
            if (source[i] < min)
            {
                min = source[i];
                index = i;
            }
        }

        return index;
    }
}