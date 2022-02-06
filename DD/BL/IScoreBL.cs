//GetAllScoresAsync   GetScoreByIdAsync AddScore
namespace BL;

//traditionally IRepo
public interface IScoreBL
{

List<Scoreboard?> GetAllScores();

Task<Scoreboard?> GetScoreByIdAsync(string? userId);

void AddScore(Object entity);

}