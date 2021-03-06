# KerasTris
A neural network plays a tic-tac-toe game implemented in C# and TensorFlow.NET

## Overview and specification
KerasTris is a C# console application written to experiment with neural network models. It allows an human player to play tic-tac-toe against an AI driven opponent. The model of the neural network which enables the AI opponent is prebuilt and pretrained. It was originated by an external application (not included in this project) written in Python with Keras libraries and it is loaded in the application at runtime. Also this project is a benchwork for experimenting with TensorFlow.NET and Keras.NET.

## Problem Analysis
The application must provide a suitable user interface to represent the game board and receive input from the user. Moreover it must implement a game engine to act as the opponent to the human player. No specifications have been given about the user interface, so our choice is to keep everything as simple as possible. Thus the interface will be a simple character console. Nevertheless an object-oriented architecture will be implemented wisely in order to ease future improvements that will include a graphical interface. 

As for the algorithmic solution, many ways were possible. Since the tic-tac-toe game has a finite number of states and the universe of possible games is limited to something more than two hundred thousands, we may well have chosen an algorithm like minimax. Nevertheless we wanted to explore the possibilities of a simple Machine Learning model and cope with an unusual approach to a computational problem. 

## Overall Architecture
Although the complexity of the application is far from overwhelming, its architecture is heavily object-oriented and it is based on the MVC (Model-View-Controller) design pattern. Thus the project is grouped into three main components: a Model which encapsulates the states and the internal representation of the game, a View which organizes the visual representation of the game board, and the Controller, which gets the user input, interprets it and passes it to the Model. This allows for an abstract representation of the program, easing the maintainance and future improvements. Thus the implementation decouples the game abstract functionalities from their graphical representation and their actual input controls. The current simple console application may be improved, for example, by adding a graphical interface and thus implementing new code in the Controller and View sections, but leaving the game engine untouched. In the same way we may add new input devices, other than the keyboard, for example a mouse or a gamepad.

The project classes and their relative MVC section are shown in the following UML classes diagram.

![KerasTris UML Diagram](/KerasTrisUMLDiagram.png)


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
## Model Training
Model training has been done in different ways to check whether some improvements in performance may be achieved just by different training. The code for the model training is reported below. Many different models have been obtained changing either epochs or batch_size or both, sometimes leading to training sessions of more than 12 hours. Nevertheless no dramatic improvements were shown after that, compared to the ones from the basic training. 
```
model.fit(
    X_train,
    y_train,
    epochs=1000,
    batch_size=32,
    validation_data=(X_test, y_test),
    callbacks=[tensorboard_callback],
)
```
## Running the program
After compiling the code, the program can be launched just by running its executable, e.g.  KerasTris.exe  (on Windows). No parameters are required. The AI will always make the first move. To play the game is very intuitive: just enter a number from 1 to 9 which correspond to the cell you want to mark with a nought. 1 is the cell in the upper-left corner; 9 is the one in the lower-right corner. The user may choose to end the game at any time, just entering 'q' (for quit).

## Use cases

An UML diagram of the use cases is included here for reference.

![KerasTris UML Use Cases](/KerasTrisUMLUseCase.png)

## Performance Evaluation
Although the AI (which always moves first) behaves well on the opening, almost always choosing the center square, it declines on choice quality in the subsequent moves.
```
-|-|-
-----
-|X|-
-----
-|-|-
Enter move (1-9):
```
For example, an easy win on the third move is spoiled by the silly positioning on the 9th square.
```
O|O|-
-----
-|X|X
-----
-|-|X
Enter move (1-9):
```
At the current stage the model definitely underperforms and there's no way for the AI to win a game unless the human player does one or even more very bad moves.

## A note on possible future improvements
Some improvements may be achieved modifiyng the model, trying different optimizers and loss functions. But the most important one it would be training the neural network through a Monte Carlo Tree Search algorithm and adjusting the model's weight accordingly.

## Conclusions
C# can be used proficiently with TensorFlow.NET to build AI applications (beside native AI functionalities, which have however, limited features compared to the ones of TensorFlow). Nevertheless at this stage, the present application needs to be improved to show its actual potentiality.

## License
MIT License

## Author 
Nicolò Tambone 267259
