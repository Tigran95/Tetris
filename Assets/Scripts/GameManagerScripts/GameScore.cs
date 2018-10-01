using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameScore : MonoBehaviour {

    public int Score { get;private set; }

    public Text currentScoreText;
    public Text bestScoreText;

    private void Start()
    {
        ShowScores();
    }

	public void ChangeScore()
    {
        Score++;
        SaveScore();
        ShowScores();

        FindObjectOfType<AudioSelecting>().ChooseAudio(AudioTypes.destroyTiles);
    }

    private void SaveScore()
    {
        
            if (PlayerPrefs.GetInt("BestScore") < Score)
            {
                PlayerPrefs.DeleteKey("BestScore");
                PlayerPrefs.SetInt("BestScore", Score);
            }
    }

    private void ShowScores()
    {
        currentScoreText.text = Score.ToString();
        bestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
    }
}
