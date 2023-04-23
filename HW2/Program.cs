using System;
using System.Linq;
using System.Text;

namespace HW2
{
    class Program
    {
        public static int GetSumOfDigits(string str)
        {
            return (int)str.Where(x => Char.IsDigit(x))
                           .Select(x => Char.GetNumericValue(x))
                           .Sum();
        }

        public static int GetMaxDigit(string str)
        {
            return (int)str.Where(x => Char.IsDigit(x))
                           .Select(x => Char.GetNumericValue(x))
                           .DefaultIfEmpty(0)
                           .Max();
        }

        public static int GetIndexOfMaxDigit(string str)
        {
            char max = (char)(GetMaxDigit(str)+'0');
            return str.Trim()
                      .Select((val, idx) => (val, idx))
                      .Where(x => x.val == max)
                      .DefaultIfEmpty(('_',-1))
                      .First().Item2;
        }

        static void Main()
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;

            string str = "   n14 jw# !j3/..4,3";
            Console.WriteLine($"Початковий текст: \"{str}\"");

            //Task 1
            Console.WriteLine("\nTask 1");

            Console.WriteLine($"Сума цифр тексту дорівнює: {GetSumOfDigits(str)}");
            Console.WriteLine($"Максимальна цифра у тексті: {GetMaxDigit(str)}");


            //Task 2
            Console.WriteLine("\nTask 2");

            Console.WriteLine($"Індекс максимальної цифри у тексті: {GetIndexOfMaxDigit(str)}");


            //Task 3
            Console.WriteLine("\nTask 3");

            Random rand = new Random();
            int[] pages = new int[100];
            for (int i = 0; i < pages.Length; i++)
            {
                pages[i] = rand.Next() % 400 + 100;
            }

            foreach (int page in pages) //Виведення кількості сторінок усіх книг
            {
                Console.Write(page + " ");
            }

            int maxPages = pages.Max();
            Console.WriteLine($"\nКількість сторінок у найтовстішій книзі: {maxPages}");

            //Task 4
            Console.WriteLine("\nTask 4");

            double[] carSpeed = new double[40];
            for (int i = 0; i < carSpeed.Length; i++)
            {
                carSpeed[i] = Math.Round(rand.NextDouble() * 90 + 10, 2);
            }

            foreach (double speed in carSpeed) //Виведення швидкостей усіх машин
            {
                Console.Write(speed + " ");
            }

            double maxSpeed = carSpeed.Max();

            int firstCar = Array.IndexOf(carSpeed, maxSpeed);
            int lastCar = Array.LastIndexOf(carSpeed, maxSpeed);
            
            if(firstCar == lastCar)
            {
                Console.WriteLine($"\nНайбільш швидка машина знаходиться за індексом {firstCar}");
            }
            else
            {
                Console.WriteLine($"\nПерша найбільш швидка машина знаходиться за індексом {firstCar}");
                Console.WriteLine($"Остання найбільш швидка машина знаходиться за індексом {lastCar}");
            }
        }
    }
}