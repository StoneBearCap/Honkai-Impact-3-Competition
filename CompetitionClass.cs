using System;
using BaseClass;

namespace CompetitionClass
{
    class Competition<TLeft, TRight>
        where TLeft : Competitor, ICompetitor
        where TRight : Competitor, ICompetitor
    {
        Func<int, bool> ProbabilityFunction = (int ProbabilityValue) =>
        {
            Random RandomSeed = new Random();
            int RandomResult = RandomSeed.Next(1, 100);
            if(RandomResult <= ProbabilityValue)
            {
                return true;
            }
            return false;
        };
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

        //����ǰ�׶�
        private void PreparatoryPhase(Competitor Character)
        {
            Func<Competitor, Competitor> Another = (Competitor Character) =>
            {
                if(( (Competitor) Left ) == Character)
                {
                    return (Competitor) Right;
                }
                else
                {
                    return (Competitor) Left;
                }
            };
            if(( (ICompetitor) Character ).GetName() == "Kiana")
            {
                //�������޹���ǰ�׶�
                return;
            }
            else if(( (ICompetitor) Character ).GetName() == "RaidenMei")
            {
                //ѿ���޹���ǰ�׶�
                return;
            }
            else if(( (ICompetitor) Character ).GetName() == "RitaRossweisse")
            {
                //�����޹���ǰ�׶�
                return;
            }
            else if(( (ICompetitor) Character ).GetName() == "TheresaApocalypse")
            {
                //����ɯ�޹���ǰ�׶�
                return;
            }
            else if(( (ICompetitor) Character ).GetName() == "CorvusCorax")
            {
                if(Count == 1)
                {
                    Character.EffectedByCorvusCorax_ToDefender(Another(Character));
                }
                else
                {
                    //��ѻ���˵�һ�غ����޹���ǰ�׶�
                    return;
                }
            }
            else if(( (ICompetitor) Character ).GetName() == "Bronya")
            {
                //��������޹���ǰ�׶�
                return;
            }
            else if(( (ICompetitor) Character ).GetName() == "KallenAndSakura")
            {
                Character.EffectedBySakura();
            }
            else if(( (ICompetitor) Character ).GetName() == "SeeleVollerei")
            {
                Character.EffectedBySeeleVollerei();
            }
            else if(( (ICompetitor) Character ).GetName() == "FuHua")
            {
                //�����޹���ǰ�׶�
                return;
            }
            else if(( (ICompetitor) Character ).GetName() == "Himeko")
            {
                if(Count == 1)
                {
                    Character.EffectedByHimeko_Love(Another(Character));
                }
                else
                {
                    if(Count % 2 == 0)
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
        //�����׶�
        private void AttackingPhase(Competitor Character, bool HasSkills = true)
        {
            Func<Competitor, Competitor> Another = (Competitor Character) =>
            {
                if(( (Competitor) Left ) == Character)
                {
                    return (Competitor) Right;
                }
                else
                {
                    return (Competitor) Left;
                }
            };
            Competitor Defender = Another(Character);
            if(( (ICompetitor) Character ).GetName() == "Kiana")
            {
                if(Count % 2 == 0)
                {
                    if(HasSkills)
                    {
                        Defender.EffectedByKiana_Spear(Character);
                    }
                }
                else
                {
                    Defender.GetAttacked(Character);
                }
            }
            else if(( (ICompetitor) Character ).GetName() == "RaidenMei")
            {
                if(Count % 2 == 0)
                {
                    if(HasSkills)
                    {
                        Defender.EffectedByRaidenMei_Dragon(Character);
                        Defender.EffectedByRaidenMei_Singer(Character);
                    }
                }
                else
                {
                    Defender.GetAttacked(Character);
                    if(HasSkills)
                    {
                        Defender.EffectedByRaidenMei_Singer(Character);
                    }
                }
            }
            else if(( (ICompetitor) Character ).GetName() == "RitaRossweisse")
            {

                if(Count % 4 == 0)
                {
                    if(HasSkills)
                    {
                        Defender.EffectedByRitaRossweisse_Mind(Character);
                    }
                }
                else
                {
                    Defender.GetAttacked(Character);
                    if(HasSkills)
                    {
                        if(ProbabilityFunction(35))
                        {
                            Defender.EffectedByRitaRossweisse_Clear(Character);
                        }
                    }
                }
            }
            else if(( (ICompetitor) Character ).GetName() == "TheresaApocalypse")
            {
                if(Count % 3 == 0)
                {
                    if(HasSkills)
                    {
                        Defender.EffectedByTheresaApocalypse_Kick(Character);
                    }
                }
                else
                {
                    Defender.GetAttacked(Character);
                }
            }
            else if(( (ICompetitor) Character ).GetName() == "CorvusCorax")
            {
                if(Count % 3 == 0)
                {
                    if(HasSkills)
                    {
                        Defender.EffectedByCorvusCorax_Island(Character);
                    }
                }
                else
                {
                    Defender.GetAttacked(Character);
                }
            }
            else if(( (ICompetitor) Character ).GetName() == "Bronya")
            {
                if(Count % 3 == 0)
                {
                    if(HasSkills)
                    {
                        Defender.EffectedByBronya_Mortar(Character);
                    }
                }
                else
                {
                    Defender.GetAttacked(Character);
                }
            }
            else if(( (ICompetitor) Character ).GetName() == "KallenAndSakura")
            {
                if(Count % 2 == 0)
                {
                    if(HasSkills)
                    {
                        Defender.EffectedByKallen(Character);
                    }
                }
                else
                {
                    Defender.GetAttacked(Character);
                }
            }
            else if(((ICompetitor)Character).GetName()== "SeeleVollerei")
            {
                Defender.GetAttacked(Character);
            }
            else if(( (ICompetitor) Character ).GetName() == "FuHua")
            {
                if(Count % 3 == 0)
                {
                    if(HasSkills)
                    {
                        Defender.EffectedByFuHua(Character);
                    }
                }
                else
                {
                    Defender.GetAttacked(Character);
                }
            }
            else if(( (ICompetitor) Character ).GetName() == "Himeko")
            {
                Defender.GetAttacked(Character);
            }
        }
        //������׶�
        private void EndPhase(Competitor Character)
        {
            Func<Competitor, Competitor> Another = (Competitor Character) =>
            {
                if(( (Competitor) Left ) == Character)
                {
                    return (Competitor) Right;
                }
                else
                {
                    return (Competitor) Left;
                }
            };
            if(( (ICompetitor) Character ).GetName() == "Kiana")
            {
                //�������޹�����׶�
                return;
            }
            else if(( (ICompetitor) Character ).GetName() == "RaidenMei")
            {
                //ѿ���޹�����׶�
                return;
            }
            else if(( (ICompetitor) Character ).GetName() == "RitaRossweisse")
            {
                //�����޹�����׶�
                return;
            }
            else if(( (ICompetitor) Character ).GetName() == "TheresaApocalypse")
            {
                Another(Character).EffectedByTheresaApocalypse_Judas(Character);
            }
            else if(( (ICompetitor) Character ).GetName() == "CorvusCorax")
            {
                //��ѻ�޹�����׶�
                return;
            }
            else if(( (ICompetitor) Character ).GetName() == "Bronya")
            {
                Another(Character).EffectedByBronya_Cyberangel(Character);
            }
            else if(( (ICompetitor) Character ).GetName() == "KallenAndSakura")
            {
                //����&����ӣ�޹�����׶�
                return;
            }
            else if(((ICompetitor)Character).GetName()== "SeeleVollerei")
            {
                //ϣ���޹�����׶�
                return;
            }
            else if(( (ICompetitor) Character ).GetName() == "FuHua")
            {
                //�����޹�����׶�
                return;
            }
            else if(( (ICompetitor) Character ).GetName() == "Himeko")
            {
                //�����޹�����׶�
                return;
            }
        }
        private void Action(Competitor Character)
        {
            Func<Competitor, Competitor> Another = (Competitor Character) =>
            {
                if(( (Competitor) Left ) == Character)
                {
                    return (Competitor) Right;
                }
                else
                {
                    return (Competitor) Left;
                }
            };
            bool Return = false;
            if(Character.IsVertigo == true)
            {
                Character.ResetVertigo();
                Return = true;
            } 
            if(Character.IsParalysis == true)
            {
                Character.ResetParalysis();
                Return = true;
            }
            if(Return == true)
            {
                return;
            }
            bool HasSkills = Character.IsCharmed == true ? false : true;
            if(Character.IsCharmed == true)
            {
                Character.CharmedTime--;
            }
            if(HasSkills)
            {
                PreparatoryPhase(Character);
            }
            else
            {
                Console.WriteLine($"{( (ICompetitor) Character ).GetName()}��������ǰ�׶�");
            }
            AttackingPhase(Character, HasSkills);
            if(Another(Character).Health == 0)
            {
                return;
            }
            if(HasSkills)
            {
                EndPhase(Character);
            }
            else
            {
                Console.WriteLine($"{( (ICompetitor) Character ).GetName()}����������׶�");
            }
            if(Character.CharmedTime == 0)
            {
                Character.ClearChramed();
            }
        }
        public void TaskFunction()
        {
            Func<Competitor, Competitor> Another = (Competitor Character) =>
            {
                if(( (Competitor) Left ) == Character)
                {
                    return (Competitor) Right;
                }
                else
                {
                    return (Competitor) Left;
                }
            };
            Competitor CurrnetCharacter = Left.Speed >= Right.Speed ? (Competitor) Left : Right;
            while(true)
            {
                Count++;
                Console.WriteLine($"��{Count}�غ�");
                Action(CurrnetCharacter);
                if(Another(CurrnetCharacter).Health == 0)
                {
                    Winner = CurrnetCharacter;
                    Console.WriteLine($"{( (ICompetitor) CurrnetCharacter ).GetName()}ʤ����ʣ��{CurrnetCharacter.Health}������");
                    break;
                }
                CurrnetCharacter = Another(CurrnetCharacter);
                Action(CurrnetCharacter);
                if(Another(CurrnetCharacter).Health == 0)
                {
                    Winner = CurrnetCharacter;
                    Console.WriteLine($"{( (ICompetitor) CurrnetCharacter ).GetName()}ʤ����ʣ��{CurrnetCharacter.Health}������");
                    break;
                }
                CurrnetCharacter = Another(CurrnetCharacter);
                Console.WriteLine();
            }
        }
    }
}