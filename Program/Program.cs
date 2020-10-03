﻿using Competition.BaseClass;
using Competition.Runtime;
using CompetitorSetting;
using PrintLibrary;
using System;

namespace MainProgram
{
    class Program
    {
        private static void TaskFunction()
        {
            Competitor ReturnCompetitor(int Number)
            {
                switch (Number)
                {
                    case 1:
                        return new Kiana();
                    case 2:
                        return new RaidenMei();
                    case 3:
                        return new RitaRossweisse();
                    case 4:
                        return new TheresaApocalypse();
                    case 5:
                        return new CorvusCorax();
                    case 6:
                        return new Bronya();
                    case 7:
                        return new KallenAndSakura();
                    case 8:
                        return new SeeleVollerei();
                    case 9:
                        return new FuHua();
                    case 10:
                        return new Himeko();
                }
                return null;
            }
            Console.WriteLine("选择第一位选手：");
            Console.WriteLine("1.Kiana 2.RaidenMei 3.RitaRossweisse 4.TheresaApocalypse 5.CorvusCorax 6.Bronya 7.KallenAndSakura 8.SeeleVollerei 9.FuHua 10.Himeko");
            var A = ReturnCompetitor(Convert.ToInt32(Console.ReadLine()));
            Console.Clear();
            Console.WriteLine("选择第二位选手：");
            Console.WriteLine("1.Kiana 2.RaidenMei 3.RitaRossweisse 4.TheresaApocalypse 5.CorvusCorax 6.Bronya 7.KallenAndSakura 8.SeeleVollerei 9.FuHua 10.Himeko");
            var B = ReturnCompetitor(Convert.ToInt32(Console.ReadLine()));
            Console.Clear();
            Console.WriteLine("比赛回合数：");
            int Round = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("1.文件输出 2.无文件输出");
            PrintSetting.FileOrNot = Convert.ToInt32(Console.ReadLine()) == 1;
            Console.Clear();
            Console.WriteLine("1.控制台输出 2.无控制台输出");
            PrintSetting.ScreenOrNot = Convert.ToInt32(Console.ReadLine()) == 1;
            Console.Clear();
            if (PrintSetting.FileOrNot == true)
            {
                Console.WriteLine("文件名：");
                PrintSetting.FileName = Console.ReadLine();
                Console.Clear();
            }
            int AW = 0, BW = 0;
            var TCompetition = Activator.CreateInstance(typeof(Competition<,>).MakeGenericType(A.GetType(), B.GetType()), A, B);
            for (int i = 1; i <= Round; i++)
            {
                if (PrintSetting.ScreenOrNot == true)
                {
                    TCompetition.GetType().GetProperty("TextResult").SetValue(TCompetition, TCompetition.GetType().GetProperty("TextResult").GetValue(TCompetition) + ($"第{i}局\n"));
                }
                TCompetition.GetType().GetMethod("TaskFunction").Invoke(TCompetition, null);
                if (TCompetition.GetType().GetProperty("Winner").GetValue(TCompetition) == A)
                {
                    AW++;
                }
                else if (TCompetition.GetType().GetProperty("Winner").GetValue(TCompetition) == B)
                {
                    BW++;
                }
                if (i == Round)
                {
                    if (PrintSetting.FileOrNot == true)
                    {
                        new FilePrint($"{AW} {BW}\n").PrintMethod();
                    }
                    break;
                }
                A.Refresh();
                B.Refresh();
                TCompetition.GetType().GetMethod("Refresh").Invoke(TCompetition, null);
            }
            if (PrintSetting.ScreenOrNot == true)
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