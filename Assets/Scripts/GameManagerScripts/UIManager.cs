using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour {

    public GameObject pauseBtn;
    public GameObject losePanel;
    public GameObject pausePanel;
    public Slider speedSlider;
    public Text scoreText;
   


    public void Lose()
    {
        pauseBtn.GetComponent<Image>().raycastTarget = false;
        scoreText.text= FindObjectOfType<GameScore>().Score.ToString();
        losePanel.GetComponent<Animator>().SetTrigger("LoseTrigger");
        Time.timeScale = 0;
        FindObjectOfType<AudioSelecting>().ChooseAudio(AudioTypes.lose);
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0;
        pausePanel.GetComponent<Animator>().SetTrigger("MoveTo");
        pauseBtn.GetComponent<Image>().raycastTarget = false;

        FindObjectOfType<AudioSelecting>().ChooseAudio(AudioTypes.click);
    }


    public void GoToMenuScene()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;

        FindObjectOfType<AudioSelecting>().ChooseAudio(AudioTypes.click);
    }


    public void ContinueTheGame()
    {
        Time.timeScale = 1;
        pausePanel.GetComponent<Animator>().SetTrigger("ReturnTo");
        pauseBtn.GetComponent<Image>().raycastTarget = true;

        FindObjectOfType<AudioSelecting>().ChooseAudio(AudioTypes.click);
    }
    public void RestartTheGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");

        FindObjectOfType<AudioSelecting>().ChooseAudio(AudioTypes.click);
    }
}
