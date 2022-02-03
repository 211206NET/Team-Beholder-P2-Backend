//GetAllScoresAsync   GetScoreByIdAsync AddScore
namespace DL;

//traditionally IRepo
public interface IScoreRepo
{

List<Scoreboard?> GetAllScores();

Task<Scoreboard?> GetScoreByIdAsync(string userId);

object AddScore(Object entity);

}