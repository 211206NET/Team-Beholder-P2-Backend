//GetAllScoresAsync   GetScoreByIdAsync AddScore
namespace BL;

//traditionally IRepo
public interface IScoreBL
{

Task<Scoreboard?> GetAllScoresAsync();

Task<Scoreboard?> GetScoreByIdAsync(int scoreId);

void AddScore(Object entity);

}