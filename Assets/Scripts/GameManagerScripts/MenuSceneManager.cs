using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour {

    public Slider rowSizeCheckSlider;
    public Slider columnSizeCheckSlider;
    public Text rowsCountText;
    public Text columnsCountText;
    public Text bestScoreText;
    private void Start()
    {
        GetOrCreateBestScore();
    }

    private void GetOrCreateBestScore()
    {
        bestScoreText.text = ((PlayerPrefs.HasKey("BestScore")) ? PlayerPrefs.GetInt("BestScore") : 0).ToString();
        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", 0);
        }
    }

    private void Update()
    {
        rowsCountText.text = rowSizeCheckSlider.value.ToString();
        columnsCountText.text = columnSizeCheckSlider.value.ToString();
    }

    public void LetsPlay()
    {
        GridCreator.countOfColumns = (int)columnSizeCheckSlider.value;
        GridCreator.countOfRows = (int)rowSizeCheckSlider.value;
        FindObjectOfType<Canvas>().GetComponent<Animator>().SetTrigger("ChangeSceneTrigger");
        columnSizeCheckSlider.enabled = false;
        rowSizeCheckSlider.enabled = false;
        StartCoroutine(ChangeScene());


        FindObjectOfType<AudioSelecting>().ChooseAudio(AudioTypes.click);
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Main");
    }

}
