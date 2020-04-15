/*
 * Class AIPlayer.
 * 
 * This class implements the abstract class Player regarding the interactions
 * of the AI. Here we are going to use a pre-trained Keras model which we will
 * load from file. It comes from an external project of which you may see 
 * more details at the following link: https://github.com/bsamseth/tictacNET
 * 
 * This model is far from perfect and wouldn't win a game unless the opponent
 * commits a wrong move, or sometimes more than one.
 * 
 * It remains a good starting point for future developments, anyway. 
 * 
 * Author: Nicolò Tambone 267259
 * 
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Tensorflow;
using static Tensorflow.Binding;
using Keras;
using Numpy;


namespace KerasTris
{
    class AIPlayer : Player
    {
        
        private Keras.Models.BaseModel model;

        // Contructor. Loads model from the current directory
        public AIPlayer()
        {
            string path = Directory.GetCurrentDirectory();
            model = Keras.Models.Model.LoadModel(path + "\\tictacNET.h5");
        }

        // Override implementation of abstract class' Make_move
        public override Board Make_move(Board b, out Boolean quit)
        {

            List<int> legalMoves = new List<int>();

            foreach (int i in b.Moves())
            {
                legalMoves.Add(i);
            }

            // Converts the internal representation to a list of 1 and 0 (int)
            List<int> listInputs = b.Bitboard_to_list(b.squares);

            listInputs.Add(b.Turn);

            int[,] inputs = new int[1,19];

            for(int i = 0; i < listInputs.Count; i++)
            {
                inputs[0, i] = listInputs[i];
            }

            // Call the model's Predict method.
            // This makes a prediction based on the current state of the board.
            // The 3rd parameter (verbose) is set to 0 to void undesired output
            var predict = this.model.Predict(inputs,null,0)[0];

            // now sort the output to get a vector of probabilities 
            // in ascending order
            var outputs = Numpy.np.argsort(predict);

            // output var quit is always false. It is supposed
            // the AI never requires to quit 
            quit = false;

            // scan the output vector backwards (it is ordered ascending)
            // and plays the highest rated move if it's legal
            for (int i = outputs.len - 1; i >= 0; i--)
            {
                int o = (int)outputs[i];
                int move = 1 << o;

                if (legalMoves.Contains(move))

                    return b.Do_move(move);

            }

            // return the updated board
            return b;

        }
    }
}
