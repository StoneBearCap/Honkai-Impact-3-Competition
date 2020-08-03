using System;
using BaseClass;

namespace CustomException
{
    sealed class UserMismatchingException : Exception
    {
        public UserMismatchingException(Competitor User) : base()
        {
            Console.WriteLine($"{( (ICompetitor) User ).GetName()}无权限使用技能");
        }
    }
}
