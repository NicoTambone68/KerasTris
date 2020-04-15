/*
 * Abstract class View.
 * This class is in charge of the visual representation of the game.
 * 
 * Author: Nicolò Tambone 267259
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace KerasTris
{
    abstract class View
    {
        public abstract void DisplayBoard(Board b, Boolean new_game = false);

        public abstract void DisplayMessage(string s);

    }
}
