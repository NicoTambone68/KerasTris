/*
 * Class ConsoleController.
 * This class implements the abstract class Controller 
 * for the user inputs by console.
 * Actually it just wraps around the method consoleGetMove()
 *
 * 
 * Author: Nicolò Tambone 267259
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace KerasTris
{
    class ConsoleController : Controller
    {
        // Constructor
        public ConsoleController()
        {

        }

        public override int getMove()
        {
            return this.consoleGetMove();
        }
    }
}
