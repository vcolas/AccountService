using System;

namespace DayTwo
{
    public class PrinterSystem : IPrinterSystem
    {
        public void PrintLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}