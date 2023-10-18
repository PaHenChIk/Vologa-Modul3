using System;
using System.Text.RegularExpressions;

public class NotificationEventArgs : EventArgs
{
    public string Message { get; set; }
}

public class Notification
{
    public delegate void NotificationEventHandler(object sender, NotificationEventArgs args);

    public event NotificationEventHandler MessageNotification;
    public event NotificationEventHandler CallNotification;
    public event NotificationEventHandler EmailNotification;

    public void SendMessage(string message)
    {
        MessageNotification.Invoke(this, new NotificationEventArgs { Message = message });
    }

    public void MakeCall(string message)
    {
        if (!Regex.IsMatch(message, @"^\+\d+$"))
            throw new Exception("Номер должен начинаться с '+' и содержать только цифры.");
        CallNotification?.Invoke(this, new NotificationEventArgs { Message = message });
    }

    public void SendEmail(string message)
    {
        if (!message.Contains("@") || !(message.Contains(".") ))
            throw new Exception("Адрес электронной почты должен содержать '@' и оканчиваться на '.com', '.ru' или '.by' и т.д.");
        EmailNotification?.Invoke(this, new NotificationEventArgs { Message = message });
    }
}

public class Vivod_Notification
{
    static void Main(string[] args)
    {
        Vivod_Notification vivod_notification = new Vivod_Notification();
        vivod_notification.Vivod_notification();
    }

    public void Vivod_notification()
    {

        var notification = new Notification();

        notification.MessageNotification += (sender, e) => Console.WriteLine("Сообщение: " + e.Message);
        notification.CallNotification += (sender, e) => Console.WriteLine("Звонок: " + e.Message);
        notification.EmailNotification += (sender, e) => Console.WriteLine("Письмо с адреса: " + e.Message);

        try
        {
            Console.Write("Введите сообщение: ");
            string message = Console.ReadLine();
            notification.SendMessage(message);

            Console.Write("Введите номер для звонка: ");
            string call = Console.ReadLine();
            notification.MakeCall(call);

            Console.Write("Введите адрес электронной почты: ");
            string email = Console.ReadLine();
            notification.SendEmail(email);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.ReadKey();
    }
}
