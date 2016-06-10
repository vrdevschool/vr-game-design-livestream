using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public Text scoreText;
    public int MaxScore = 10;
    public int CurrentScore = 0;

    public ParticleSystem ps_YouWin;
    
    public void UpdateScore(int addedScoreAmount)
    {
        CurrentScore++;
        scoreText.text = "SCORE: " + CurrentScore.ToString();

        if(CurrentScore >= MaxScore)
        {
            YouWin();
        }
    }

    public void YouWin()
    {
        ps_YouWin.Emit(1000);
    }
}
