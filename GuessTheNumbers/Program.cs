using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
        start:
            Console.WriteLine("Введите количество отгадываемых чисел");
            string cntstr = Console.ReadLine();
            if (!int.TryParse(cntstr, out int cnt)) goto start;
            var compNumbers = new List<int>();

            var rnd = new Random();
            for (int i = 0; i < cnt; i++) compNumbers.Add(rnd.Next(0, 9));

            Console.WriteLine("Компьютер загадал числа");
            Console.WriteLine("Ваша очередь загадывать!");
            var humNumbers = new List<int>();

            for (int i = 0; i < cnt; i++)
            {
            error:
                Console.WriteLine($"Введите число номер {i + 1}");
                string numbstr = Console.ReadLine();
                if (!int.TryParse(numbstr, out int numb)) goto error;
                humNumbers.Add(numb);
            }

            human:
            Console.WriteLine($"Ваш ход, введите {cnt} чисел");

            var humAnswer = new List<int>();
            for (int i = 0; i < cnt; i++)
            {
            error:
                Console.WriteLine($"Введите число номер {i + 1}");
                string numbstr = Console.ReadLine();
                if (!int.TryParse(numbstr, out int numb)) goto error;
                humAnswer.Add(numb);
            }
            var failCount = compNumbers.Except(humAnswer).Count();
            if (failCount == 0)
            {
                Console.WriteLine("Победил человек!");
                goto end;
            }

            if (Convert.ToDouble(failCount) / Convert.ToDouble(cnt) > 0.5)
            {
                Console.WriteLine("Было близко, но нет");
                goto human;
            }

        end:
            Console.Read();
        }
    }
}
