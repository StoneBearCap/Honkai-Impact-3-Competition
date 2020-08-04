using System;
using CompetitorSetting;
using CustomException;

namespace BaseClass
{
    class Competitor
    {
        //概率匿名委托
        Func<int, bool> ProbabilityFunction = (int ProbabilityValue) => 
            new Random().Next(1, 100) <= ProbabilityValue ? true : false;
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
        public int AttackPercentage { get; set; }
        //琪亚娜是否被技能负面影响眩晕
        public bool IsVertigo { get; protected set; }
        //是否被丽塔技能魅惑(若是，则无法使用技能且全伤害永久下降60%持续两回合)
        public bool IsCharmed { get; protected set; }
        //是否曾经被丽塔技能魅惑
        public bool HasBeenCharmed { get; protected set; }
        //魅惑待生效次数
        public int CharmedTime { get; set; }
        //丽塔1技能：女仆的温柔清理，对敌人
        //被影响效果，永久降低攻击力4点
        public void EffectedByRitaRossweisse_Clear(Competitor User)
        {
            try
            {
                if(( (ICompetitor) User ).GetName() != "RitaRossweisse")
                {
                    throw new UserMismatchingException(User);
                }
                int FellowAttack = this.Attack;
                if(Attack > 4)
                {
                    Attack -= 4;
                }
                else
                {
                    Attack = 0;
                }
                this.Health += 3;
                Console.WriteLine($"{( (ICompetitor) User ).GetName()}发动技能女仆的温柔清理，降低{( (ICompetitor) this ).GetName()}{FellowAttack - Attack}点攻击力");
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //丽塔2技能：完美心意，对敌人
        //效果，进入魅惑状态2回合
        public void EffectedByRitaRossweisse_Mind(Competitor User)
        {
            try
            {
                if(( (ICompetitor) User ).GetName() != "RitaRossweisse")
                {
                    throw new UserMismatchingException(User);
                }
                IsCharmed = true;
                CharmedTime = 2;
                if(HasBeenCharmed == false)
                {
                    this.AttackPercentage = this.AttackPercentage * 60 / 100;
                }
                HasBeenCharmed = true;
                Console.WriteLine($"{((ICompetitor)User).GetName()}对{((ICompetitor)this).GetName()}使用魅惑技能，使其进入魅惑状态两回合（期间不能使用技能），永久降低60%伤害");
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        public void ClearChramed()
        {
            if(this.IsCharmed == true)
            {
                this.IsCharmed = false;
            }
        }


        //符华
        //


        //符华
        //

        //德莉莎1技能：血犹大第一可爱，对敌人
        //效果，攻击后30%概率降低5点防御
        public void EffectedByTheresaApocalypse_Judas(Competitor User)
        {
            try
            {
                if(( (ICompetitor) User ).GetName() != "TheresaApocalypse")
                {
                    throw new UserMismatchingException(User);
                }
                if(ProbabilityFunction(30))
                {
                    int FellowDefense = Defense;
                    if(Defense > 5)
                    {
                        Defense -= 5;
                    }
                    else
                    {
                        Defense = 0;
                    }
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}发动技能血犹大第一可爱，降低{( (ICompetitor) this ).GetName()}{FellowDefense - Defense}点防御");
                }
                else
                {

                }
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //德莉莎2技能：在线踢人,对敌人
        //效果，造成5*16伤害
        public void EffectedByTheresaApocalypse_Kick(Competitor User)
        {
            try
            {
                if(( (ICompetitor) User ).GetName() != "TheresaApocalypse")
                {
                    throw new UserMismatchingException(User);
                }
                int FellowHealth = this.Health;
                for(int i = 1; i <= 5; i++)
                {
                    if(ProbabilityFunction(User.HitRate))
                    {
                        int AttackValue = 16 - Defense;
                        AttackValue = AttackValue * User.AttackPercentage / 100;
                        if(Health > AttackValue)
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
                Console.WriteLine($"{( (ICompetitor) User ).GetName()}发动技能在线踢人，对{( (ICompetitor) this ).GetName()}造成{FellowHealth - Health}点伤害");
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //琪亚娜1技能：吃我一矛！，对敌人
        //效果，每两个回合发动，本次攻击的攻击力上升2倍对手防御值
        public void EffectedByKiana_Spear(Competitor User)
        {
            try
            {
                if(( (ICompetitor) User ).GetName() != "Kiana")
                {
                    throw new UserMismatchingException(User);
                }
                if(ProbabilityFunction(User.HitRate))
                {
                    int FellowHealth = this.Health;
                    int AttackValue = User.Attack + this.Defense * 2 - this.Defense;
                    AttackValue = AttackValue * User.AttackPercentage / 100;
                    if(Health > AttackValue)
                    {
                        Health -= AttackValue;
                    }
                    else
                    {
                        Health = 0;
                    }
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}发动技能吃我一矛！，对{( (ICompetitor) this ).GetName()}造成{FellowHealth - Health}点伤害");
                    Console.WriteLine($"{( (ICompetitor) this ).GetName()}剩下{Health}点体力");
                }
                else
                {
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}发动技能吃我一矛！，未命中");
                }
                EffectedByKiana_Voice(User);
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //琪亚娜2技能：音浪~太强~，对自己
        //效果，使用吃我一矛！时35%概率眩晕自己一回合
        private void EffectedByKiana_Voice(Competitor User)
        {
            try
            {
                if(( (ICompetitor) User ).GetName() != "Kiana")
                {
                    throw new UserMismatchingException(User);
                }
                if(ProbabilityFunction(35))
                {
                    User.IsVertigo = true;
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}发动技能音浪~太强~，使自己眩晕一回合");
                }
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //清除眩晕标记，仅对琪亚娜自己有效
        public void ResetVertigo()
        {
            try
            {
                if(( (ICompetitor) this ).GetName() != "Kiana")
                {
                    throw new UserMismatchingException(this);
                }
                if(this.IsVertigo == true)
                {
                    IsVertigo = false;
                }
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //芽衣1技能：崩坏世界的歌姬，对敌人
        //效果：攻击时有30%概率麻痹对方一回合
        public void EffectedByRaidenMei_Singer(Competitor User)
        {
            try
            {
                if(( (ICompetitor) User ).GetName() != "RaidenMei")
                {
                    throw new UserMismatchingException(User);
                }
                if(ProbabilityFunction(30))
                {
                    this.IsParalysis = true;
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}发动技能崩坏世界的歌姬，使{( (ICompetitor) this ).GetName()}麻痹一回合");
                }
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //清除眩晕标记
        public void ResetParalysis()
        {
            if(this.IsParalysis  == true)
            {
                this.IsParalysis = false;
            }
        }
        //芽衣2技能：雷电家的龙女仆，对敌人
        //效果：每两回合发动一次，造成5次3点无视防御的元素伤害（可触发崩坏世界的歌姬一次）
        public void EffectedByRaidenMei_Dragon(Competitor User)
        {
            try
            {
                if(( (ICompetitor) User ).GetName() != "RaidenMei")
                {
                    throw new UserMismatchingException(User);
                }
                int FellowHealth = this.Health;
                for(int i = 1; i <= 5; i++)
                {
                    if(ProbabilityFunction(User.HitRate))
                    {
                        int AttackValue = 3 * User.AttackPercentage / 100;
                        if(Health > AttackValue)
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
                Console.WriteLine($"{( (ICompetitor) User ).GetName()}发动技能雷电家的龙女仆，对{( (ICompetitor) this ).GetName()}造成{FellowHealth - Health}点伤害");
                Console.WriteLine($"{( (ICompetitor) this ).GetName()}剩下{this.Health}点体力");
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //渡鸦1技能：不是针对你，对自己
        //战斗开始时，对琪亚娜伤害提升25%，对其他人造成的伤害有25%概率提升25%
        public void EffectedByCorvusCorax_ToDefender(Competitor Defender)
        {
            try
            {
                if(( (ICompetitor) this ).GetName() != "CorvusCorax")
                {
                    throw new UserMismatchingException(this);
                }
                if(( (ICompetitor) Defender ).GetName() == "Kiana")
                {
                    this.AttackPercentage += 25;
                    Console.WriteLine($"{( (ICompetitor) this ).GetName()}发动技能不是针对你，提升自己对琪亚娜25%伤害");
                }
                else
                {
                    if(ProbabilityFunction(25))
                    {
                        this.AttackPercentage += 25;
                        Console.WriteLine($"{( (ICompetitor) this ).GetName()}发动技能不是针对你，提升自己25%伤害");
                    }
                }
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //渡鸦2技能：别墅小岛，对敌人
        //每三个回合发动一次，给与对方7次16点伤害
        public void EffectedByCorvusCorax_Island(Competitor User)
        {
            try
            {
                if(((ICompetitor)User).GetName()!= "CorvusCorax")
                {
                    throw new UserMismatchingException(User);
                }
                int FellowHealth = Health;
                for(int i = 1; i <= 7; i++)
                {
                    if(ProbabilityFunction(User.HitRate))
                    {
                        int AttackValue = 16 - this.Defense;
                        AttackValue = AttackValue * User.AttackPercentage / 100;
                        if(this.Health > AttackValue)
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
                Console.WriteLine($"{( (ICompetitor) User ).GetName()}发动技能别墅小岛对{( (ICompetitor) this ).GetName()}造成{FellowHealth - Health}点伤害");
                Console.WriteLine($"{( (ICompetitor) this ).GetName()}剩下{Health}点体力");
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //布洛妮娅1技能：天使重构，对敌人
        //攻击后25%概率发射钻头，造成4次12点伤害
        public void EffectedByBronya_Cyberangel(Competitor User)
        {
            try
            {
                if(( (ICompetitor) User ).GetName() != "Bronya")
                {
                    throw new UserMismatchingException(User);
                }
                if(ProbabilityFunction(25))
                {
                    int FellowHealth = this.Health;
                    for(int i = 1; i <= 4; i++)
                    {
                        if(ProbabilityFunction(User.HitRate))
                        {
                            int AttackValue = 12 - this.Defense;
                            AttackValue = AttackValue * User.AttackPercentage / 100;
                            if(this.Health > AttackValue)
                            {
                                this.Health -= AttackValue;
                            }
                            else
                            {
                                this.Health = 0;
                                break;
                            }
                        }
                    }
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}发动技能天使重构，对{( (ICompetitor) this ).GetName()}造成{FellowHealth - Health}点伤害");
                    Console.WriteLine($"{( (ICompetitor) this ).GetName()}剩下{Health}点体力");
                }
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //布洛妮娅2技能：摩托拜客哒！，对敌人
        //每三个回合发动一次，造成1~100点无视防御的元素伤害
        public void EffectedByBronya_Mortar(Competitor User)
        {
            try
            {
                if(( (ICompetitor) User ).GetName() != "Bronya")
                {
                    throw new UserMismatchingException(User);
                }
                Func<int> RandomResult = () => new Random().Next(1, 100);
                if(ProbabilityFunction(User.HitRate))
                {
                    int AttackValue = RandomResult();
                    AttackValue = AttackValue * User.AttackPercentage / 100;
                    int FellowHealth = this.Health;
                    if(this.Health > AttackValue)
                    {
                        Health -= AttackValue;
                    }
                    else
                    {
                        Health = 0;
                    }
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}发动技能摩托拜客哒！，对{( (ICompetitor) this ).GetName()}造成{FellowHealth - Health}点伤害");
                }
                else
                {
                    Console.WriteLine($"{((ICompetitor)User).GetName()}发动技能摩托拜客哒！未命中");
                }
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //卡莲&八重樱1技能：八重樱的饭团，对自己
        //每个回合攻击前有30%概率回复25点生命
        public void EffectedBySakura()
        {
            try
            {
                if(( (ICompetitor) this ).GetName() != "KallenAndSakura")
                {
                    throw new UserMismatchingException(this);
                }
                if(ProbabilityFunction(30))
                {
                    int FellowHealth = this.Health;
                    Health = ( 100 - Health ) >= 25 ? Health + 25 : 100;
                    Console.WriteLine($"{( (ICompetitor) this ).GetName()}发动技能八重樱的饭团，回复自己{Health-FellowHealth}点血量");
                }
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //卡莲&八重樱2技能：卡莲的饭团，对敌人
        //每两个回合发动一次，对敌人造成25点元素伤害
        public void EffectedByKallen(Competitor User)
        {
            try
            {
                if(( (ICompetitor) User ).GetName() != "KallenAndSakura")
                {
                    throw new UserMismatchingException(User);
                }
                if(ProbabilityFunction(User.HitRate))
                {
                    int FellowHealth = this.Health;
                    int AttackValue = 25 * User.AttackPercentage / 100;
                    if(this.Health > AttackValue)
                    {
                        this.Health -= AttackValue;
                    }
                    else
                    {
                        this.Health = 0;
                    }
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}发动技能卡莲的饭团，对{( (ICompetitor) this ).GetName()}造成{FellowHealth - Health}点伤害");
                }
                else
                {
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}发动技能卡莲的饭团，未命中");
                }
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //希儿技能：我换我自己（拜托了，另一个我/去吧，希儿，去守护我们的约定）
        //每个回合攻击前阶段切换一次状态
        //黑希，攻击提高10点，防御降低5点
        //白希，切换时回复1~15点生命，攻击减少10点，防御增加5点
        public void EffectedBySeeleVollerei()
        {
            try
            {
                if(((ICompetitor)this).GetName()!= "SeeleVollerei")
                {
                    throw new UserMismatchingException(this);
                }
                //黑变白
                if(( (SeeleVollerei) this ).Color == SeeleVollerei.SeeleVollereiColor.Black)
                {
                    int FellowHealth = this.Health;
                    int FellowAttack = this.Attack;
                    int FellowDefense = this.Defense;
                    ( (SeeleVollerei) this ).Color = SeeleVollerei.SeeleVollereiColor.White;
                    int RandomResult = new Random().Next(1, 15);
                    this.Health = this.Health + RandomResult >= 100 ? 100 : this.Health + RandomResult;
                    this.Attack = this.Attack >= 10 ? this.Attack - 10 : 0;
                    this.Defense += 5;
                    Console.WriteLine($"{( (ICompetitor) this ).GetName()}发动技能我换我自己，“去吧，希儿，去守护我们的约定”，降低{FellowAttack - Attack}点攻击，提升{Health - FellowHealth}点生命，提升{this.Defense - FellowDefense}点防御");
                }
                //白变黑
                else if(( (SeeleVollerei) this ).Color == SeeleVollerei.SeeleVollereiColor.White)
                {
                    int FellowAttack = this.Attack;
                    int FellowDefense = this.Defense;
                    ( (SeeleVollerei) this ).Color = SeeleVollerei.SeeleVollereiColor.Black;
                    this.Attack += 10;
                    this.Defense = this.Defense >= 5 ? this.Defense - 5 : 0;
                    Console.WriteLine($"{( (ICompetitor) this ).GetName()}发动技能我换我自己，“拜托了，另一个我”，提升{this.Attack - FellowAttack}点攻击，降低{FellowDefense - this.Defense}点防御");
                }
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }

        //普通攻击
        public void GetAttacked(Competitor Attacker)
        {
            //普通攻击命中
            if(ProbabilityFunction(Attacker.HitRate))
            {
                int FellowHealth = Health;
                //物理攻击
                if(Attacker.IsPhysical == true)
                {
                    int AttackValue = Attacker.Attack - this.Defense;
                    AttackValue = AttackValue * Attacker.AttackPercentage / 100;
                    if(AttackValue < 0)
                    {
                        Console.WriteLine($"{( (ICompetitor) Attacker ).GetName()}普通攻击未对{( (ICompetitor) this ).GetName()}造成伤害");
                        return;
                    }
                    else
                    {
                        if(Health > AttackValue)
                        {
                            Health -= AttackValue;
                        }
                        else
                        {
                            Health = 0;
                        }
                        Console.WriteLine($"{( (ICompetitor) Attacker ).GetName()}普通攻击对{( (ICompetitor) this ).GetName()}造成{FellowHealth - Health}点伤害");
                    }
                }
                //元素攻击
                else
                {
                    int AttackValue = Attacker.Attack;
                    AttackValue = AttackValue * Attacker.AttackPercentage / 100;
                    if(Health > AttackValue)
                    {
                        Health -= AttackValue;
                    }
                    else
                    {
                        Health = 0;
                    }
                    Console.WriteLine($"{( (ICompetitor) Attacker ).GetName()}普通攻击对{( (ICompetitor) this ).GetName()}造成{FellowHealth - Health}点伤害");
                }
                Console.WriteLine($"{( (ICompetitor) this ).GetName()}剩下{Health}点生命值");
            }
            //普通攻击未命中
            else
            {
                Console.WriteLine($"{( (ICompetitor) Attacker ).GetName()}普通攻击未命中");
            }
        }
        //测试用方法，输出人物实时数据
        sealed public override string ToString()
        {
            string Result = null;
            Result += $"Name:{((ICompetitor)this).GetName()}\n";
            Result += $"Health:{Health}\n";
            Result += $"Attack:{Attack}\n";
            Result += $"Defense:{Defense}\n";
            Result += $"Speed:{Speed}\n";
            Result += $"HitRate:{HitRate}\n";
            Result += $"AttackPercentage:{AttackPercentage}\n";
            Result += $"IsVertigo:{IsVertigo}\n";
            Result += $"IsPhysical:{IsPhysical}\n";
            Result += $"IsParalysis:{IsParalysis}\n";
            Result += $"IsChramed:{IsCharmed}\n";
            Result += $"CharmedTime:{CharmedTime}\n";
            Result += $"HasBeenCharmed:{HasBeenCharmed}\n";
            Result += "\n";
            return Result;
        }
    }

    interface ICompetitor
    {
        public abstract string GetName();
    }
}
