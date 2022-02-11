//GetAllScoresAsync   GetScoreByIdAsync AddScore
namespace DL;

//traditionally IRepo
public interface IScoreRepo
{

List<Scoreboard?> GetAllScores();

Task<Scoreboard?> GetScoreByIdAsync(int id);

object ChangeScoreInfo(Object entity);

object AddScore(Object entity);

}