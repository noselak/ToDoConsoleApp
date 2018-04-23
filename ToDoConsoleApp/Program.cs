using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoLibrary;

namespace ToDoConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DataManager.LoadInitialData();
            Controls.PrintWelcomeMessage();
            Controls.PrintInstructions();
            while (true)
            {
                Controls.Actions();
            }
        }
    }
}
