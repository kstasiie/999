using System.Security.Cryptography.X509Certificates;
using Microsoft.Testing.Platform.Extensions.Messages;

namespace _999
{
    internal class Program
    {
        //public static void SortRunners(RunnerArray runnerArray) 
        //{
        //    for (int i = 0; i < runnerArray.Length - 1; i++)
        //    {
        //        for (int j = 0; j < runnerArray.Length - i - 1; j++) 
        //        {
        //            if (runnerArray[j].Distance < runnerArray[j + 1].Distance || runnerArray[j].Distance == runnerArray[j + 1].Distance && runnerArray[j].CalculatingTime() > runnerArray[j + 1].CalculatingTime())
        //            {
        //                Runner tempRunner = runnerArray[j];
        //                runnerArray[j] = runnerArray[j + 1];
        //                runnerArray[j + 1] = tempRunner;
        //            }
        //        }
        //    }
        //}

        public static void SortRunners(RunnerArray runnerArray)
        {
            for (int i = 0; i < runnerArray.Length - 1; i++)
            {
                for (int j = 0; j < runnerArray.Length - i - 1; j++)
                {
                    if (runnerArray[j] < runnerArray[i])
                    {
                        Runner tempRunner = runnerArray[j];
                        runnerArray[j] = runnerArray[j + 1];
                        runnerArray[j + 1] = tempRunner;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            try
            {
                //создание
                Console.WriteLine("Создание");

                Console.WriteLine("\nКонструктор без параметров\n");
                Runner runner = new Runner();
                runner.Show();

                Console.WriteLine("\nКонструктор с параметрами\n");
                Runner runner1 = new Runner(15, 10);
                runner1.Show();
                Runner runner2 = new Runner(15, 100);
                runner2.Show();

                //вычисление времени статическим и нестатическим методом
                
                Console.WriteLine("\nВычисление времени нестатическим методом\n");
                double time2 = runner2.CalculatingTime();//нестатический метод
                Console.WriteLine(time2);

                Console.WriteLine("\nВычисление времени статическим методом\n");
                double time3 = Runner.CalculatingTime(50, 100);//статический метод
                Console.WriteLine(time3);


                //количество созданных объектов
                Console.WriteLine("\nКоличество созданных объектов\n");

                Console.WriteLine(Runner.GetCount);

                //перегрузка

                //унарные операции

                Console.WriteLine("\n\n\nПерегрузка операции ++ (увеличивает расстояние на 0.1 км)\n");
                runner1++;
                runner1.Show();

                Console.WriteLine("\nПерегрузка операции -- (уменьшает скорость на 0.05 км/ч)\n");
                runner2--;
                runner2.Show();

                //бинарные операции

                Console.WriteLine("\nПерегрузка операции - (вычисляет расстояния, на котором встретятся два бегун)\n");
                double mt = runner1 - runner2;//Вычисление расстояния, на котором встретятся два бегуна
                Console.WriteLine(mt);

                Console.WriteLine("\nПерегрузка операции ^ (увеличивает скорость на какую-то величину)\n");
                runner1 = runner1 ^ 4;//Увеличение скорости на величину
                runner1.Show();

                runner2 = 10 ^ runner2;
                runner2.Show();

                //операции приведение типа

                Console.WriteLine("\n\n\nЯвное приведение к double (возвращает значение, на которое нужно увеличить скорость)\n");
                double increasedSpeed = (double)runner1;//явное приведение к double
                Console.WriteLine(increasedSpeed);

                Console.WriteLine("\nНеявное приведение к string (возвращает время, за которое преодалел дистанцию)\n");
                string timeString = runner1;//неявное приведение к string
                Console.WriteLine(timeString);

                Console.WriteLine("\n\n\nКласс-коллекция");

                Console.WriteLine("\nКонструктор без параметров\n");
                RunnerArray ra = new RunnerArray();
                ra.Show();

                Console.WriteLine("\nКонструктор с параметром\n");
                RunnerArray ra1 = new RunnerArray(5);
                ra1.Show();

                Console.WriteLine("\nКонструктор копирования\n");
                RunnerArray ra2 = new RunnerArray(ra1);
                ra2.Show();

                ra1[0].Speed = 100;
                Console.WriteLine("\nИзмененный массив");
                ra1.Show();
                Console.WriteLine("\nСкопированный массив (до изменения)\n");
                ra2.Show();

                Console.WriteLine("\nЗапись объекта и его получение с существующим индексом\n");
                RunnerArray ra3 = new RunnerArray(5);
                Console.WriteLine("Изначальный массив\n");
                ra3.Show();
                Console.WriteLine("\nЗапись в элемент с индексом 3 значения скорости 100 и его вывод\n");
                ra3[3].Speed = 100;
                ra3[3].Show();
                //Console.WriteLine("\nЗапись в элемент с индексом 10 значения скорости 100 и его вывод\n");
                //ra3[10].Speed = 100;
                //ra3[10].Show();

                Console.WriteLine("\nСортировка массива бегунов");
                Console.WriteLine("\nДо сортировки\n");
                ra1.Show();
                Console.WriteLine("\nПосле сортировки\n");
                SortRunners(ra1);
                ra1.Show();

                Console.WriteLine("\nКоличество созданных коллекций\n");
                Console.WriteLine(RunnerArray.GetCount);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("\nВычисления окончены!");
            }
        }
    }
}
