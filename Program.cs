using System;
using System.Threading.Tasks;
using CompetitorSetting;
using CompetitionClass;
using BaseClass;

namespace MyCompetition
{
    class Program
    {
        public static void TaskFunction()
        {
            int AW = 0, BW = 0;
            for(int i = 1; i <= 1000; i++)
            {
                var A = new Himeko();
                var B = new KallenAndSakura();
                var TCompetition = new Competition<Himeko, KallenAndSakura>(A, B);
                Console.WriteLine($"第{i}局");
                TCompetition.TaskFunction();
                Console.WriteLine();
                if(TCompetition.Winner == A)
                {
                    AW++;
                }
                else if(TCompetition.Winner == B)
                {
                    BW++;
                }
            }
            Console.WriteLine($"{AW} {BW}");
        }
        public static void Main()
        {
            TaskFunction();
        }
    }
}
