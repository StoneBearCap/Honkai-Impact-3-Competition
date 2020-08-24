using System;
using Competiotion.CharacterSetting;
using Competition.Runtime;

namespace Competition.MainProgram
{
    class Program
    {
        private static void TaskFunction()
        {
            Func<int, Type> ReturnCompetitor = (int Number) =>
             {
                 switch (Number)
                 {
                     case 1:
                         return new Kiana().GetType();
                     case 2:
                         return new RaidenMei().GetType();
                     case 3:
                         return new RitaRossweisse().GetType();
                     case 4:
                         return new TheresaApocalypse().GetType();
                     case 5:
                         return new CorvusCorax().GetType();
                     case 6:
                         return new Bronya().GetType();
                     case 7:
                         return new KallenAndSakura().GetType();
                     case 8:
                         return new SeeleVollerei().GetType();
                     case 9:
                         return new FuHua().GetType();
                     case 10:
                         return new Himeko().GetType();
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
            typeof(FileSetting).GetProperty("Use").SetValue(new FileSetting(), Convert.ToInt32(Console.ReadLine()) == 1 ? true : false);
            Console.Clear();
            if ((bool)typeof(FileSetting).GetProperty("Use").GetValue(new FileSetting()) == true)
            {
                Console.WriteLine("文件名：");
                typeof(FileSetting).GetProperty("FileName").SetValue(new FileSetting(), Console.ReadLine());
                Console.Clear();
            }
            int AW = 0, BW = 0;
            for (int i = 1; i <= Round; i++)
            {
                var A = Activator.CreateInstance(LeftCompetitor);
                var B = Activator.CreateInstance(RightCompetitor);
                dynamic TCompetition = Activator.CreateInstance(typeof(Competition<,>).MakeGenericType(A.GetType(), B.GetType()), A, B);
                Console.WriteLine($"第{i}局");
                TCompetition.GetType().GetProperty("TextResult").SetValue(TCompetition, TCompetition.GetType().GetProperty("TextResult").GetValue(TCompetition) + ($"第{i}局\n"));
                TCompetition.TaskFunction();
                Console.WriteLine();
                if (TCompetition.Winner == A)
                {
                    AW++;
                }
                else if (TCompetition.Winner == B)
                {
                    BW++;
                }
            }
            Console.WriteLine($"{AW} {BW}");
            Console.ReadLine();
        }
        //对照组，用于确认反射是否影响结果，计划后期版本删除此方法
        private static void TryTask()
        {
            int AW = 0, BW = 0;
            for (int i = 1; i <= 1000; i++)
            {
                var A = new Kiana();
                var B = new RaidenMei();
                var TCompetition = new Competition<Kiana, RaidenMei>(A, B);
                Console.WriteLine($"第{i}局");
                TCompetition.TaskFunction();
                Console.WriteLine();
                if (TCompetition.Winner == A)
                {
                    AW++;
                }
                else if (TCompetition.Winner == B)
                {
                    BW++;
                }
            }
            Console.WriteLine($"{AW} {BW}");
            Console.ReadLine();
        }
        public static void Main()
        {
            TaskFunction();
        }
    }
    class FileSetting
    {
        static public string FileName { get; private set; }
        static public bool Use { get; private set; } = false;
    }
}