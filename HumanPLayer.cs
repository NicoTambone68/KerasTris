/*
 * Class HumanPlayer.
 * This class implements the abstract class Player for the
 * actions available to the human player.
 * 
 * Author: Nicolò Tambone 267259
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace KerasTris
{
    class HumanPlayer : Player
    {

        // internal var for the view
        private View view;

        // internal var for the controller
        private Controller controller;

        // The human player interacts with both view and controller
        // so these have to be passed to the constructor
        public HumanPlayer(View view, Controller controller)
        {
            this.view = view;
            this.controller = controller;
        }

        // Implementation of the move by the human player
        public override Board Make_move(Board b, out Boolean quit)
        {
            // this list keeps track of the moves currently still available
            List<int> legalMoves = new List<int>();

            // initializing the chosen move with an invalid value
            // the actual range is 1-9
            int move = -1;

            // initializing the termination flag
            quit = false;

            foreach( int i in b.Moves())
            {
                legalMoves.Add(i);
            }

            // loop until a valid move is made or the user quits
            while (!(legalMoves.Contains(move)))
            {
                // display a messae through a view call
                this.view.DisplayMessage("Enter move (1-9): ");

                // get the move from the controller
                move = this.controller.getMove();

                // poll the controller for possible quit 
                if (this.controller.Quit)
                {
                    quit = true;
                    break;
                }
            }

            // update the board with the current move
            return b.Do_move(move);

        }
    }
}
