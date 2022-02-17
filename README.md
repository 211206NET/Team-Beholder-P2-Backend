# Dungeons & Danger 1.0

## Project Description
Fight to the death in a battle royale. Connect to online games and participate in turn based combat. 
Your score is tracked on a leaderboard based on your cumulative progress. Your score enables special access
to the VIP area of the website.

## Tables
1. User
2. ScoreBoard
3. CharacterClasses
   1. Barbarian
   2. Cleric
   3. Paladin
   4. Ranger
   5. Wizard

4. CharacterAbilities
   1. Attack
   2. Heal
   3. Dodge
   4. Cast Spell
   5. etc.

5. CharacterStats
   1. Strength
   2. Dexterity
   3. Constitution
   4. Intelligence
   5. Wisdom
   6. Charisma
   7. Proficiency
   8. Initiative
   9. Armor Class
   10. HP
   11. Speed

## User Stories
- A user should be able to sign up for an account.
- A user should be able to see their score board.
- A user should be able kill his enemies.
- An admin should be able view all registered users.
- A user should be able to visit the special VIP tavern page if their score is high enough.

## MVP
- Log in function 
- Create a server connection
- Player’s results should persist to the database.
- Demo with rock, paper and scissor test
- Battle system

## Long Term Goal
- Complex battle system
- Score board
- Pick your own character
- Multiplayer function
        
## Tech Stack
- C#
- AWS
- Angular
- XUnit, Moq, Sonar cloud for testing and code analysis
- Node JS?
- Socket IO?

## Backburner
- Dungeon Map Generator
- Chat function
- Leaderboard
- Create and Save Characters
- Special Equipment?
- PVE, Coop
- Form Parties
- Form Guilds
- Truly Functional stats
- Buff/Debuff Abilities

## Contributors
- Matthew Wiese
- Connor Kobel
- Brayan Cordero
- Kevin Chen

## Getting Started
To run the application use the following steps:

- Install the Angular CLI to run the application with npm install -g @angular/cli
- Clone the repo git clone https://github.com/211206NET/Team-Beholder-P2-Backend.git
- Navigate to project folder and enter ng serve
