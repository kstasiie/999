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

        Runner[] runnerArray;

        public int Length => runnerArray.Length;

        public RunnerArray()
        {
            runnerArray = new Runner[0];
        }

        public RunnerArray(int length)
        {
            runnerArray = new Runner[length];
            for (int i = 0; i < length; i++)
            {
                runnerArray[i] = new Runner(random.Next(1, 100), random.Next(1, 1000));
            }
        }

        public void Show()
        {
            for (int i = 0; i < runnerArray.Length; i++)
            {
                runnerArray[i].Show();
            }
        }
    }
}
