/*
 * Abstract class Player.
 * This class encapsulates the actions available for a player.
 * 
 * Author: Nicolò Tambone 267259
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace KerasTris
{
    abstract class Player
    {
        public abstract Board Make_move(Board b, out Boolean quit);
    }
}
