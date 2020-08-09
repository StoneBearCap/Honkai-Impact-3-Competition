using System;
using CompetitorSetting;
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
        public int AttackPercentage { get; protected set; }
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
                int PreviousAttack = Attack;
                if(Attack > 4)
                {
                    Attack -= 4;
                }
                else
                {
                    Attack = 0;
                }
                Health += 3;
                Console.WriteLine($"{( (ICompetitor) User ).GetName()}��������Ů�͵�������������{( (ICompetitor) this ).GetName()}{PreviousAttack - Attack}�㹥����");
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
                    AttackPercentage = AttackPercentage * 60 / 100;
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
            if(IsCharmed == true)
            {
                IsCharmed = false;
            }
        }
        //�������ܣ���֮��ī���Ե���
        //ÿ�����غϷ���һ�Σ����18��Ԫ���˺������Ͷ���25%�����ʣ��ɵ���
        public void EffectedByFuHua(Competitor User)
        {
            try
            {
                if(( (ICompetitor) User ).GetName() != "FuHua")
                {
                    throw new UserMismatchingException(User);
                }
                if(ProbabilityFunction(User.HitRate))
                {
                    int AttackValue = 18 * User.AttackPercentage / 100;
                    int PreviousHealth = Health;
                    int PreviousHitRate = HitRate;
                    if(Health >= AttackValue)
                    {
                        Health -= AttackValue;
                    }
                    else
                    {
                        Health = 0;
                    }
                    if(HitRate >= 25)
                    {
                        HitRate -= 25;
                    }
                    else
                    {
                        HitRate = 0;
                    }
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}����������֮��ī����{( (ICompetitor) this ).GetName()}���{PreviousHealth - Health}���˺�������{PreviousHitRate - HitRate}%������");

                }
                else
                {
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}����������֮��īδ����");
                }
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
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
                    int PreviousDefense = Defense;
                    if(Defense > 5)
                    {
                        Defense -= 5;
                    }
                    else
                    {
                        Defense = 0;
                    }
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}��������Ѫ�̴��һ�ɰ�������{( (ICompetitor) this ).GetName()}{PreviousDefense - Defense}�����");
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
                int PreviousHealth = Health;
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
                Console.WriteLine($"{( (ICompetitor) User ).GetName()}���������������ˣ���{( (ICompetitor) this ).GetName()}���{PreviousHealth - Health}���˺�");
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
                    int PreviousHealth = Health;
                    int AttackValue = User.Attack + Defense * 2 - Defense;
                    AttackValue = AttackValue * User.AttackPercentage / 100;
                    if(Health >= AttackValue)
                    {
                        Health -= AttackValue;
                    }
                    else
                    {
                        Health = 0;
                    }
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}�������ܳ���һì������{( (ICompetitor) this ).GetName()}���{PreviousHealth - Health}���˺�");
                    Console.WriteLine($"{( (ICompetitor) this ).GetName()}ʣ��{Health}������");
                }
                else
                {
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}�������ܳ���һì����δ����");
                }
                User.EffectedByKiana_Voice();
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //������2���ܣ�����~̫ǿ~�����Լ�
        //Ч����ʹ�ó���һì��ʱ35%����ѣ���Լ�һ�غ�
        private void EffectedByKiana_Voice()
        {
            try
            {
                if(( (ICompetitor) this ).GetName() != "Kiana")
                {
                    throw new UserMismatchingException(this);
                }
                if(ProbabilityFunction(35))
                {
                    IsVertigo = true;
                    Console.WriteLine($"{( (ICompetitor) this ).GetName()}������������~̫ǿ~��ʹ�Լ�ѣ��һ�غ�");
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
                if(IsVertigo == true)
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
                    IsParalysis = true;
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
            if(IsParalysis  == true)
            {
                IsParalysis = false;
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
                int PreviousHealth = Health;
                for(int i = 1; i <= 5; i++)
                {
                    if(ProbabilityFunction(User.HitRate))
                    {
                        int AttackValue = 3 * User.AttackPercentage / 100;
                        if(Health >= AttackValue)
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
                Console.WriteLine($"{( (ICompetitor) User ).GetName()}���������׵�ҵ���Ů�ͣ���{( (ICompetitor) this ).GetName()}���{PreviousHealth - Health}���˺�");
                Console.WriteLine($"{( (ICompetitor) this ).GetName()}ʣ��{Health}������");
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
                    AttackPercentage += 25;
                    Console.WriteLine($"{( (ICompetitor) this ).GetName()}�������ܲ�������㣬�����Լ���������25%�˺�");
                }
                else
                {
                    if(ProbabilityFunction(25))
                    {
                        AttackPercentage += 25;
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
                int PreviousHealth = Health;
                for(int i = 1; i <= 7; i++)
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
                Console.WriteLine($"{( (ICompetitor) User ).GetName()}�������ܱ���С����{( (ICompetitor) this ).GetName()}���{PreviousHealth - Health}���˺�");
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
                    int PreviousHealth = Health;
                    for(int i = 1; i <= 4; i++)
                    {
                        if(ProbabilityFunction(User.HitRate))
                        {
                            int AttackValue = 12 - Defense;
                            AttackValue = AttackValue * User.AttackPercentage / 100;
                            if(Health >= AttackValue)
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
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}����������ʹ�ع�����{( (ICompetitor) this ).GetName()}���{PreviousHealth - Health}���˺�");
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
                if(ProbabilityFunction(User.HitRate))
                {
                    int AttackValue = new Random().Next(1, 100);
                    AttackValue = AttackValue * User.AttackPercentage / 100;
                    int PreviousHealth = Health;
                    if(Health > AttackValue)
                    {
                        Health -= AttackValue;
                    }
                    else
                    {
                        Health = 0;
                    }
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}��������Ħ�аݿ��գ�����{( (ICompetitor) this ).GetName()}���{PreviousHealth - Health}���˺�");
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
                    int PreviousHealth = Health;
                    Health = ( 100 - Health ) >= 25 ? Health + 25 : 100;
                    Console.WriteLine($"{( (ICompetitor) this ).GetName()}�������ܰ���ӣ�ķ��ţ��ظ��Լ�{Health-PreviousHealth}��Ѫ��");
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
                    int PreviousHealth = Health;
                    int AttackValue = 25 * User.AttackPercentage / 100;
                    if(Health > AttackValue)
                    {
                        Health -= AttackValue;
                    }
                    else
                    {
                        Health = 0;
                    }
                    Console.WriteLine($"{( (ICompetitor) User ).GetName()}�������ܿ����ķ��ţ���{( (ICompetitor) this ).GetName()}���{PreviousHealth - Health}���˺�");
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
        //ϣ�����ܣ��һ����Լ��������ˣ���һ����/ȥ�ɣ�ϣ����ȥ�ػ����ǵ�Լ����
        //ÿ���غϹ���ǰ�׶��л�һ��״̬
        //��ϣ���������10�㣬��������5��
        //��ϣ���л�ʱ�ظ�1~15����������������10�㣬��������5��
        public void EffectedBySeeleVollerei()
        {
            try
            {
                if(((ICompetitor)this).GetName()!= "SeeleVollerei")
                {
                    throw new UserMismatchingException(this);
                }
                //�ڱ��
                if(( (SeeleVollerei) this ).Color == SeeleVollerei.SeeleVollereiColor.Black)
                {
                    int PreviousHealth = Health;
                    int PreviousAttack = Attack;
                    int PreviousDefense = Defense;
                    ( (SeeleVollerei) this ).Color = SeeleVollerei.SeeleVollereiColor.White;
                    int RandomResult = new Random().Next(1, 15);
                    Health = Health + RandomResult >= 100 ? 100 : Health + RandomResult;
                    Attack = Attack >= 10 ? Attack - 10 : 0;
                    Defense += 5;
                    Console.WriteLine($"{( (ICompetitor) this ).GetName()}���������һ����Լ�����ȥ�ɣ�ϣ����ȥ�ػ����ǵ�Լ����������{PreviousAttack - Attack}�㹥��������{Health - PreviousHealth}������������{Defense - PreviousDefense}�����");
                }
                //�ױ��
                else if(( (SeeleVollerei) this ).Color == SeeleVollerei.SeeleVollereiColor.White)
                {
                    int PreviousAttack = Attack;
                    int PreviousDefense = Defense;
                    ( (SeeleVollerei) this ).Color = SeeleVollerei.SeeleVollereiColor.Black;
                    Attack += 10;
                    Defense = Defense >= 5 ? Defense - 5 : 0;
                    Console.WriteLine($"{( (ICompetitor) this ).GetName()}���������һ����Լ����������ˣ���һ���ҡ�������{Attack - PreviousAttack}�㹥��������{PreviousDefense - Defense}�����");
                }
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //����1���ܣ��氮���������Լ�
        //�Էǵ��˶�������˺�����100%
        public void EffectedByHimeko_Love(Competitor Defender)
        {
            try
            {
                if(( (ICompetitor) this ).GetName() != "Himeko")
                {
                    throw new UserMismatchingException(this);
                }
                if(( (ICompetitor) Defender ).GetName() == "KallenAndSakura")
                {
                    AttackPercentage += 100;
                    Console.WriteLine($"{( (ICompetitor) this ).GetName()}���������氮����������100%�˺�");
                }
            }
            catch(UserMismatchingException)
            {
                return;
            }
        }
        //����2���ܣ��ɱ������ѣ����Լ�
        //ÿ2�غϷ���һ�Σ�����ǰʹ�Լ����������������������ʽ���35%���ɵ���
        public void EffectedByHimeko_Alcohol()
        {
            try
            {
                if(( (ICompetitor) this ).GetName() != "Himeko")
                {
                    throw new UserMismatchingException(this);
                }
                int PreviousAttack = Attack;
                int PreviousHitRate = HitRate;
                Attack *= 2;
                HitRate = HitRate >= 35 ? HitRate - 35 : 0;
                Console.WriteLine($"{( (ICompetitor) this ).GetName()}�������ܸɱ������� ����{Attack - PreviousAttack}�㹥����������{PreviousHitRate - HitRate}%������");
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
                int PreviousHealth = Health;
                //������
                if(Attacker.IsPhysical == true)
                {
                    int AttackValue = Attacker.Attack - Defense;
                    AttackValue = AttackValue * Attacker.AttackPercentage / 100;
                    if(AttackValue < 0)
                    {
                        Console.WriteLine($"{( (ICompetitor) Attacker ).GetName()}��ͨ����δ��{( (ICompetitor) this ).GetName()}����˺�");
                        return;
                    }
                    else
                    {
                        if(Health >= AttackValue)
                        {
                            Health -= AttackValue;
                        }
                        else
                        {
                            Health = 0;
                        }
                        Console.WriteLine($"{( (ICompetitor) Attacker ).GetName()}��ͨ������{( (ICompetitor) this ).GetName()}���{PreviousHealth - Health}���˺�");
                    }
                }
                //Ԫ�ع���
                else
                {
                    int AttackValue = Attacker.Attack;
                    AttackValue = AttackValue * Attacker.AttackPercentage / 100;
                    if(Health >= AttackValue)
                    {
                        Health -= AttackValue;
                    }
                    else
                    {
                        Health = 0;
                    }
                    Console.WriteLine($"{( (ICompetitor) Attacker ).GetName()}��ͨ������{( (ICompetitor) this ).GetName()}���{PreviousHealth - Health}���˺�");
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