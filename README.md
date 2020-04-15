# KerasTris
A neural network plays a tic-tac-toe game implemented in C# and TensorFlow.NET

## Overview
KerasTris is a C# console application written to experiment with neural network models. It allows an human player to play tic-tac-toe against an AI driven opponent. The model of the neural network which enables the AI opponent is prebuilt and pretrained. It was originated by an external application (not included in this project) written in Python with Keras libraries and it is loaded in the application at runtime. Also this project is a benchwork for experimenting with TensorFlow.NET and Keras.NET.

## Overall Architecture
Although the complexity of the application is far from overwhelming, its architecture is heavily object-oriented and it is based on the MVC (Model-View-Controller) paradigm. Thus the project is grouped into three main components: a Model which encapsulates the states and the internal representation of the game, a View which organizes the visual representation of the game board, and the Controller, which gets the user input, interprets it and passes it to the Model. This allows for an abstract representation of the program, easing the maintainance and future improvements. The current simple console application may be improved, for example, by adding a graphical interface and thus implementing new code in the Controller and View sections, without worrying about the game engine.

The project classes and their relative MVC section are shown in the following diagram.

## Neural Network Architecture
As said before, the neural network's implementation is currently outside this project. KerasTris merely import a trained model developed in Python. The code of the model is reported here for reference.
```
model = tf.keras.Sequential()
model.add(tf.keras.layers.Dense(128, activation="relu", input_dim=X.shape[1]))
model.add(tf.keras.layers.Dropout(0.3))
model.add(tf.keras.layers.Dense(64, activation="relu"))
model.add(tf.keras.layers.Dropout(0.3))
model.add(tf.keras.layers.Dense(32, activation="relu"))
model.add(tf.keras.layers.Dropout(0.3))
model.add(tf.keras.layers.Dense(moves.shape[1], activation="softmax"))

model.compile(optimizer="adam", loss="categorical_crossentropy", metrics=["accuracy"])
```
## Training Data
The model has been trained with a set of data representing the board status respectively for player a, player b, unselected cells, turn and score. The dataset was made of about 4500 records of a csv file. An example of the training data is shown below.
```
1,0,1,0,1,0,0,1,0,0,1,0,1,0,1,0,0,0,0,0,0,0,0,0,1,0,1,1,1
1,0,1,0,1,0,0,0,0,0,1,0,1,0,1,0,0,0,0,0,0,0,0,0,1,1,1,0,1
1,0,1,0,1,1,0,0,0,0,1,0,1,0,0,1,1,0,0,0,0,0,0,0,0,0,1,0,1
```



