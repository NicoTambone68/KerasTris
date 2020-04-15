/*
  Class Board.
  This class is in charge of the internal representation of the game.
 
  Board represented by two bitboards, one for each player,
    where a set bit indicates that the given player has played a
    move on the corresponding square.

    Example:

        X|O|X
        -+-+-          CROSS        NOUGHT
        O|X|O   = [ 0b101010101, 0b010101010 ]
        -+-+-
        X|O|X* 
 
  Author: Nicolò Tambone 267259
  
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace KerasTris
{

    class Board
    {
        private const int Cross = 0;

        private const int Nought = 1;

        private static readonly int[] players = { Cross, Nought };

        // array of the winning configurations patterns converted to int
        private static readonly int[] WinningPatterns = { 448, 56, 7, 292, 146, 73, 273, 84 };

        // game turn
        private int turn;

        // game depth
        private int depth;

        public int Turn
        {
            get { return this.turn; }

            set { this.turn = value; }
        }

        // array containing the board representation
        public int[] squares = { 0, 0 };

        // constructor 
        public Board(int[] squares, int turn, int depth)
        {
            this.turn = turn;
            this.depth = depth;
            this.squares = squares;
        }

        // this method returns the score of the game
        // *  1 if the AI wins
        // * -1 if the human wins
        // *  0 if tie
        public int Score()
        {
            foreach (int player in players) {

                foreach(int pattern in WinningPatterns)
                {
                    if ((this.squares[player] & pattern) == pattern)

                        if (player == this.turn)
                            return 1;
                        else
                            return -1;
                }

            }
            return 0;
        }

        // return an array of int[a,b]
        // a == flag game over
        // b == score ( 1 || -1 || 0 )
        public int[] Is_decided_and_score()
        {
            int score = this.Score();

            Boolean gameOver = Convert.ToBoolean(score) || this.depth == 9;

            int[] arrayRet = { Convert.ToInt32(gameOver), score };

            return arrayRet;

        }

        // return true if the game is over.
        // game is over when either one or the other of this conditions occurs:
        // * all the 9 cells have been marked by the players (tie)
        // * a game is won by one player marking a row, a column or a diagonal
        public Boolean Is_decided()
        {
            int score = this.Score();

            int dpt = this.depth;

            return Convert.ToBoolean(score) || this.depth == 9;

        }

        // switch player
        public int Next_player()
        {
            return (this.turn == Nought) ? Cross : Nought;
        }

        // convert the internal board representation from an array of 0 and 1 (int)
        // to an integer value (binary to integer)
        //
        public System.Collections.Generic.IEnumerable<int> Moves()
        {
            int taken = this.squares[Cross] | this.squares[Nought];
            int square = 256;

            while (square > 0)
            {
                if (!Convert.ToBoolean(taken & square))
                    yield return square;

                square = square >> 1;
            }

            
        }

        // record a move made by a player to the internal board representation
        // return the board representation
        public Board Do_move(int move)
        {
            Board b = new Board(this.squares, this.Next_player(), this.depth + 1);

            b.squares[this.turn] |= move;

            return b;
        }

        // convert the internal binary representation of the board 
        // to a 2D human-readable character representation to be
        // used by the view
        public override string ToString()
        {
            String s = "";

            for(int i = 0; i < 9; i++)
            {
                if (Convert.ToBoolean(this.squares[Cross] & (1 << i)))
                    s += "X";
                else if (Convert.ToBoolean(this.squares[Nought] & (1 << i)))
                    s += "O";
                else
                    s += "-";
                if (i % 3 < 2)
                    s += "|";
                else if (i < 8)
                    s += "\n-----\n";
            }
            return s;
        }

        // convert the internal binary representation of the board
        // to the array of int representation.
        // it is the inverse of the method Moves()
        public List<int> Bitboard_to_list(int[] boardSquare)
        {
            List<int> squares = new List<int>();
            int square = 256;

            // Cross
            for (int i = 0; i < 9; i++)
            {
                squares.Add(Convert.ToInt32(square & boardSquare[Cross]));

                square = square >> 1;

            }

            square = 256;

            // Noughts
            for (int i = 0; i < 9; i++)
            {
                squares.Add(Convert.ToInt32(square & boardSquare[Nought]));

                square = square >> 1;

            }

            return squares;

        }

    }
}
