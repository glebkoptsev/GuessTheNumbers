using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuessTheNumbers
{
    class Program
    {
        static void Main()
        {
        start:
            Console.WriteLine("Введите количество отгадываемых чисел");
            string cntstr = Console.ReadLine();
            if (!int.TryParse(cntstr, out int cnt)) goto start;
            var compNumbers = new List<int>();

            Thread.Sleep(1000);

            var rnd = new Random();
            for (int i = 0; i < cnt; i++) compNumbers.Add(rnd.Next(0, 9));

            Console.WriteLine("Компьютер загадал числа");
            Thread.Sleep(1000);
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

        #region ход человека
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

            if (1.0 - Convert.ToDouble(failCount) / Convert.ToDouble(cnt) > 0.5)
            {
                Console.WriteLine("Было близко, но нет");
                goto human;
            }

            Console.WriteLine("Даже не близко, ход переходит к компьютеру");

            #endregion

            Thread.Sleep(1000);

        #region ход компьютера
        comp:
            var compAnswer = new List<int>();
            var rnd2 = new Random();
            for (int i = 0; i < cnt; i++) compAnswer.Add(rnd2.Next(0, 9));
            var failCompCount = humNumbers.Except(compAnswer).Count();

            if (failCompCount == 0)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Победил компьютер!");
                goto end;
            }

            if (1.0 - Convert.ToDouble(failCompCount) / Convert.ToDouble(cnt) > 0.5)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Компьютер был близко, но нет");
                goto comp;
            }

            Console.WriteLine("Компьютер в этом ходу не угадал и половины чисел!");
            Thread.Sleep(1000);
            Console.WriteLine("Ход переходит к человеку");
            goto human;
        #endregion


        end:
            Console.WriteLine("Игра окончена");
            Console.Read();
        }
    }
}
