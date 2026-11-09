using System;
using System.Security.AccessControl;
namespace lab00;

class Program{
    public static void Main()
    {
        Console.Write("Добро пожаловать на сервер, введите свое имя: ");
        string name = Console.ReadLine();
        Console.Write("Отлично, теперь введите ваш возраст: ");
        string agestr = Console.ReadLine();
        int age = int.Parse(agestr);
        Console.Write("Введи свой город чтобы мы смогли подобрать оптимальный сервер: ");
        string city = Console.ReadLine();
        Console.WriteLine($"Найс, вот твой игровой профиль: \nИмя: {name}\nВозраст: {age}\nГород: {city}");
    }
