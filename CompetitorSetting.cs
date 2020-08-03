using BaseClass;

namespace CompetitorSetting
{
    //ç÷ÑÇÄÈ
    class Kiana : Competitor, ICompetitor
    {
        public Kiana()
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
        public string GetName()
        {
            return "Kiana";
        }
    }
    //À×µçÑ¿ÒÂ
    class RaidenMei : Competitor, ICompetitor
    {
        public RaidenMei()
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
        public string GetName()
        {
            return "RaidenMei";
        }
    }
    //ÀöËþÂåË¿Þ±Éª
    class RitaRossweisse : Competitor, ICompetitor
    {
        public RitaRossweisse()
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
        public string GetName()
        {
            return "RitaRossweisse";
        }
    }
    //µÂÀòÉ¯
    class TheresaApocalypse : Competitor, ICompetitor
    {
        public TheresaApocalypse()
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
        public string GetName()
        {
            return "TheresaApocalypse";
        }
    }
    //¶ÉÑ»
    class CorvusCorax : Competitor, ICompetitor
    {
        public CorvusCorax()
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
        public string GetName()
        {
            return "CorvusCorax";
        }
    }
    //²¼ÂåÄÝæ«
    class Bronya : Competitor, ICompetitor
    {
        public Bronya()
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
        public string GetName()
        {
            return "Bronya";
        }
    }
    //¿¨Á«&°ËÖØÓ£
    class KallenAndSakura : Competitor, ICompetitor
    {
        public KallenAndSakura()
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
        public string GetName()
        {
            return "KallenAndSakura";
        }
    }
}