using System;
using CompetitorSetting;
using PrintLibrary;
using Competition.Runtime;
using System.Reflection;

namespace Competition.MainProgram
{
    class Program
    {
        private static void TaskFunction()
        {
            Func<int, Type> ReturnCompetitor = (int Number) =>
            {
                switch(Number)
                {
                    case 1:
                        return typeof(Kiana);
                    case 2:
                        return typeof(RaidenMei);
                    case 3:
                        return typeof(RitaRossweisse);
                    case 4:
                        return typeof(TheresaApocalypse);
                    case 5:
                        return typeof(CorvusCorax);
                    case 6:
                        return typeof(Bronya);
                    case 7:
                        return typeof(KallenAndSakura);
                    case 8:
                        return typeof(SeeleVollerei);
                    case 9:
                        return typeof(FuHua);
                    case 10:
                        return typeof(Himeko);
                }
                return null;
            };
            Type LeftCompetitor, RightCompetitor;
            Console.WriteLine("选择第一位选手：");
            Console.WriteLine("1.Kiana 2.RaidenMei 3.RitaRossweisse 4.TheresaApocalypse 5.CorvusCorax 6.Bronya 7.KallenAndSakura 8.SeeleVollerei 9.FuHua 10.Himeko");
            LeftCompetitor = ReturnCompetitor(Convert.ToInt32(Console.ReadLine()));
            Console.Clear();
            Console.WriteLine("选择第二位选手：");
            Console.WriteLine("1.Kiana 2.RaidenMei 3.RitaRossweisse 4.TheresaApocalypse 5.CorvusCorax 6.Bronya 7.KallenAndSakura 8.SeeleVollerei 9.FuHua 10.Himeko");
            RightCompetitor = ReturnCompetitor(Convert.ToInt32(Console.ReadLine()));
            Console.Clear();
            Console.WriteLine("比赛回合数：");
            int Round = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("1.包含文件输出 2.无文件输出");
            typeof(PrintSetting).GetProperty("FileOrNot").SetValue(new PrintSetting(), Convert.ToInt32(Console.ReadLine()) == 1 ? true : false);
            Console.Clear();
            Console.WriteLine("1.包含控制台输出 2.无控制台输出");
            typeof(PrintSetting).GetProperty("ScreenOrNot").SetValue(new PrintSetting(), Convert.ToInt32(Console.ReadLine()) == 1 ? true : false);
            Console.Clear();
            if((bool) typeof(PrintSetting).GetProperty("FileOrNot").GetValue(new PrintSetting()) == true)
            {
                Console.WriteLine("文件名：");
                typeof(PrintSetting).GetProperty("FileName").SetValue(new PrintSetting(), Console.ReadLine());
                Console.Clear();
            }
            int AW = 0, BW = 0;
            for(int i = 1; i <= Round; i++)
            {
                var A = Activator.CreateInstance(LeftCompetitor);
                var B = Activator.CreateInstance(RightCompetitor);
                var TCompetition = Activator.CreateInstance(typeof(Competition<,>).MakeGenericType(A.GetType(), B.GetType()), A, B);
                if((bool) typeof(PrintSetting).GetProperty("ScreenOrNot").GetValue(new PrintSetting()) == true)
                {
                    TCompetition.GetType().GetProperty("TextResult").SetValue(TCompetition, TCompetition.GetType().GetProperty("TextResult").GetValue(TCompetition) + ( $"第{i}局\n" ));
                }
                TCompetition.GetType().GetMethod("TaskFunction").Invoke(TCompetition, null);
                if(TCompetition.GetType().GetProperty("Winner").GetValue(TCompetition) == A)
                {
                    AW++;
                }
                else if(TCompetition.GetType().GetProperty("Winner").GetValue(TCompetition) == B)
                {
                    BW++;
                }
                if(i == Round)
                {
                    if((bool) typeof(PrintSetting).GetProperty("FileOrNot").GetValue(new PrintSetting()) == true)
                    {
                        new FilePrint($"{AW} {BW}\n").PrintMethod();
                    }
                }
            }
            if((bool) typeof(PrintSetting).GetProperty("ScreenOrNot").GetValue(new PrintSetting()) == true)
            {
                Console.WriteLine($"{AW} {BW}");
            }
            Console.ReadLine();
        }
        public static void Main()
        {
            TaskFunction();
        }
    }
}