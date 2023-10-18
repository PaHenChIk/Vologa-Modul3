using System;
using System.Collections.Generic;
using System.Linq;

public delegate void SortDelegate(List<long> list);

public class Sortirovka 
{
    private bool flag = true;
    public void vivod_sortirovka() 
    {
        List<long> numbers = new List<long>();
        SortDelegate sortDelegate = BubbleSort;



        while (flag)
        {
            Console.Clear();
            Console.WriteLine("1. Введите числа");
            Console.WriteLine("2. Просмотреть введенные числа");
            Console.WriteLine("3. Отсортировать числа");
            Console.WriteLine("4. Выход");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите числа через пробел: ");
                    string[] input = Console.ReadLine().Split(' ');
                    try
                    {
                        numbers = input.Select(long.Parse).ToList();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка: Ввод должен содержать только числа.");
                        break;
                    }
                    break;
                case "2":
                    Console.WriteLine("Введенные числа:");
                    foreach (long number in numbers)
                    {
                        Console.Write(number + " ");
                    }
                    Console.WriteLine();
                    break;
                case "3":
                    sortDelegate(numbers);
                    Console.WriteLine("Числа после сортировки:");
                    foreach (long number in numbers)
                    {
                        Console.Write(number + " ");
                    }
                    Console.WriteLine();
                    break;
                case "4":
                    flag = false;
                    break;
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
        flag = true;
    }
    static void Main(string[] args)
    {
        Sortirovka sortirovka = new Sortirovka();
        sortirovka.vivod_sortirovka();
    }

    static void BubbleSort(List<long> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = 0; j < list.Count - 1; j++)
            {
                if (list[j] > list[j + 1])
                {
                    long temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }
        }
    }
}
