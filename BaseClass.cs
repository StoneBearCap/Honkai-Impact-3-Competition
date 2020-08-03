using System;
using CustomException;

namespace BaseClass
{
    class Competitor
    {
        //��������ί��
        Func<int, bool> ProbabilityFunction = (int ProbabilityValue) => 
            new Random().Next(1, 100) <= ProbabilityValue ? true : false;
        public int Health { get; protected set; }
        public int Attack { get; protected set; }
        public int Defense { get; protected set; }
        public int Speed { get; protected set; }
        //�Ƿ���������������ΪԪ��
        public bool IsPhysical { get; protected set; }
        //������,100Ϊ��ʼֵ����100%
        public int HitRate { get; protected set; }
        //�Ƿ���ԣ�ѿ�¹���������ԣ�
        public bool IsParalysis { get; protected set; }
        //ȫ�˺�����,100Ϊ��ʼֵ����100%
        public int AttackPercentage { get; set; }
        //�������Ƿ񱻼��ܸ���Ӱ��ѣ��
        public bool IsVertigo { get; protected set; }
        //�Ƿ����������Ȼ�(���ǣ����޷�ʹ�ü�����ȫ�˺������½�60%�������غ�)
        public bool IsCharmed { get; protected set; }
        //�Ƿ����������������Ȼ�
        public bool HasBeenCharmed { get; protected set; }
        //�Ȼ����Ч����
        public int CharmedTime { get; set; }
        //����1���ܣ�Ů�͵����������Ե���
        //��Ӱ��Ч�������ý��͹�����4��
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
                Console.WriteLine($"{( (ICompetitor) User ).GetName()}��������Ů�͵�������������{( (ICompetitor) this ).GetName()}{FellowAttack - Attack}�㹥����");
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //����2���ܣ��������⣬�Ե���
        //Ч���������Ȼ�״̬2�غ�
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
                Console.WriteLine($"{((ICompetitor)User).GetName()}��{((ICompetitor)this).GetName()}ʹ���Ȼ��ܣ�ʹ������Ȼ�״̬���غϣ��ڼ䲻��ʹ�ü��ܣ������ý���60%�˺�");
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


        //����
        //


        //����
        //

        //����ɯ1���ܣ�Ѫ�̴��һ�ɰ����Ե���
        //Ч����������30%���ʽ���5�����
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
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}��������Ѫ�̴��һ�ɰ�������{( (ICompetitor) this ).GetName()}{FellowDefense - Defense}�����");
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
        //����ɯ2���ܣ���������,�Ե���
        //Ч�������5*16�˺�
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
                Console.WriteLine($"{( (ICompetitor) User ).GetName()}���������������ˣ���{( (ICompetitor) this ).GetName()}���{FellowHealth - Health}���˺�");
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //������1���ܣ�����һì�����Ե���
        //Ч����ÿ�����غϷ��������ι����Ĺ���������2�����ַ���ֵ
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
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}�������ܳ���һì������{( (ICompetitor) this ).GetName()}���{FellowHealth - Health}���˺�");
                    Console.WriteLine($"{( (ICompetitor) this ).GetName()}ʣ��{Health}������");
                }
                else
                {
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}�������ܳ���һì����δ����");
                }
                EffectedByKiana_Voice(User);
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //������2���ܣ�����~̫ǿ~�����Լ�
        //Ч����ʹ�ó���һì��ʱ35%����ѣ���Լ�һ�غ�
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
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}������������~̫ǿ~��ʹ�Լ�ѣ��һ�غ�");
                }
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //���ѣ�α�ǣ������������Լ���Ч
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
        //ѿ��1���ܣ���������ĸ輧���Ե���
        //Ч��������ʱ��30%������ԶԷ�һ�غ�
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
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}�������ܱ�������ĸ輧��ʹ{( (ICompetitor) this ).GetName()}���һ�غ�");
                }
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //���ѣ�α��
        public void ResetParalysis()
        {
            if(this.IsParalysis  == true)
            {
                this.IsParalysis = false;
            }
        }
        //ѿ��2���ܣ��׵�ҵ���Ů�ͣ��Ե���
        //Ч����ÿ���غϷ���һ�Σ����5��3�����ӷ�����Ԫ���˺����ɴ�����������ĸ輧һ�Σ�
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
                Console.WriteLine($"{( (ICompetitor) User ).GetName()}���������׵�ҵ���Ů�ͣ���{( (ICompetitor) this ).GetName()}���{FellowHealth - Health}���˺�");
                Console.WriteLine($"{( (ICompetitor) this ).GetName()}ʣ��{this.Health}������");
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //��ѻ1���ܣ���������㣬���Լ�
        //ս����ʼʱ�����������˺�����25%������������ɵ��˺���25%��������25%
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
                    Console.WriteLine($"{( (ICompetitor) this ).GetName()}�������ܲ�������㣬�����Լ���������25%�˺�");
                }
                else
                {
                    if(ProbabilityFunction(25))
                    {
                        this.AttackPercentage += 25;
                        Console.WriteLine($"{( (ICompetitor) this ).GetName()}�������ܲ�������㣬�����Լ�25%�˺�");
                    }
                }
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //��ѻ2���ܣ�����С�����Ե���
        //ÿ�����غϷ���һ�Σ�����Է�7��16���˺�
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
                Console.WriteLine($"{( (ICompetitor) User ).GetName()}�������ܱ���С����{( (ICompetitor) this ).GetName()}���{FellowHealth - Health}���˺�");
                Console.WriteLine($"{( (ICompetitor) this ).GetName()}ʣ��{Health}������");
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //�������1���ܣ���ʹ�ع����Ե���
        //������25%���ʷ�����ͷ�����4��12���˺�
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
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}����������ʹ�ع�����{( (ICompetitor) this ).GetName()}���{FellowHealth - Health}���˺�");
                    Console.WriteLine($"{( (ICompetitor) this ).GetName()}ʣ��{Health}������");
                }
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //�������2���ܣ�Ħ�аݿ��գ����Ե���
        //ÿ�����غϷ���һ�Σ����1~100�����ӷ�����Ԫ���˺�
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
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}��������Ħ�аݿ��գ�����{( (ICompetitor) this ).GetName()}���{FellowHealth - Health}���˺�");
                }
                else
                {
                    Console.WriteLine($"{((ICompetitor)User).GetName()}��������Ħ�аݿ��գ�δ����");
                }
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //����&����ӣ1���ܣ�����ӣ�ķ��ţ����Լ�
        //ÿ���غϹ���ǰ��30%���ʻظ�25������
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
                    Console.WriteLine($"{( (ICompetitor) this ).GetName()}�������ܰ���ӣ�ķ��ţ��ظ��Լ�{Health-FellowHealth}��Ѫ��");
                }
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //����&����ӣ2���ܣ������ķ��ţ��Ե���
        //ÿ�����غϷ���һ�Σ��Ե������25��Ԫ���˺�
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
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}�������ܿ����ķ��ţ���{( (ICompetitor) this ).GetName()}���{FellowHealth - Health}���˺�");
                }
                else
                {
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}�������ܿ����ķ��ţ�δ����");
                }
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }

        //��ͨ����
        public void GetAttacked(Competitor Attacker)
        {
            //��ͨ��������
            if(ProbabilityFunction(Attacker.HitRate))
            {
                int FellowHealth = Health;
                //������
                if(Attacker.IsPhysical == true)
                {
                    int AttackValue = Attacker.Attack - this.Defense;
                    AttackValue = AttackValue * Attacker.AttackPercentage / 100;
                    if(AttackValue < 0)
                    {
                        Console.WriteLine($"{( (ICompetitor) Attacker ).GetName()}��ͨ����δ��{( (ICompetitor) this ).GetName()}����˺�");
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
                        Console.WriteLine($"{( (ICompetitor) Attacker ).GetName()}��ͨ������{( (ICompetitor) this ).GetName()}���{FellowHealth - Health}���˺�");
                    }
                }
                //Ԫ�ع���
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
                    Console.WriteLine($"{( (ICompetitor) Attacker ).GetName()}��ͨ������{( (ICompetitor) this ).GetName()}���{FellowHealth - Health}���˺�");
                }
                Console.WriteLine($"{( (ICompetitor) this ).GetName()}ʣ��{Health}������ֵ");
            }
            //��ͨ����δ����
            else
            {
                Console.WriteLine($"{( (ICompetitor) Attacker ).GetName()}��ͨ����δ����");
            }
        }
        //�����÷������������ʵʱ����
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