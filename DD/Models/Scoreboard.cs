namespace Models;

//UserId(PK/FK), GamesPlayed, Wins, Loses


public class Scoreboard {
    public int Id { get; set; }
    // public string? UserFirst {get;set;}
    // public string? UserSecond {get;set;}
    // public string? UserThird {get;set;}
    public string? Username {get;set;}
    public int GamesPlayed {get;set;}
    public int GamesWon {get;set;}
    public int TotalKills {get;set;}
}

