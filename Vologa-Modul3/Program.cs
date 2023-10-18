using System;
using TaskManagerApp;

public class Vologa_Madul3
{
    static void Main(string[] args)
    {
        Vivod_Figur vivod_figur = new Vivod_Figur();
        Vivod_Notification vivod_notification = new Vivod_Notification();
        Zadachi zadachi = new Zadachi();
        Filter filter = new Filter();
        Sortirovka sortirovka = new Sortirovka();

        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Вывод фигур");
            Console.WriteLine("2. Вывод уведомлений");
            Console.WriteLine("3. Вывод задач");
            Console.WriteLine("4. Вывод фильтра");
            Console.WriteLine("5. Вывод сортировки");
            Console.WriteLine("6. Выход");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    vivod_figur.vivod_Figur();
                    Console.Clear();    
                    break;
                case 2:
                    vivod_notification.Vivod_notification();
                    Console.Clear();
                    break;
                case 3:
                    zadachi.vivod_zadachi();
                    Console.Clear();
                    break;
                case 4:
                    filter.vivod_filter();
                    Console.Clear();
                    break;
                case 5:
                    sortirovka.vivod_sortirovka();
                    Console.Clear();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Неверный выбор, попробуйте еще раз.");
                    break;
            }
        }
    }
}
