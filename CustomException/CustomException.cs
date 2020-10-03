using System;

namespace CustomException
{
    public class UserMismatchingException : Exception
    {
        public UserMismatchingException(ICompetitor User) : base()
        {
            Console.WriteLine($"{User.GetName()}无权限使用技能");
        }
    }
    public interface ICompetitor
    {
        string GetName();
    }
}
