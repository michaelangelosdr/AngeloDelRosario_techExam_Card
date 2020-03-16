## Tech exam 
### Texas Holdem' Poker mini-game
### Email: michaelangelosdr@gmail.com

Assets used: Boardgamepack v2 from kennyassets.com 

To play the project on your browser, simply open this link: 
https://michaelangelosdr.github.io/AngeloDelRosario_techExam_Card/HTML5/index.html

# Code Objects
 * Playerhand.cs - the object representing a player's hand. 
 * Card - a card object.
 * Deck - a deck object containing the list of cards
 * Board - The board object represents where community cards are placed.

# Managers
 * TexasHoldemPokerManager.cs - is a statemachine that controls the flow of the game and at the same time has all the data neccesary for interaction such as the Deck. 
 * InterfaceManager.cs - Manages all UI elements in the game and contains references to each object's view. 
 * PokerHelper.cs - Contains helpful methods such as a Value convert and check hand strength. As well as other test methods. 

# States
 Since Poker is a turn based game, State pattern is perfect to implement here. 
 * Idle.cs - the state where the board and the hand is reset. 
 * Deal.cs - the state where the game shuffles the deck and distributes cards to player1, player2 and the board.
 * CheckResult.cs - the state where the game assigns each player's Hand result. 
 * CompResult.cs - The state where the game compares the result and determines the winning player. 

# View Objects 
 * PlayerInterface.cs - the monobehaviour that would have the references to the sprite game objects of the player. 
 * BoardInterface.cs - the monobehaviour that would containthe references for the sprites of the board. 

### Final Thoughts 

Doing the exam was fun and challenging.  
