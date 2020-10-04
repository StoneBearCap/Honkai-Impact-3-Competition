using System;
using System.IO;
using System.Text;

namespace PrintLibrary
{
    public class Print
    {
        public string Data { get; protected set; } = default;
        static public string FileName { get; set; } = null;
        static public bool FileOrNot { get; set; } = false;
        static public bool ScreenOrNot { get; set; } = false;
        public Print(string data)
        {
            Data = data;
        }
    }
    public class ScreenPrint : Print
    {
        public ScreenPrint(string data) : base(data)
        {

        }
        public void PrintMethod()
        {
            Console.WriteLine(Data);
        }
    }
    public class FilePrint : Print
    {
        public FilePrint(string data) : base(data)
        {
            
        }
        public void PrintMethod()
        {
            using (var FileOperation = new StreamWriter(FileName, true, Encoding.UTF8, 30000))
            {
                FileOperation.WriteLine(Data);
            }
        }
    }
}
