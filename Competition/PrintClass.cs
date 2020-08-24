using System;
using System.IO;
using System.Text;
using Competition.MainProgram;

namespace Competition.Write
{
    class Print
    {
        public string Data {  get; private set; } = default;
        public Print(string data)
        {
            Data = data;
        }
    }
    class ScreenPrint : Print
    {
        public ScreenPrint(string data) : base(data)
        {
            Console.WriteLine(Data);
        }
    }
    class FilePrint : Print
    {
        public string FileName { get; private set; } = default;
        public FilePrint(string data) : base(data)
        {
            FileName = (string)typeof(FileSetting).GetProperty("FileName").GetValue(new FileSetting());
            using (var FileOperation = new StreamWriter(FileName, true, Encoding.UTF8, 10000)) 
            {
                FileOperation.WriteLine(Data);
            }
        }
    }
}
