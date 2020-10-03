using CustomException;
using System;
using System.Text;

namespace Competition.BaseClass
{
    public class Competitor : ICompetitor
    {
        //概率匿名委托
        readonly Func<int, bool> ProbabilityFunction = (int ProbabilityValue) =>
            new Random().Next(1, 100) <= ProbabilityValue;
        public int Health { get; protected set; }
        public int Attack { get; protected set; }
        public int Defense { get; protected set; }
        public int Speed { get; protected set; }
        //是否是物理攻击，符华为元素
        public bool IsPhysical { get; protected set; }
        //命中率,100为初始值，即100%
        public int HitRate { get; protected set; }
        //是否被麻痹（芽衣攻击概率麻痹）
        public bool IsParalysis { get; protected set; }
        //全伤害比例,100为初始值，即100%
        public int AttackPercentage { get; protected set; }
        //琪亚娜是否被技能负面影响眩晕
        public bool IsVertigo { get; protected set; }
        //是否被丽塔技能魅惑(若是，则无法使用技能且全伤害永久下降60%持续两回合)
        public bool IsCharmed { get; protected set; }
        //是否曾经被丽塔技能魅惑
        public bool HasBeenCharmed { get; protected set; }
        //魅惑待生效次数
        public int CharmedTime { get; protected set; }
        //丽塔1技能：女仆的温柔清理，对敌人
        //被影响效果，永久降低攻击力4点
        public string EffectedByRitaRossweisse_Clear(Competitor User)
        {
            try
            {
                if (User.GetName() != "RitaRossweisse")
                {
                    throw new UserMismatchingException(User);
                }
                int PreviousAttack = Attack;
                if (Attack > 4)
                {
                    Attack -= 4;
                }
                else
                {
                    Attack = 0;
                }
                Health += 3;
                return ($"{User.GetName()}发动技能女仆的温柔清理，降低{this.GetName()}{PreviousAttack - Attack}点攻击力\n");
            }
            catch (UserMismatchingException)
            {
                return null;
            }
        }
        //丽塔2技能：完美心意，对敌人
        //效果，进入魅惑状态2回合
        public string EffectedByRitaRossweisse_Mind(Competitor User)
        {
            try
            {
                if (User.GetName() != "RitaRossweisse")
                {
                    throw new UserMismatchingException(User);
                }
                IsCharmed = true;
                CharmedTime = 2;
                if (HasBeenCharmed == false)
                {
                    AttackPercentage = AttackPercentage * 40 / 100;
                }
                HasBeenCharmed = true;
                return ($"{User.GetName()}对{this.GetName()}使用魅惑技能，使其进入魅惑状态两回合（期间不能使用技能），永久降低60%伤害\n");
            }
            catch (UserMismatchingException)
            {
                return null;
            }
        }
        //符华技能：形之笔墨，对敌人
        //每三个回合发动一次，造成18点元素伤害，降低对手25%命中率，可叠加
        public string EffectedByFuHua(Competitor User)
        {
            try
            {
                if (User.GetName() != "FuHua")
                {
                    throw new UserMismatchingException(User);
                }
                if (ProbabilityFunction(User.HitRate))
                {
                    int AttackValue = 18 * User.AttackPercentage / 100;
                    int PreviousHealth = Health;
                    int PreviousHitRate = HitRate;
                    if (Health >= AttackValue)
                    {
                        Health -= AttackValue;
                    }
                    else
                    {
                        Health = 0;
                    }
                    if (HitRate >= 25)
                    {
                        HitRate -= 25;
                    }
                    else
                    {
                        HitRate = 0;
                    }
                    return ($"{User.GetName()}发动技能形之笔墨，对{this.GetName()}造成{PreviousHealth - Health}点伤害，降低{PreviousHitRate - HitRate}%命中率\n");

                }
                else
                {
                    return ($"{User.GetName()}发动技能形之笔墨未命中\n");
                }
            }
            catch (UserMismatchingException)
            {
                return null;
            }
        }
        //德莉莎1技能：血犹大第一可爱，对敌人
        //效果，攻击后30%概率降低5点防御
        public string EffectedByTheresaApocalypse_Judas(Competitor User)
        {
            try
            {
                if (User.GetName() != "TheresaApocalypse")
                {
                    throw new UserMismatchingException(User);
                }
                if (ProbabilityFunction(30))
                {
                    int PreviousDefense = Defense;
                    if (Defense > 5)
                    {
                        Defense -= 5;
                    }
                    else
                    {
                        Defense = 0;
                    }
                    return ($"{User.GetName()}发动技能血犹大第一可爱，降低{this.GetName()}{PreviousDefense - Defense}点防御\n");
                }
                else
                {
                    return null;
                }
            }
            catch (UserMismatchingException)
            {
                return null;
            }
        }
        //德莉莎2技能：在线踢人,对敌人
        //效果，造成5*16伤害
        public string EffectedByTheresaApocalypse_Kick(Competitor User)
        {
            try
            {
                if (User.GetName() != "TheresaApocalypse")
                {
                    throw new UserMismatchingException(User);
                }
                int PreviousHealth = Health;
                for (int i = 1; i <= 5; i++)
                {
                    if (ProbabilityFunction(User.HitRate))
                    {
                        int AttackValue = 16 - Defense;
                        AttackValue = AttackValue * User.AttackPercentage / 100;
                        if (Health > AttackValue)
                        {
                            Health -= AttackValue;
                        }
                        else
                        {
                            Health = 0;
                            break;
                        }
                    }
                    else
                    {

                    }
                }
                return ($"{User.GetName()}发动技能在线踢人，对{this.GetName()}造成{PreviousHealth - Health}点伤害\n");
            }
            catch (UserMismatchingException)
            {
                return null;
            }
        }
        //琪亚娜1技能：吃我一矛！，对敌人
        //效果，每两个回合发动，本次攻击的攻击力上升2倍对手防御值
        public string EffectedByKiana_Spear(Competitor User)
        {
            try
            {
                if (User.GetName() != "Kiana")
                {
                    throw new UserMismatchingException(User);
                }
                if (ProbabilityFunction(User.HitRate))
                {
                    int PreviousHealth = Health;
                    int AttackValue = User.Attack + Defense * 2 - Defense;
                    AttackValue = AttackValue * User.AttackPercentage / 100;
                    if (Health >= AttackValue)
                    {
                        Health -= AttackValue;
                    }
                    else
                    {
                        Health = 0;
                    }
                    return ($"{User.GetName()}发动技能吃我一矛！，对{this.GetName()}造成{PreviousHealth - Health}点伤害\n")
                    + ($"{this.GetName()}剩下{Health}点体力\n");
                }
                else
                {
                    return ($"{User.GetName()}发动技能吃我一矛！，未命中\n");
                }
            }
            catch (UserMismatchingException)
            {
                return null;
            }
        }
        //琪亚娜2技能：音浪~太强~，对自己，攻击后阶段
        //效果，使用吃我一矛！时35%概率眩晕自己一回合
        public string EffectedByKiana_Voice()
        {
            try
            {
                if (this.GetName() != "Kiana")
                {
                    throw new UserMismatchingException(this);
                }
                if (ProbabilityFunction(35))
                {
                    IsVertigo = true;
                    return ($"{this.GetName()}发动技能音浪~太强~，使自己眩晕一回合\n");
                }
                else
                {
                    return null;
                }
            }
            catch (UserMismatchingException)
            {
                return null;
            }
        }
        //芽衣1技能：崩坏世界的歌姬，对敌人
        //效果：攻击时有30%概率麻痹对方一回合
        public string EffectedByRaidenMei_Singer(Competitor User)
        {
            try
            {
                if (User.GetName() != "RaidenMei")
                {
                    throw new UserMismatchingException(User);
                }
                if (ProbabilityFunction(30))
                {
                    IsParalysis = true;
                    return ($"{User.GetName()}发动技能崩坏世界的歌姬，使{this.GetName()}麻痹一回合\n");
                }
                else
                {
                    return null;
                }
            }
            catch (UserMismatchingException)
            {
                return null;
            }
        }
        //芽衣2技能：雷电家的龙女仆，对敌人
        //效果：每两回合发动一次，造成5次3点无视防御的元素伤害（可触发崩坏世界的歌姬一次）
        public string EffectedByRaidenMei_Dragon(Competitor User)
        {
            try
            {
                if (User.GetName() != "RaidenMei")
                {
                    throw new UserMismatchingException(User);
                }
                int PreviousHealth = Health;
                for (int i = 1; i <= 5; i++)
                {
                    if (ProbabilityFunction(User.HitRate))
                    {
                        int AttackValue = 3 * User.AttackPercentage / 100;
                        if (Health >= AttackValue)
                        {
                            Health -= AttackValue;
                        }
                        else
                        {
                            Health = 0;
                            break;
                        }
                    }
                }
                return ($"{User.GetName()}发动技能雷电家的龙女仆，对{this.GetName()}造成{PreviousHealth - Health}点伤害\n")
                + ($"{this.GetName()}剩下{Health}点体力\n");
            }
            catch (UserMismatchingException)
            {
                return null;
            }
        }
        //渡鸦1技能：不是针对你，对自己
        //战斗开始时，对琪亚娜伤害提升25%，对其他人造成的伤害有25%概率提升25%
        public string EffectedByCorvusCorax_ToDefender(Competitor Defender)
        {
            try
            {
                if (this.GetName() != "CorvusCorax")
                {
                    throw new UserMismatchingException(this);
                }
                if (Defender.GetName() == "Kiana")
                {
                    AttackPercentage += 25;
                    return ($"{this.GetName()}发动技能不是针对你，提升自己对琪亚娜25%伤害\n");
                }
                else
                {
                    if (ProbabilityFunction(25))
                    {
                        AttackPercentage += 25;
                        return ($"{this.GetName()}发动技能不是针对你，提升自己25%伤害\n");
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (UserMismatchingException)
            {
                return null;
            }
        }
        //渡鸦2技能：别墅小岛，对敌人
        //每三个回合发动一次，给与对方7次16点伤害
        public string EffectedByCorvusCorax_Island(Competitor User)
        {
            try
            {
                if (User.GetName() != "CorvusCorax")
                {
                    throw new UserMismatchingException(User);
                }
                int PreviousHealth = Health;
                for (int i = 1; i <= 7; i++)
                {
                    if (ProbabilityFunction(User.HitRate))
                    {
                        int AttackValue = 16 - Defense;
                        AttackValue = AttackValue * User.AttackPercentage / 100;
                        if (Health > AttackValue)
                        {
                            Health -= AttackValue;
                        }
                        else
                        {
                            Health = 0;
                            break;
                        }
                    }
                    else
                    {

                    }
                }
                return ($"{User.GetName()}发动技能别墅小岛对{this.GetName()}造成{PreviousHealth - Health}点伤害\n")
                + ($"{this.GetName()}剩下{Health}点体力\n");
            }
            catch (UserMismatchingException)
            {
                return null;
            }
        }
        //布洛妮娅1技能：天使重构，对敌人
        //攻击后25%概率发射钻头，造成4次12点伤害
        public string EffectedByBronya_Cyberangel(Competitor User)
        {
            try
            {
                if (User.GetName() != "Bronya")
                {
                    throw new UserMismatchingException(User);
                }
                if (ProbabilityFunction(25))
                {
                    int PreviousHealth = Health;
                    for (int i = 1; i <= 4; i++)
                    {
                        if (ProbabilityFunction(User.HitRate))
                        {
                            int AttackValue = 12 - Defense;
                            AttackValue = AttackValue * User.AttackPercentage / 100;
                            if (Health >= AttackValue)
                            {
                                Health -= AttackValue;
                            }
                            else
                            {
                                Health = 0;
                                break;
                            }
                        }
                    }
                    return ($"{User.GetName()}发动技能天使重构，对{this.GetName()}造成{PreviousHealth - Health}点伤害\n")
                    + ($"{this.GetName()}剩下{Health}点体力\n");
                }
                else
                {
                    return null;
                }
            }
            catch (UserMismatchingException)
            {
                return null;
            }
        }
        //布洛妮娅2技能：摩托拜客哒！，对敌人
        //每三个回合发动一次，造成1~100点无视防御的元素伤害
        public string EffectedByBronya_Mortar(Competitor User)
        {
            try
            {
                if (User.GetName() != "Bronya")
                {
                    var b = new UserMismatchingException(User);
                }
                if (ProbabilityFunction(User.HitRate))
                {
                    int AttackValue = new Random().Next(1, 100);
                    AttackValue = AttackValue * User.AttackPercentage / 100;
                    int PreviousHealth = Health;
                    if (Health > AttackValue)
                    {
                        Health -= AttackValue;
                    }
                    else
                    {
                        Health = 0;
                    }
                    return ($"{User.GetName()}发动技能摩托拜客哒！，对{this.GetName()}造成{PreviousHealth - Health}点伤害\n");
                }
                else
                {
                    return ($"{User.GetName()}发动技能摩托拜客哒！未命中\n");
                }
            }
            catch (UserMismatchingException)
            {
                return null;
            }
        }
        //卡莲&八重樱1技能：八重樱的饭团，对自己
        //每个回合攻击前有30%概率回复25点生命
        public string EffectedBySakura()
        {
            try
            {
                if (this.GetName() != "KallenAndSakura")
                {
                    throw new UserMismatchingException(this);
                }
                if (ProbabilityFunction(30))
                {
                    int PreviousHealth = Health;
                    Health = (100 - Health) >= 25 ? Health + 25 : 100;
                    return ($"{this.GetName()}发动技能八重樱的饭团，回复自己{Health - PreviousHealth}点血量\n");
                }
                else
                {
                    return null;
                }
            }
            catch (UserMismatchingException)
            {
                return null;
            }
        }
        //卡莲&八重樱2技能：卡莲的饭团，对敌人
        //每两个回合发动一次，对敌人造成25点元素伤害
        public string EffectedByKallen(Competitor User)
        {
            try
            {
                if (User.GetName() != "KallenAndSakura")
                {
                    throw new UserMismatchingException(User);
                }
                if (ProbabilityFunction(User.HitRate))
                {
                    int PreviousHealth = Health;
                    int AttackValue = 25 * User.AttackPercentage / 100;
                    if (Health > AttackValue)
                    {
                        Health -= AttackValue;
                    }
                    else
                    {
                        Health = 0;
                    }
                    return ($"{User.GetName()}发动技能卡莲的饭团，对{this.GetName()}造成{PreviousHealth - Health}点伤害\n");
                }
                else
                {
                    return ($"{User.GetName()}发动技能卡莲的饭团，未命中\n");
                }
            }
            catch (UserMismatchingException)
            {
                return null;
            }
        }
        //希儿技能：我换我自己（拜托了，另一个我/去吧，希儿，去守护我们的约定）
        //每个回合攻击前阶段切换一次状态
        //黑希，攻击提高10点，防御降低5点
        //白希，切换时回复1~15点生命，攻击减少10点，防御增加5点
        public string EffectedBySeeleVollerei()
        {
            try
            {
                if (this.GetName() != "SeeleVollerei")
                {
                    throw new UserMismatchingException(this);
                }
                //黑变白
                if (((ISeeleVollerei)this).Color == ISeeleVollerei.SeeleVollereiColor.Black)
                {
                    int PreviousHealth = Health;
                    int PreviousAttack = Attack;
                    int PreviousDefense = Defense;
                    ((ISeeleVollerei)this).Color = ISeeleVollerei.SeeleVollereiColor.White;
                    int RandomResult = new Random().Next(1, 15);
                    Health = Health + RandomResult >= 100 ? 100 : Health + RandomResult;
                    Attack = Attack >= 10 ? Attack - 10 : 0;
                    Defense += 5;
                    return ($"{this.GetName()}发动技能我换我自己，“去吧，希儿，去守护我们的约定”，降低{PreviousAttack - Attack}点攻击，提升{Health - PreviousHealth}点生命，提升{Defense - PreviousDefense}点防御\n");
                }
                //白变黑
                else if (((ISeeleVollerei)this).Color == ISeeleVollerei.SeeleVollereiColor.White)
                {
                    int PreviousAttack = Attack;
                    int PreviousDefense = Defense;
                    ((ISeeleVollerei)this).Color = ISeeleVollerei.SeeleVollereiColor.Black;
                    Attack += 10;
                    Defense = Defense >= 5 ? Defense - 5 : 0;
                    return ($"{this.GetName()}发动技能我换我自己，“拜托了，另一个我”，提升{Attack - PreviousAttack}点攻击，降低{PreviousDefense - Defense}点防御\n");
                }
                else
                {
                    return null;
                }
            }
            catch (UserMismatchingException)
            {
                return null;
            }
        }
        //姬子1技能：真爱不死，对自己
        //对非单人队伍造成伤害提升100%
        public string EffectedByHimeko_Love(Competitor Defender)
        {
            try
            {
                if (this.GetName() != "Himeko")
                {
                    throw new UserMismatchingException(this);
                }
                if (Defender.GetName() == "KallenAndSakura")
                {
                    AttackPercentage += 100;
                    return ($"{this.GetName()}发动技能真爱不死，提升100%伤害\n");
                }
                else
                {
                    return null;
                }
            }
            catch (UserMismatchingException)
            {
                return null;
            }
        }
        //姬子2技能：干杯，朋友，对自己
        //每2回合发动一次，攻击前使自己攻击力翻倍，基础命中率降低35%，可叠加
        public string EffectedByHimeko_Alcohol()
        {
            try
            {
                if (this.GetName() != "Himeko")
                {
                    throw new UserMismatchingException(this);
                }
                int PreviousAttack = Attack;
                int PreviousHitRate = HitRate;
                Attack *= 2;
                HitRate = HitRate >= 35 ? HitRate - 35 : 0;
                return ($"{this.GetName()}发动技能干杯，朋友 提升{Attack - PreviousAttack}点攻击力，降低{PreviousHitRate - HitRate}%命中率\n");
            }
            catch (UserMismatchingException)
            {
                return null;
            }
        }

        //普通攻击
        public string GetAttacked(Competitor Attacker)
        {
            //普通攻击命中
            if (ProbabilityFunction(Attacker.HitRate))
            {
                int PreviousHealth = Health;
                string Result = null;
                //物理攻击
                if (Attacker.IsPhysical == true)
                {
                    int AttackValue = Attacker.Attack - Defense;
                    AttackValue = AttackValue * Attacker.AttackPercentage / 100;
                    if (AttackValue < 0)
                    {
                        Result += ($"{Attacker.GetName()}普通攻击未对{this.GetName()}造成伤害\n");
                    }
                    else
                    {
                        if (Health >= AttackValue)
                        {
                            Health -= AttackValue;
                        }
                        else
                        {
                            Health = 0;
                        }
                        Result += ($"{Attacker.GetName()}普通攻击对{this.GetName()}造成{PreviousHealth - Health}点伤害\n");
                    }
                }
                //元素攻击
                else
                {
                    int AttackValue = Attacker.Attack;
                    AttackValue = AttackValue * Attacker.AttackPercentage / 100;
                    if (Health >= AttackValue)
                    {
                        Health -= AttackValue;
                    }
                    else
                    {
                        Health = 0;
                    }
                    Result += ($"{Attacker.GetName()}普通攻击对{this.GetName()}造成{PreviousHealth - Health}点伤害\n");
                }
                Result += ($"{this.GetName()}剩下{Health}点生命值\n");
                return Result;
            }
            //普通攻击未命中
            else
            {
                return ($"{Attacker.GetName()}普通攻击未命中\n");
            }
        }
        public virtual string GetName()
        {
            return null;
        }
        public virtual void Refresh()
        {
            return;
        }
        //测试用方法，输出人物实时数据
        sealed public override string ToString()
        {
            var Result = new StringBuilder();
            Result.Append($"Name:{this.GetName()}\n");
            Result.Append($"Health:{Health}\n");
            Result.Append($"Attack:{Attack}\n");
            Result.Append($"Defense:{Defense}\n");
            Result.Append($"Speed:{Speed}\n");
            Result.Append($"HitRate:{HitRate}\n");
            Result.Append($"AttackPercentage:{AttackPercentage}\n");
            Result.Append($"IsVertigo:{IsVertigo}\n");
            Result.Append($"IsPhysical:{IsPhysical}\n");
            Result.Append($"IsParalysis:{IsParalysis}\n");
            Result.Append($"IsCharmed:{IsCharmed}\n");
            Result.Append($"CharmedTime:{CharmedTime}\n");
            Result.Append($"HasBeenCharmed:{HasBeenCharmed}\n");
            Result.Append("\n");
            return Convert.ToString(Result);
        }
    }
    public interface ISeeleVollerei
    {
        public enum SeeleVollereiColor { Black, White };
        SeeleVollereiColor Color { get; set; }
    }
}