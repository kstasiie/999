using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _999
{
    internal class RunnerArray
    {
        static Random random = new Random();

        static int count;

        public static int GetCount
        {
            get => count; 
        }

        Runner[] runnerArray;

        public int Length => runnerArray.Length;

        public RunnerArray()
        {
            runnerArray = new Runner[0];
            count++;
        }

        public RunnerArray(int length)
        {
            runnerArray = new Runner[length];
            count++;
            for (int i = 0; i < length; i++)
            {
                runnerArray[i] = new Runner(random.Next(1, 100), random.Next(1, 1000));
            }
        }

        public RunnerArray(RunnerArray other)
        {
            runnerArray = new Runner[other.Length];
            count++;
            for (int i = 0; i < other.Length; i++)
                runnerArray[i] = new Runner (other[i].Speed, other[i].Distance);
        }

        public void Show()
        {
            for (int i = 0; i < runnerArray.Length; i++)
            {
                runnerArray[i].Show();
            }
        }

        public Runner this[int index]
        {
            get 
            { 
                if (index >= 0 && index < runnerArray.Length)
                return runnerArray[index];
                else throw new Exception("Выход за границы массива");
            }
            set 
            {
                if (index >= 0 && index < runnerArray.Length)
                    runnerArray[index] = value;
                else throw new Exception("Выход за границы массива");
            }
        }
    }
}
