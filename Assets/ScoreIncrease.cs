using UnityEngine;
using UnityEngine.UI;

public class ScoreIncrease : MonoBehaviour
{
    public int playerScore;
    public Text playerScoretext;

    public void addscore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        playerScoretext.text = playerScore.ToString();
    }
}
