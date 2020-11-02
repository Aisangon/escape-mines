# Escape Mines Game

## Technologies
Project is created with:
* C# Console Application (.NET Core 3.1)
* Unit testing with MSTest

## General info
This game will navigate a turtle through a 2-dimensional grid with mines as obstacules and one exit point. 
The goal is for the turtle to find the exit without getting hit by a mine.
The application will read a `.txt` file containing the instructions for the game. <br> <br>
Line 1: Sets the dimenstions of the grid. <br>
Line 2: Sets the placement of the mines. <br>
Line 3: Sets the position of the exit. <br>
Line 4: Sets the initial position of the turtle. <br>
Line 5 onwards: Describes the movement of the turtle. `M` for Move, `L` for turn Left and `R` for turn Right. <br> <br>
The results of the game will be displayed in the output command line. <br>

## Setup

```
$ git clone https://github.com/Aisangon/escape-mines.git

Run the application in Visual Studio
```
