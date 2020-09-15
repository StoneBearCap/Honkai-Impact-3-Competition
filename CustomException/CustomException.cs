using System;

namespace CustomException
{
    public class UserMismatchingException : Exception
    {
        //待改动，解除循环引用并换成静态类型
        public UserMismatchingException(dynamic User) : base()
        {
            Console.WriteLine($"{User.GetName()}无权限使用技能");
        }
    }
}
