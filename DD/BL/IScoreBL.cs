//GetAllScoresAsync   GetScoreByIdAsync AddScore
namespace BL;

//traditionally IRepo
public interface IScoreBL
{

List<Scoreboard?> GetAllScores();
Task<Scoreboard?> GetScoreByIdAsync(int id);
object ChangeScoreInfo(Object entity);
void AddScore(Object entity);

}