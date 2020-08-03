using System;
using System.Threading.Tasks;
using CustomException;
using CompetitorSetting;
using CompetitionClass;

namespace MyCompetition
{
    class Program
    {
        public static void Main()
        {
            int AW = 0, BW = 0;
            for(int i = 1; i <= 10; i++)
            {
                var A = new TheresaApocalypse();
                var B = new KallenAndSakura();
                var TCompetition = new Competition<TheresaApocalypse, KallenAndSakura>(A, B);
                TCompetition.TaskFunction();
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
            Console.ReadLine();
        }
    }
}