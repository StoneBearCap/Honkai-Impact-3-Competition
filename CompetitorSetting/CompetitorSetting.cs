using Competition.BaseClass;

namespace CompetitorSetting
{
    //琪亚娜
    public class Kiana : Competitor
    {
        public Kiana()
        {
            Refresh();
        }
        public override void Refresh()
        {
            Health = 100;
            Attack = 24;
            Defense = 11;
            Speed = 23;
            IsPhysical = true;
            IsCharmed = false;
            CharmedTime = 0;
            IsVertigo = false;
            IsParalysis = false;
            HasBeenCharmed = false;
            AttackPercentage = 100;
            HitRate = 100;
        }
        public override string GetName()
        {
            return "Kiana";
        }
    }
    //雷电芽衣
    public class RaidenMei : Competitor
    {
        public RaidenMei()
        {
            Refresh();
        }
        public override void Refresh()
        {
            Health = 100;
            Attack = 24;
            Defense = 12;
            Speed = 30;
            IsPhysical = true;
            IsCharmed = false;
            CharmedTime = 0;
            IsVertigo = false;
            IsParalysis = false;
            HasBeenCharmed = false;
            AttackPercentage = 100;
            HitRate = 100;
        }
        public override string GetName()
        {
            return "RaidenMei";
        }
    }
    //丽塔洛丝薇瑟
    public class RitaRossweisse : Competitor
    {
        public RitaRossweisse()
        {
            Refresh();
        }
        public override void Refresh()
        {
            Health = 100;
            Attack = 26;
            Defense = 11;
            Speed = 17;
            IsPhysical = true;
            IsCharmed = false;
            CharmedTime = 0;
            IsVertigo = false;
            IsParalysis = false;
            HasBeenCharmed = false;
            AttackPercentage = 100;
            HitRate = 100;
        }
        public override string GetName()
        {
            return "RitaRossweisse";
        }
    }
    //德莉莎
    public class TheresaApocalypse : Competitor
    {
        public TheresaApocalypse()
        {
            Refresh();
        }
        public override void Refresh()
        {
            Health = 100;
            Attack = 19;
            Defense = 12;
            Speed = 22;
            IsPhysical = true;
            IsCharmed = false;
            CharmedTime = 0;
            IsVertigo = false;
            IsParalysis = false;
            HasBeenCharmed = false;
            AttackPercentage = 100;
            HitRate = 100;
        }
        public override string GetName()
        {
            return "TheresaApocalypse";
        }
    }
    //渡鸦
    public class CorvusCorax : Competitor
    {
        public CorvusCorax()
        {
            Refresh();
        }
        public override void Refresh()
        {
            Health = 100;
            Attack = 23;
            Defense = 14;
            Speed = 14;
            IsPhysical = true;
            IsCharmed = false;
            CharmedTime = 0;
            IsVertigo = false;
            IsParalysis = false;
            HasBeenCharmed = false;
            AttackPercentage = 100;
            HitRate = 100;
        }
        public override string GetName()
        {
            return "CorvusCorax";
        }
    }
    //布洛妮娅
    public class Bronya : Competitor
    {
        public Bronya()
        {
            Refresh();
        }
        public override void Refresh()
        {
            Health = 100;
            Attack = 21;
            Defense = 10;
            Speed = 20;
            IsPhysical = true;
            IsCharmed = false;
            CharmedTime = 0;
            IsVertigo = false;
            IsParalysis = false;
            HasBeenCharmed = false;
            AttackPercentage = 100;
            HitRate = 100;
        }
        public override string GetName()
        {
            return "Bronya";
        }
    }
    //卡莲&八重樱
    public class KallenAndSakura : Competitor
    {
        public KallenAndSakura()
        {
            Refresh();
        }
        public override void Refresh()
        {
            Health = 100;
            Attack = 20;
            Defense = 9;
            Speed = 18;
            IsPhysical = true;
            IsCharmed = false;
            CharmedTime = 0;
            IsVertigo = false;
            IsParalysis = false;
            HasBeenCharmed = false;
            AttackPercentage = 100;
            HitRate = 100;
        }
        public override string GetName()
        {
            return "KallenAndSakura";
        }
    }
    //希儿
    public class SeeleVollerei : Competitor, ISeeleVollerei
    {

        public ISeeleVollerei.SeeleVollereiColor Color { get; set; }

        public SeeleVollerei()
        {
            Refresh();
        }
        public override void Refresh()
        {
            Color = ISeeleVollerei.SeeleVollereiColor.White;
            Health = 100;
            Attack = 23;
            Defense = 13;
            Speed = 26;
            IsPhysical = true;
            IsCharmed = false;
            CharmedTime = 0;
            IsVertigo = false;
            IsParalysis = false;
            HasBeenCharmed = false;
            AttackPercentage = 100;
            HitRate = 100;
        }
        public override string GetName()
        {
            return "SeeleVollerei";
        }
    }
    //符华
    public class FuHua : Competitor
    {
        public FuHua()
        {
            Refresh();
        }
        public override void Refresh()
        {
            Health = 100;
            Attack = 17;
            Defense = 15;
            Speed = 16;
            IsPhysical = false;
            IsCharmed = false;
            CharmedTime = 0;
            IsVertigo = false;
            IsParalysis = false;
            HasBeenCharmed = false;
            AttackPercentage = 100;
            HitRate = 100;
        }
        public override string GetName()
        {
            return "FuHua";
        }
    }
    //姬子
    public class Himeko : Competitor
    {
        public Himeko()
        {
            Refresh();
        }
        public override void Refresh()
        {
            Health = 100;
            Attack = 23;
            Defense = 9;
            Speed = 12;
            IsPhysical = true;
            IsCharmed = false;
            CharmedTime = 0;
            IsVertigo = false;
            IsParalysis = false;
            HasBeenCharmed = false;
            AttackPercentage = 100;
            HitRate = 100;
        }
        public override string GetName()
        {
            return "Himeko";
        }
    }
}
