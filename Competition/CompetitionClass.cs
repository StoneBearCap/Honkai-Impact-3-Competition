using Competition.BaseClass;
using PrintLibrary;
using System;

namespace Competition.Runtime
{
    public class Competition<TLeft, TRight>
        where TLeft : Competitor
        where TRight : Competitor
    {
        //概率匿名委托
        readonly Func<int, bool> ProbabilityFunction = (int ProbabilityValue) =>
            new Random().Next(1, 100) <= ProbabilityValue;
        public TLeft Left { get; }
        public TRight Right { get; }
        public Competitor Winner { get; private set; }
        public int Count { get; private set; }
        public string TextResult { get; private set; }

        public Competition(TLeft left, TRight right)
        {
            Left = left;
            Right = right;
            Refresh();
        }
        public void Refresh()
        {
            Winner = default;
            Count = 0;
            TextResult = null;
        }
        //攻击前阶段
        private void PreparatoryPhase(Competitor Character)
        {
            Competitor Another(Competitor character)
            {
                if (((Competitor)Left) == character)
                {
                    return (Competitor)Right;
                }
                else
                {
                    return (Competitor)Left;
                }
            }
            if (Character.GetName() == "Kiana")
            {
                //琪亚娜无攻击前阶段
                return;
            }
            else if (Character.GetName() == "RaidenMei")
            {
                //芽衣无攻击前阶段
                return;
            }
            else if (Character.GetName() == "RitaRossweisse")
            {
                //丽塔无攻击前阶段
                return;
            }
            else if (Character.GetName() == "TheresaApocalypse")
            {
                //德莉莎无攻击前阶段
                return;
            }
            else if (Character.GetName() == "CorvusCorax")
            {
                if (Count == 1)
                {
                    TextResult += Character.EffectedByCorvusCorax_ToDefender(Another(Character));
                }
                else
                {
                    //渡鸦除了第一回合外无攻击前阶段
                    return;
                }
            }
            else if (Character.GetName() == "Bronya")
            {
                //布洛妮娅无攻击前阶段
                return;
            }
            else if (Character.GetName() == "KallenAndSakura")
            {
                TextResult += Character.EffectedBySakura();
            }
            else if (Character.GetName() == "SeeleVollerei")
            {
                TextResult += Character.EffectedBySeeleVollerei();
            }
            else if (Character.GetName() == "FuHua")
            {
                //符华无攻击前阶段
                return;
            }
            else if (Character.GetName() == "Himeko")
            {
                if (Count == 1)
                {
                    TextResult += Character.EffectedByHimeko_Love(Another(Character));
                }
                else
                {
                    if (Count % 2 == 0)
                    {
                        TextResult += Character.EffectedByHimeko_Alcohol();
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
            Competitor Another(Competitor character)
            {
                if (((Competitor)Left) == character)
                {
                    return (Competitor)Right;
                }
                else
                {
                    return (Competitor)Left;
                }
            }
            Competitor Defender = Another(Character);
            if (Character.GetName() == "Kiana")
            {
                if (Count % 2 == 0)
                {
                    if (HasSkills)
                    {
                        TextResult += Defender.EffectedByKiana_Spear(Character);
                    }
                }
                else
                {
                    TextResult += Defender.GetAttacked(Character);
                }
            }
            else if (Character.GetName() == "RaidenMei")
            {
                if (Count % 2 == 0)
                {
                    if (HasSkills)
                    {
                        TextResult += Defender.EffectedByRaidenMei_Dragon(Character);
                        TextResult += Defender.EffectedByRaidenMei_Singer(Character);
                    }
                }
                else
                {
                    TextResult += (Defender.GetAttacked(Character));
                    if (HasSkills)
                    {
                        TextResult += Defender.EffectedByRaidenMei_Singer(Character);
                    }
                }
            }
            else if (Character.GetName() == "RitaRossweisse")
            {

                if (Count % 4 == 0)
                {
                    if (HasSkills)
                    {
                        TextResult += Defender.EffectedByRitaRossweisse_Mind(Character);
                    }
                }
                else
                {
                    TextResult += Defender.GetAttacked(Character);
                    if (HasSkills)
                    {
                        if (ProbabilityFunction(35))
                        {
                            TextResult += Defender.EffectedByRitaRossweisse_Clear(Character);
                        }
                    }
                }
            }
            else if (Character.GetName() == "TheresaApocalypse")
            {
                if (Count % 3 == 0)
                {
                    if (HasSkills)
                    {
                        TextResult += Defender.EffectedByTheresaApocalypse_Kick(Character);
                    }
                }
                else
                {
                    TextResult += Defender.GetAttacked(Character);
                }
            }
            else if (Character.GetName() == "CorvusCorax")
            {
                if (Count % 3 == 0)
                {
                    if (HasSkills)
                    {
                        TextResult += Defender.EffectedByCorvusCorax_Island(Character);
                    }
                }
                else
                {
                    TextResult += Defender.GetAttacked(Character);
                }
            }
            else if (Character.GetName() == "Bronya")
            {
                if (Count % 3 == 0)
                {
                    if (HasSkills)
                    {
                        TextResult += Defender.EffectedByBronya_Mortar(Character);
                    }
                }
                else
                {
                    TextResult += Defender.GetAttacked(Character);
                }
            }
            else if (Character.GetName() == "KallenAndSakura")
            {
                if (Count % 2 == 0)
                {
                    if (HasSkills)
                    {
                        TextResult += Defender.EffectedByKallen(Character);
                    }
                }
                else
                {
                    TextResult += Defender.GetAttacked(Character);
                }
            }
            else if (Character.GetName() == "SeeleVollerei")
            {
                TextResult += Defender.GetAttacked(Character);
            }
            else if (Character.GetName() == "FuHua")
            {
                if (Count % 3 == 0)
                {
                    if (HasSkills)
                    {
                        TextResult += Defender.EffectedByFuHua(Character);
                    }
                }
                else
                {
                    TextResult += Defender.GetAttacked(Character);
                }
            }
            else if (Character.GetName() == "Himeko")
            {
                TextResult += Defender.GetAttacked(Character);
            }
        }
        //攻击后阶段
        private void EndPhase(Competitor Character)
        {
            Competitor Another(Competitor character)
            {
                if (((Competitor)Left) == character)
                {
                    return (Competitor)Right;
                }
                else
                {
                    return (Competitor)Left;
                }
            }
            if (Character.GetName() == "Kiana")
            {
                if (Count % 2 == 0)
                {
                    TextResult += Character.EffectedByKiana_Voice();
                }
                return;
            }
            else if (Character.GetName() == "RaidenMei")
            {
                //芽衣无攻击后阶段
                return;
            }
            else if (Character.GetName() == "RitaRossweisse")
            {
                //丽塔无攻击后阶段
                return;
            }
            else if (Character.GetName() == "TheresaApocalypse")
            {
                TextResult += Another(Character).EffectedByTheresaApocalypse_Judas(Character);
            }
            else if (Character.GetName() == "CorvusCorax")
            {
                //渡鸦无攻击后阶段
                return;
            }
            else if (Character.GetName() == "Bronya")
            {
                TextResult += Another(Character).EffectedByBronya_Cyberangel(Character);
            }
            else if (Character.GetName() == "KallenAndSakura")
            {
                //卡莲&八重樱无攻击后阶段
                return;
            }
            else if (Character.GetName() == "SeeleVollerei")
            {
                //希儿无攻击后阶段
                return;
            }
            else if (Character.GetName() == "FuHua")
            {
                //符华无攻击后阶段
                return;
            }
            else if (Character.GetName() == "Himeko")
            {
                //姬子无攻击后阶段
                return;
            }
        }
        private void Action(Competitor Character)
        {
            Competitor Another(Competitor character)
            {
                if (((Competitor)Left) == character)
                {
                    return (Competitor)Right;
                }
                else
                {
                    return (Competitor)Left;
                }
            }
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
            bool HasSkills = Character.IsCharmed != true;
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
                TextResult += $"{Character.GetName()}跳过攻击前阶段\n";
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
                TextResult += $"{ Character.GetName()}跳过攻击后阶段\n";
            }
            if (Character.CharmedTime == 0)
            {
                Character.GetType().GetProperty("IsCharmed").SetValue(Character, false);
            }
        }
        public void TaskFunction()
        {
            Competitor Another(Competitor character)
            {
                if (((Competitor)Left) == character)
                {
                    return (Competitor)Right;
                }
                else
                {
                    return (Competitor)Left;
                }
            }
            Competitor CurrnetCharacter = Left.Speed >= Right.Speed ? (Competitor)Left : Right;
            while (true)
            {
                Count++;
                TextResult += $"第{Count}回合\n";
                Action(CurrnetCharacter);
                if (Another(CurrnetCharacter).Health == 0)
                {
                    Winner = CurrnetCharacter;
                    TextResult += $"{CurrnetCharacter.GetName()}胜利，剩下{CurrnetCharacter.Health}点生命\n" + "\n";
                    break;
                }
                CurrnetCharacter = Another(CurrnetCharacter);
                Action(CurrnetCharacter);
                if (Another(CurrnetCharacter).Health == 0)
                {
                    Winner = CurrnetCharacter;
                    TextResult += $"{CurrnetCharacter.GetName()}胜利，剩下{CurrnetCharacter.Health}点生命\n" + "\n";
                    break;
                }
                CurrnetCharacter = Another(CurrnetCharacter);
                TextResult += ("\n");
            }
            if (PrintSetting.ScreenOrNot == true)
            {
                new ScreenPrint(TextResult).PrintMethod();
            }
            if (PrintSetting.FileOrNot == true)
            {
                new FilePrint(TextResult).PrintMethod();
            }
        }
    }
}