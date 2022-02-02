//GetAllScoresAsync   GetScoreByIdAsync AddScore
namespace DL;

//traditionally IRepo
public interface IScoreRepo
{

Task<Scoreboard?> GetAllScoresAsync();

Task<Scoreboard?> GetScoreByIdAsync(int scoreId);

void AddScore(Object entity);

}