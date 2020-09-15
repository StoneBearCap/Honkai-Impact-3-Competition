using System;
using System.IO;
using System.Text;

namespace PrintLibrary
{
    public class Print
    {
        public string Data { get; protected set; } = default;
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
        public string FileName { get; private set; } = default;
        public FilePrint(string data) : base(data)
        {
            FileName = (string) typeof(PrintSetting).GetProperty("FileName").GetValue(new PrintSetting());
        }
        public void PrintMethod()
        {
            using(var FileOperation = new StreamWriter(FileName, true, Encoding.UTF8, 30000))
            {
                FileOperation.WriteLine(Data);
            }
        }
    }
    public class PrintSetting
    {
        static public string FileName { get; private set; } = default;
        static public bool FileOrNot { get; private set; } = false;
        static public bool ScreenOrNot { get; private set; } = false;
    }
}
