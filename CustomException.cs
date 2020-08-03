using System;
using BaseClass;

namespace CustomException
{
    sealed class UserMismatchingException : Exception
    {
        public UserMismatchingException(Competitor User) : base()
        {
            Console.WriteLine($"{( (ICompetitor) User ).GetName()}��Ȩ��ʹ�ü���");
        }
    }
}