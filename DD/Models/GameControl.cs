namespace Models;

public class GameControl {

    //public GameControl(){}

    public int Id { get; set; }
    public int Players { get; set; } //1 - 4 
    public int GameTurn { get; set; } //1 - 4 for the standard 4 player game
    public string? p1Name { get; set; }
    public string? p2Name { get; set; }
    public string? p3Name { get; set; }
    public string? p4Name { get; set; }

    //Old position for each player will be stored locally for each player,
    //this will send new position data to each player via the database
    //Doubles are floats in unity
    public int P1mv { get; set; }
    public int P2mv { get; set; }
    public int P3mv { get; set; }
    public int P4mv { get; set; }
    public int P1fc { get; set; }
    public int P2fc { get; set; }
    public int P3fc { get; set; }
    public int P4fc { get; set; }

    //What kind of action, all actions will be kept in 4 different libraries
    public int Action { get; set; } //0 = No Action Yet, 1 = Melee, 2 = Spell, 3 = Self Skill, 4 = Self Spell
    public int ActionID { get; set; } //the Id for the action in a list
    public string? TargetName { get; set; }//Who is being targeted this turn

    //HP UI
    public int P1MaxHP { get; set; } 
    public int P2MaxHP { get; set; } 
    public int P3MaxHP { get; set; } 
    public int P4MaxHP { get; set; } 
    public int P1HP { get; set; } 
    public int P2HP { get; set; } 
    public int P3HP { get; set; } 
    public int P4HP { get; set; } 

    public int FinalDamage { get; set; } 

}