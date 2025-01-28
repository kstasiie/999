using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace _999
{
    internal class Runner
    {
        double speed;
        double distance;
        static int count;

        public double Speed
        {
            get => speed;
            set
            {
                if (value < 0)
                    throw new Exception("Скорость не может быть меньше 0 ");
                else
                    speed = value;
            }
        }

        public double Distance
        {
            get => distance;
            set
            {
                if (value < 0)
                    throw new Exception("Расстояние не может быть меньше 0 ");
                else
                    distance = value;
            }
        }
        public static int GetCount
        { get => count; }
        public Runner()
        { 
            Speed = 0;
            Distance = 0;
            count++; 
        }

        public Runner(double speed, double distance)
        { 
            Speed = speed;
            Distance = distance; 
            count++; 
        }

        public double CalculatingTime()
        {
            if (Math.Round(Distance / Speed, 2) != 0)
                return Math.Round(Distance / Speed, 2);
            else
            {
                return 0;
            }
        }

        public static double CalculatingTime(double speed, double distance)
        {
            if (Math.Round(distance / speed, 2) != 0)
                return Math.Round(distance / speed, 2);
            else
            {
                return 0;
            }
        }

        public static Runner operator ++(Runner runner)
        {
            runner.Distance = runner.Distance + 0.1;
            return runner;
        }

        public static Runner operator --(Runner runner)
        {
            runner.Speed = runner.Speed - 0.05;
            return runner;
        }

        public static double operator -(Runner r1, Runner r2) //Вычисление расстояния, на котором встретятся два бегуна
        {
            double initialDistance = 15.0;

            if (r1.Speed <= 0 && r2.Speed <= 0)
                return -1;

            double totalSpeed = r1.Speed + r2.Speed;

            double meetingTime = initialDistance / totalSpeed;

            if (meetingTime < 0)
                return -1;

            double meetingPoint = r1.Speed * meetingTime;

            return meetingPoint;
        }

        public static Runner operator ^(Runner r, double sp) //увеличение скорости на величину
        {
            return new Runner(r.Speed + sp, r.Distance);
        }

        public static Runner operator ^(double sp, Runner r) 
        {
            return new Runner(r.Speed + sp, r.Distance);
        }

        public static explicit operator double(Runner r) //явное приведение
        {
            double reducedTime = r.CalculatingTime() * 0.95;
            double requiredSpeed = r.Distance / reducedTime;
            return requiredSpeed - r.Speed;
        }

        public static implicit operator string(Runner r) 
        {
            int totalSeconds = (int)(r.CalculatingTime() * 3600);
            int hours = totalSeconds / 3600;
            int minutes = (totalSeconds % 3600) / 60;
            int seconds = totalSeconds % 60;
            return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }

        public void Show()
        {
            Console.WriteLine($"Скорость: {Speed} км/ч  Расстояние: {Distance} км Время: {CalculatingTime()}");
        }
    }
}
