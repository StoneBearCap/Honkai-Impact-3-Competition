using System;
using BaseClass;
using System.Reflection;

namespace CompetitionClass
{
    class Competition<TLeft, TRight>
        where TLeft : Competitor, ICompetitor
        where TRight : Competitor, ICompetitor
    {
        //概率匿名委托
        Func<int, bool> ProbabilityFunction = (int ProbabilityValue) =>
            new Random().Next(1, 100) <= ProbabilityValue ? true : false;
        public TLeft Left { get; }
        public TRight Right { get; }
        public Competitor Winner { get; private set; } = default;
        public int Count { get; private set; }


        public Competition(TLeft left, TRight right)
        {
            Left = left;
            Right = right;
            Count = 0;
        }

        //攻击前阶段
        private void PreparatoryPhase(Competitor Character)
        {
            Func<Competitor, Competitor> Another = (Competitor character) =>
            {
                if (((Competitor)Left) == character)
                {
                    return (Competitor)Right;
                }
                else
                {
                    return (Competitor)Left;
                }
            };
            if (((ICompetitor)Character).GetName() == "Kiana")
            {
                //琪亚娜无攻击前阶段
                return;
            }
            else if (((ICompetitor)Character).GetName() == "RaidenMei")
            {
                //芽衣无攻击前阶段
                return;
            }
            else if (((ICompetitor)Character).GetName() == "RitaRossweisse")
            {
                //丽塔无攻击前阶段
                return;
            }
            else if (((ICompetitor)Character).GetName() == "TheresaApocalypse")
            {
                //德莉莎无攻击前阶段
                return;
            }
            else if (((ICompetitor)Character).GetName() == "CorvusCorax")
            {
                if (Count == 1)
                {
                    Character.EffectedByCorvusCorax_ToDefender(Another(Character));
                }
                else
                {
                    //渡鸦除了第一回合外无攻击前阶段
                    return;
                }
            }
            else if (((ICompetitor)Character).GetName() == "Bronya")
            {
                //布洛妮娅无攻击前阶段
                return;
            }
            else if (((ICompetitor)Character).GetName() == "KallenAndSakura")
            {
                Character.EffectedBySakura();
            }
            else if (((ICompetitor)Character).GetName() == "SeeleVollerei")
            {
                Character.EffectedBySeeleVollerei();
            }
            else if (((ICompetitor)Character).GetName() == "FuHua")
            {
                //符华无攻击前阶段
                return;
            }
            else if (((ICompetitor)Character).GetName() == "Himeko")
            {
                if (Count == 1)
                {
                    Character.EffectedByHimeko_Love(Another(Character));
                }
                else
                {
                    if (Count % 2 == 0)
                    {
                        Character.EffectedByHimeko_Alcohol();
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
        //攻击阶段
        private void AttackingPhase(Competitor Character, bool HasSkills = true)
        {
            Func<Competitor, Competitor> Another = (Competitor character) =>
            {
                if (((Competitor)Left) == character)
                {
                    return (Competitor)Right;
                }
                else
                {
                    return (Competitor)Left;
                }
            };
            Competitor Defender = Another(Character);
            if (((ICompetitor)Character).GetName() == "Kiana")
            {
                if (Count % 2 == 0)
                {
                    if (HasSkills)
                    {
                        Defender.EffectedByKiana_Spear(Character);
                    }
                }
                else
                {
                    Defender.GetAttacked(Character);
                }
            }
            else if (((ICompetitor)Character).GetName() == "RaidenMei")
            {
                if (Count % 2 == 0)
                {
                    if (HasSkills)
                    {
                        Defender.EffectedByRaidenMei_Dragon(Character);
                        Defender.EffectedByRaidenMei_Singer(Character);
                    }
                }
                else
                {
                    Defender.GetAttacked(Character);
                    if (HasSkills)
                    {
                        Defender.EffectedByRaidenMei_Singer(Character);
                    }
                }
            }
            else if (((ICompetitor)Character).GetName() == "RitaRossweisse")
            {

                if (Count % 4 == 0)
                {
                    if (HasSkills)
                    {
                        Defender.EffectedByRitaRossweisse_Mind(Character);
                    }
                }
                else
                {
                    Defender.GetAttacked(Character);
                    if (HasSkills)
                    {
                        if (ProbabilityFunction(35))
                        {
                            Defender.EffectedByRitaRossweisse_Clear(Character);
                        }
                    }
                }
            }
            else if (((ICompetitor)Character).GetName() == "TheresaApocalypse")
            {
                if (Count % 3 == 0)
                {
                    if (HasSkills)
                    {
                        Defender.EffectedByTheresaApocalypse_Kick(Character);
                    }
                }
                else
                {
                    Defender.GetAttacked(Character);
                }
            }
            else if (((ICompetitor)Character).GetName() == "CorvusCorax")
            {
                if (Count % 3 == 0)
                {
                    if (HasSkills)
                    {
                        Defender.EffectedByCorvusCorax_Island(Character);
                    }
                }
                else
                {
                    Defender.GetAttacked(Character);
                }
            }
            else if (((ICompetitor)Character).GetName() == "Bronya")
            {
                if (Count % 3 == 0)
                {
                    if (HasSkills)
                    {
                        Defender.EffectedByBronya_Mortar(Character);
                    }
                }
                else
                {
                    Defender.GetAttacked(Character);
                }
            }
            else if (((ICompetitor)Character).GetName() == "KallenAndSakura")
            {
                if (Count % 2 == 0)
                {
                    if (HasSkills)
                    {
                        Defender.EffectedByKallen(Character);
                    }
                }
                else
                {
                    Defender.GetAttacked(Character);
                }
            }
            else if (((ICompetitor)Character).GetName() == "SeeleVollerei")
            {
                Defender.GetAttacked(Character);
            }
            else if (((ICompetitor)Character).GetName() == "FuHua")
            {
                if (Count % 3 == 0)
                {
                    if (HasSkills)
                    {
                        Defender.EffectedByFuHua(Character);
                    }
                }
                else
                {
                    Defender.GetAttacked(Character);
                }
            }
            else if (((ICompetitor)Character).GetName() == "Himeko")
            {
                Defender.GetAttacked(Character);
            }
        }
        //攻击后阶段
        private void EndPhase(Competitor Character)
        {
            Func<Competitor, Competitor> Another = (Competitor character) =>
            {
                if (((Competitor)Left) == character)
                {
                    return (Competitor)Right;
                }
                else
                {
                    return (Competitor)Left;
                }
            };
            if (((ICompetitor)Character).GetName() == "Kiana")
            {
                //琪亚娜无攻击后阶段
                return;
            }
            else if (((ICompetitor)Character).GetName() == "RaidenMei")
            {
                //芽衣无攻击后阶段
                return;
            }
            else if (((ICompetitor)Character).GetName() == "RitaRossweisse")
            {
                //丽塔无攻击后阶段
                return;
            }
            else if (((ICompetitor)Character).GetName() == "TheresaApocalypse")
            {
                Another(Character).EffectedByTheresaApocalypse_Judas(Character);
            }
            else if (((ICompetitor)Character).GetName() == "CorvusCorax")
            {
                //渡鸦无攻击后阶段
                return;
            }
            else if (((ICompetitor)Character).GetName() == "Bronya")
            {
                Another(Character).EffectedByBronya_Cyberangel(Character);
            }
            else if (((ICompetitor)Character).GetName() == "KallenAndSakura")
            {
                //卡莲&八重樱无攻击后阶段
                return;
            }
            else if (((ICompetitor)Character).GetName() == "SeeleVollerei")
            {
                //希儿无攻击后阶段
                return;
            }
            else if (((ICompetitor)Character).GetName() == "FuHua")
            {
                //符华无攻击后阶段
                return;
            }
            else if (((ICompetitor)Character).GetName() == "Himeko")
            {
                //姬子无攻击后阶段
                return;
            }
        }
        private void Action(Competitor Character)
        {
            Func<Competitor, Competitor> Another = (Competitor character) =>
            {
                if (((Competitor)Left) == character)
                {
                    return (Competitor)Right;
                }
                else
                {
                    return (Competitor)Left;
                }
            };
            bool Return = false;
            if (Character.IsVertigo == true)
            {
                Character.GetType().GetProperty("IsVertigo").SetValue(Character, false);
                Return = true;
            }
            if (Character.IsParalysis == true)
            {
                Character.GetType().GetProperty("IsParalysis").SetValue(Character, false);
                Return = true;
            }
            if (Return == true)
            {
                return;
            }
            bool HasSkills = Character.IsCharmed == true ? false : true;
            if (Character.IsCharmed == true)
            {
                Character.GetType().GetProperty("CharmedTime").SetValue(Character, ((dynamic)Character.GetType().GetProperty("CharmedTime").GetValue(Character)) - 1);
            }
            if (HasSkills)
            {
                PreparatoryPhase(Character);
            }
            else
            {
                Console.WriteLine($"{((ICompetitor)Character).GetName()}跳过攻击前阶段");
            }
            AttackingPhase(Character, HasSkills);
            if (Another(Character).Health == 0)
            {
                return;
            }
            if (HasSkills)
            {
                EndPhase(Character);
            }
            else
            {
                Console.WriteLine($"{((ICompetitor)Character).GetName()}跳过攻击后阶段");
            }
            if (Character.CharmedTime == 0)
            {
                Character.GetType().GetProperty("IsCharmed").SetValue(Character, false);
            }
        }
        public void TaskFunction()
        {
            Func<Competitor, Competitor> Another = (Competitor character) =>
            {
                if (((Competitor)Left) == character)
                {
                    return (Competitor)Right;
                }
                else
                {
                    return (Competitor)Left;
                }
            };
            Competitor CurrnetCharacter = Left.Speed >= Right.Speed ? (Competitor)Left : Right;
            while (true)
            {
                Count++;
                Console.WriteLine($"第{Count}回合");
                Action(CurrnetCharacter);
                if (Another(CurrnetCharacter).Health == 0)
                {
                    Winner = CurrnetCharacter;
                    Console.WriteLine($"{((ICompetitor)CurrnetCharacter).GetName()}胜利，剩下{CurrnetCharacter.Health}点生命");
                    break;
                }
                CurrnetCharacter = Another(CurrnetCharacter);
                Action(CurrnetCharacter);
                if (Another(CurrnetCharacter).Health == 0)
                {
                    Winner = CurrnetCharacter;
                    Console.WriteLine($"{((ICompetitor)CurrnetCharacter).GetName()}胜利，剩下{CurrnetCharacter.Health}点生命");
                    break;
                }
                CurrnetCharacter = Another(CurrnetCharacter);
                Console.WriteLine();
                //Console.WriteLine(Left.ToString());
                //Console.WriteLine(Right.ToString());
            }
        }
    }
}