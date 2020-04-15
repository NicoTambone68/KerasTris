using System;
using System.Collections.Generic;
using System.Text;

namespace KerasTris
{
    class ConsoleView : View
     {
        // Constructor
        public ConsoleView()
        {

        }

        public override void DisplayBoard(Board b, Boolean new_game = false)
        {
            if (new_game == true)
            {
                Console.WriteLine("\n\n");
            }
            else Console.WriteLine("\n");

            Console.WriteLine(b);
        }

        public override void DisplayMessage(string s)
        {
            Console.WriteLine(s);
        }
    }
}
