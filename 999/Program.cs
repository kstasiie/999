namespace _999
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //создание
                Console.WriteLine("Создание");

                Runner runner1 = new Runner(15, 10);
                runner1.Show();
                Runner runner2 = new Runner(15, 100);
                runner2.Show();

                //вычисление времени статическим и нестатическим методом
                Console.WriteLine("\nВычисление времени статическим и нестатическим методом\n");

                Console.WriteLine("Вычисление времени нестатическим методом");
                double time2 = runner2.CalculatingTime();//нестатический метод
                Console.WriteLine(time2);

                Console.WriteLine("\nВычисление времени статическим методом");
                double time3 = Runner.CalculatingTime(50, 100);//статический метод
                Console.WriteLine(time3);


                //количество созданных объектов
                Console.WriteLine("\nКоличество созданных объектов");

                Console.WriteLine(Runner.GetCount);

                //перегрузка
                Console.WriteLine("\nПерегрузка\n");

                //унарные операции

                Console.WriteLine("Перегрузка операции ++ (увеличивает расстояние на 0.1 км)");
                runner1++;
                runner1.Show();

                Console.WriteLine("\nПерегрузка операции -- (уменьшает скорость на 0.05 км/ч)");
                runner2--;
                runner2.Show();

                //бинарные операции

                Console.WriteLine("\nПерегрузка операции - (вычисляет расстояния, на котором встретятся два бегун)");
                double mt = runner1 - runner2;//Вычисление расстояния, на котором встретятся два бегуна
                Console.WriteLine(mt);

                Console.WriteLine("\nПерегрузка операции ^ (увеличивает скорость на какую - то величину)");
                runner1 = runner1 ^ 4;//Увеличение скорости на величину
                runner1.Show();

                runner2 = 10 ^ runner2;
                runner2.Show();

                //операции приведение типа

                Console.WriteLine("\nЯвное приведение к double (возвращает значение, на которое нужно увеличить скорость)");
                double increasedSpeed = (double)runner1;//явное приведение к double
                Console.WriteLine(increasedSpeed);

                Console.WriteLine("\nНеявное приведение к string (возвращает время, за которое преодалел дистанцию)");
                string timeString = runner1;//неявное приведение к string
                Console.WriteLine(timeString);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Вычисления окончены!");
            }
        }
    }
}
