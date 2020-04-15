/*
 * This program implements a tic-tac-toe game as AI vs human.
 * It is implemented as an MVC solution (Model-View-Controller) where
 * the model is the board representation (class Board), the controller
 * is described by the abstract class Controller and the view by the
 * abstract class View.
 * 
 * Author: Nicolò Tambone 267259
 * 
 */
using System;
using Tensorflow;
using static Tensorflow.Binding;
using Keras;

namespace KerasTris
{
    class Program
    {
        static void Main(string[] args)
        {
            // create view instance
            View view = new ConsoleView();

            // create controller instance
            Controller controller = new ConsoleController();

            // represents the player for the current turn
            Player player;

            // create instance of the human player
            HumanPlayer huPlayer = new HumanPlayer(view, controller);

            // create instance of the AI player
            AIPlayer aiPlayer = new AIPlayer();

            // flag for quit request by the human player
            Boolean quit = false;

            // flag for endless game
            Boolean gameLoop = true;

            // start an indefinite loop which ends when the human player
            // decides to quit
            while (gameLoop)
            {
                // vector which stores the internal representation of the board
                int[] brd = { 0, 0 };

                // create board instance
                Board b = new Board(brd, 0, 0);

                // display the board through a view call
                view.DisplayBoard(b, true);

                // a counter for the played games
                int iGame = 1;

                // loop until the end of the current game.
                // a board is decided when either:
                // * a game ends with tie 
                // * a game is won by one player
                while (!b.Is_decided())
                {
                    // when game counter is odd, AI moves first
                    if (Convert.ToBoolean(iGame & 1))
                        player = aiPlayer;
                    else
                        player = huPlayer;

                    // the current player makes its move.
                    // gets in input the current board state
                    // returning the board state after the move
                    // and the state of the flag quit which may
                    // be raised only by the human player
                    b = player.Make_move(b, out quit);

                    // display the board on output only if the game
                    // was not interrupted. the board is shown 
                    // through a call to the current view
                    if (!quit)
                        view.DisplayBoard(b);

                    // set the flag for continuing the game
                    //gameLoop = (quit == 0) ? true : false;
                    gameLoop = !quit;

                    // increment the game counter
                    iGame += 1;
                }
            }
        }
    }
}
