using System;
using System.Collections.Generic;
using System.Linq;

public delegate bool MessageFilter(string message);

public class Filter
{
    public void vivod_filter() 
    {
        // Запрашиваем у пользователя 5 сообщений
        List<string> messages = new List<string>();
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Введите сообщение {i + 1}: ");
            messages.Add(Console.ReadLine());
        }

        // Запрашиваем ключевое слово для фильтрации
        Console.Write("Введите ключевое слово для фильтрации: ");
        string keyword = Console.ReadLine();

        // Создаем делегат для фильтрации сообщений
        MessageFilter filter = message => message.Contains(keyword);

        // Фильтруем сообщения с помощью делегата
        List<string> filteredMessages = messages.Where(message => filter(message)).ToList();

        // Выводим отфильтрованные сообщения
        Console.WriteLine("Отфильтрованные сообщения:");
        foreach (string message in filteredMessages)
        {
            Console.WriteLine(message);
            
        }
        Console.ReadKey();
    } 
    static void Main(string[] args)
    {
       Filter filter = new Filter();
        filter.vivod_filter();
    }
}
