/*
 * Abstract class Controller.
 * This class is in charge of handling user input.
 * This class implements a method consoleGetMove() for console interaction.
 * It is supposed a new method graphicGetMove() would be implemented
 * for Forms interaction in a future release.
 * 
 * Author: Nicolò Tambone 267259
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace KerasTris
{
    abstract class Controller
    {
        // internal var for input
        private String sInput;

        // internal var for the quit flag
        private Boolean quit;

        // property (read only) that returns the state of the quit request
        public Boolean Quit
        {
            get { return this.quit; }
        }

        // property (read only) that contains the input as a string value
        public String input
        {
            get { return this.sInput; }
        }

        // Constructor
        public Controller()
        {
            quit = false;
        }

        // abstract method to be implemented in derived classes
        public abstract int getMove();

        // get move from console input
        protected int consoleGetMove()
        {
            int move = -1;

            try
            {
                sInput = Console.ReadLine();
                
                int input = Convert.ToInt32(sInput);

                move = 1 << input - 1;
            }
            catch (Exception)
            {
                if (sInput == "q" || sInput == "Q")
                {
                    quit = true;
                    move = -1;
                }
            }

            return move;

        }
    }
}
