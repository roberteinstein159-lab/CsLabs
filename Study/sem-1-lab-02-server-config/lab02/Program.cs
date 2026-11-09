using System;
using System.ComponentModel.Design;
namespace lab02;

class Program
{
    public static void Main()
    {
        Random rand = new Random();
        int pingst = rand.Next(20,101);
        int students = rand.Next(2000,8001);
        int pingse = rand.Next(20, 101);
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine("Добро пожаловать на сервер, введите пароль");
        Console.WriteLine("-------------------------------------------");
        string password = Console.ReadLine();
        if (!string.IsNullOrEmpty(password))
        {
            Console.WriteLine("Вы зашли на сервер под своим паролем!");
        }
        else
        {
            Console.WriteLine("Введите пароль снова");
            return;
        }
        Console.WriteLine($"На сервере сейчас {students} cтудентов");
        Console.WriteLine($"Ващ пинг: {pingst}");
        Console.WriteLine($"Пинг сервера: {pingse}");
        if ((pingst > 50 && pingse <50)||(pingst < 50 && pingse > 50)){
            Console.WriteLine("Пинг слишком большой, могут быть неполадки в работе с сервером");
        }
        else
        {
            Console.WriteLine("Ваш пинг в норме, с сервером не будет проблем");
        }
        if (students > 5001 && students < 7001)
        {
            Console.WriteLine("На сервере много учащихся, возможна нагрузка на сервер, подтвердите запуск, напишите Y/N: ");
            string acception = Console.ReadLine();
            if (acception == "Y" || acception == "y")
            {
                Console.WriteLine("Сервер запущен");
            }
            else if (acception == "N" || acception == "n")
            {
                Console.WriteLine("Сервер не запущен");
            }
            else
            {
                Console.WriteLine("Введите правильный символ, сервер не запущен");
            }
        }

        else if (students < 5001)
        {
            Console.WriteLine("На сервере нормальное количество людей, проблем c запуском не будет");

        }
        else
        {
            Console.WriteLine("На сервере слишком много учащихся, запуск невозможен");
        }
        
        }


}