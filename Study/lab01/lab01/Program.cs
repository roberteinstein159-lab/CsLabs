using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("======================================");
        Console.WriteLine("     ПРОВЕРКА ИГРОВОГО СЕРВЕРА");
        Console.WriteLine("======================================");
        Console.WriteLine("Выберите способ ввода данных:");
        Console.WriteLine("1 — ввести вручную");
        Console.WriteLine("2 — прочитать из файла server.txt");
        Console.Write("Ваш выбор: ");

        string inputMode = Console.ReadLine();

        string serverName;
        int playersNow;
        int playersMax;
        int ping;
        int uptimeHours;

        if (inputMode == "1")
        {
            Console.Write("Введите название сервера: ");
            serverName = Console.ReadLine();

            Console.Write("Введите количество игроков сейчас: ");
            string playersNowStr = Console.ReadLine();
            playersNow = Convert.ToInt32(playersNowStr);

            Console.Write("Введите максимальное количество игроков: ");
            string playersMaxStr = Console.ReadLine();
            playersMax = Convert.ToInt32(playersMaxStr);

            Console.Write("Введите пинг сервера в миллисекундах: ");
            string pingStr = Console.ReadLine();
            ping = Convert.ToInt32(pingStr);

            Console.Write("Сколько часов сервер работает без перезапуска: ");
            string uptimeHoursStr = Console.ReadLine();
            uptimeHours = Convert.ToInt32(uptimeHoursStr);
        }
        else if (inputMode == "2")
        {
            if (!File.Exists("server.txt"))
            {
                Console.WriteLine("Файл server.txt не найден.");
                return;
            }

            string[] serverData = File.ReadAllLines("server.txt");

            if (serverData.Length < 5)
            {
                Console.WriteLine("В файле должно быть не меньше 5 строк.");
                return;
            }

            serverName = serverData[0];
            playersNow = Convert.ToInt32(serverData[1]);
            playersMax = Convert.ToInt32(serverData[2]);
            ping = Convert.ToInt32(serverData[3]);
            uptimeHours = Convert.ToInt32(serverData[4]);
        }
        else
        {
            Console.WriteLine("Неверный выбор. Запустите программу и выберите 1 или 2.");
            return;
        }

        if (playersMax <= 0)
        {
            Console.WriteLine("Максимальное количество игроков должно быть больше нуля.");
            return;
        }

        int freeSlots = playersMax - playersNow;
        double occupancyPercent = (double)playersNow / playersMax * 100;
        bool serverReady = ping <= 100 && freeSlots > 0;

        Console.WriteLine();
        Console.WriteLine("======================================");
        Console.WriteLine("          СВОДКА СЕРВЕРА");
        Console.WriteLine("======================================");
        Console.WriteLine($"Сервер: {serverName}");
        Console.WriteLine($"Игроков онлайн: {playersNow} из {playersMax}");
        Console.WriteLine($"Свободных мест: {freeSlots}");
        Console.WriteLine($"Заполненность: {occupancyPercent:F1}%");
        Console.WriteLine($"Пинг: {ping} мс");
        Console.WriteLine($"Работает без перезапуска: {uptimeHours} ч");

        if (serverReady)
        {
            Console.WriteLine("Итог: сервер готов принимать игроков.");
        }
        else
        {
            Console.WriteLine("Итог: сервер требует внимания.");

            if (ping > 100)
            {
                Console.WriteLine("- Пинг выше 100 мс.");
            }

            if (freeSlots <= 0)
            {
                Console.WriteLine("- Свободных мест нет.");
            }
        }
    }
}