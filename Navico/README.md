## Snake and Ladders game ##

### How to run the program ###

* Please restore all the Nuget Packages. I used some packages for the Unit Test and the Dependency Injection.
* Run the Console Application, I have set up some Console logs and Console write to see the progress of the game

### Assumptions made ###

* All the player share a dice
* The game happens between 2 computer players (configurable) without human interaction
* The information shown in the Console is merely for information purposes

### Areas of improvement ###

* Write more Unit Tests
* Have better tests for the Game class
* Setup a more flexible way for the dependency injection
* Handle errors and exceptions
* Fail fast where needed
* GameConfiguration to be read from somewhere else, e.g Json file
* GameBoard could have different strategies for validating the token moves
* GameBoard could have different strategies for moving the token
* Add human interaction to the game
