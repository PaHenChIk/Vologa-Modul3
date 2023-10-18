using System;
using System.Collections.Generic;

namespace TaskManagerApp
{
   public class Zadachi
    {
        // Определяем делегат для выполнения задачи
        delegate void TaskDelegate(string task);
        private bool flag = true;
        public void vivod_zadachi() 
        {
            // Создаем словарь для хранения задач и соответствующих им делегатов
            Dictionary<string, TaskDelegate> tasks = new Dictionary<string, TaskDelegate>();

            while (flag)
            {
                Console.Clear();
                Console.WriteLine("Приложение для управления задачами");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Добавить задачу");
                Console.WriteLine("2. Выполнить задачи");
                Console.WriteLine("3. Выход");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите задачу: ");
                        string taskName = Console.ReadLine();
                        Console.WriteLine("Выберите делегата для выполнения задачи:");
                        Console.WriteLine("1. Отправка уведомления");
                        Console.WriteLine("2. Запись в журнал");
                        string delegateChoice = Console.ReadLine();
                        

                        TaskDelegate taskDelegate;
                        switch (delegateChoice)
                        {
                            case "1":
                                taskDelegate = NotifyTask;
                                break;
                            case "2":
                                taskDelegate = LogTask;
                                break;
                            default:
                                Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                                continue;
                        }

                        tasks.Add(taskName, taskDelegate);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Список задач:");
                        int index = 1;
                        foreach (var task in tasks)
                        {
                            Console.WriteLine($"{index}. {task.Key}");
                            index++;
                        }

                        Console.WriteLine("Выберите задачу для выполнения (номер): ");
                        if (int.TryParse(Console.ReadLine(), out int taskIndex) && taskIndex >= 1 && taskIndex <= tasks.Count)
                        {
                            var taskToExecute = new List<KeyValuePair<string, TaskDelegate>>(tasks)[taskIndex - 1];
                            ExecuteTask(taskToExecute);
                        }
                        else
                        {
                            Console.WriteLine("Недопустимый выбор задачи.");
                        }

                        break;
                    case "3":
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
            Zadachi zadachi= new Zadachi();
            zadachi.vivod_zadachi();
        }

        // Методы для выполнения задач с использованием делегатов
        static void ExecuteTask(KeyValuePair<string, TaskDelegate> task)
        {
            // Выполняем задачу
            task.Value(task.Key);

            Console.WriteLine($"Задача \"{task.Key}\" выполнена.");
        }

        // Метод для отправки уведомления о задаче
        static void NotifyTask(string task)
        {
            // Здесь можно добавить код для отправки уведомления о задаче
            Console.WriteLine($"Уведомление о задаче отправлено: {task}");
        }

        // Метод для записи задачи в журнал
        static void LogTask(string task)
        {
            // Здесь можно добавить код для записи задачи в журнал
            Console.WriteLine($"Задача записана в журнал: {task}");
        }
    }
}
