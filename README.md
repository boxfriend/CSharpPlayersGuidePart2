# C# Player's Guide Part 2
###### These are my solutions to the challenges in the second section of the book titled "Part 2: Object-Oriented Programming"
Info about the book including where to purchase can be found [here](https://csharpplayersguide.com/)

###### [Solutions for Part 1: The Basics](https://github.com/boxfriend/CSharpPlayersGuidePart1)

As with Part 1, some challenges are grouped together due to working with the same projects. I was also a bit looser with my personal challenge of not using anything the book hasn't described yet. Most instances of slightly breaking the challenge have comments explaining why I did so.

[Simula's Test](SimulasTest/Program.cs) - Use enums to determine the state of an object and cycle through valid state transitions

[Simula's Soup](SimulasSoup/Program.cs) - Use tuples and enums to create objects with selected properties

[Vin Fletcher's Arrow & Vin's Trouble & The Properties of Arrows & Arrow Factories](VinFletchersArrows/Program.cs) - Create a class to represent an Arrow object using properties, fields, and constructors to define the objects on creation. Also use static methods that will create specific types of arrow objects (factory methods)

### Catacombs of the class
##### Entering the Catacombs
[The Point](CatacombsOfTheClass/Point.cs) - Define a Point class with properties for X and Y with a parameterless ctor and one to define specific values for x and y

[The Color](CatacombsOfTheClass/Color.cs) - Define a Color class with R,G,B properties and static properties for specific colors

[The Card](CatacombsOfTheClass/Card.cs) - Define a Card class to represent cards in a deck and create instances for every individual card in the deck

[The Locked Door](CatacombsOfTheClass/Door.cs) - Similar to Simula's Test but using a class now and using a passcode from input to transition to unlocked state

[The Password Validator](CatacombsOfTheClass/PasswordValidator.cs) - Get input from the user and determine if the input matches specific criteria (validating a password)

##### The Chamber of Design
All three of these challenges were to create CRC design cards for the specified projects. I could have put more thought into these, but I was being lazy and also preparing for the final part of this level

[Rock-Paper-Scissors](CatacombsOfTheClass/RockPaperScissorsCRC.png), 
[15-Puzzle](15-PuzzleCRC.png), 
[Hangman](CatacombsOfTheClass/HangmanCRC.png)

##### Final Challenge of Catacombs of the Class
[Tic-Tac-Toe](TicTacToe/) - Build a simple Tic Tac Toe game using all of the knowledge gained so far through the book

[Packing Inventory & Labeling Inventory](PackingInventory/) - Create an InventoryItem base class and several derived classes and a Pack class to store an array of InventoryItem & override the .ToString() method in the base classes

[The Old Robot & Robotic Interface & Lists of Commands](TheOldRobot/) - Create a base for commands to be executed by an already existing Robot class & edit the classes to use interfaces instead of inheritance & finally edit the class to use a List instead of array

[Room Coordinates](RoomCoordinates/Coordinate.cs) - Create a struct to represent coordinates

[War Preparations](WarPreparations/Sword.cs) - Create a record that stores two enums representing a sword's material and gemstone

[Colored Items](ColoredItems/ColoredItem.cs) - Create some item classes and a generic ColoredItems class that will represent an item and a color

### The Fountain of Objects
[TheFountainOfObjects](TheFountainOfObjects/) - Culmination of all knowledge gained from the book so far to create the Fountain of Objects game. All six extra challenges are included in this

[The Robot Pilot](TheRobotPilot/Program.cs) - Modify Hunting the Manticore from part 1 to use the System.Random class to generate a random number instead of another player's input

[Time in the Cavern](TheFountainOfObjects/Program.cs) - Modify Fountain of Objects to use DateTime and TimeSpan to display how long player was in the caverns

[Lists of Commands](TheOldRobot/) - Described above in The Old Robot, added here simply for clarity since the challenge was so much later than the one it modified

And there we have it, Part 2 is completed. On to part 3!
