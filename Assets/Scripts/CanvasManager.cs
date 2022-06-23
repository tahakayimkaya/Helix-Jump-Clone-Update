using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelPassed;

    public GameObject gameOverPanel;
    public GameObject levelPassedPanel;

    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;
    public TextMeshProUGUI scoreText;

    public Slider gameProgressSlider;

    public static int numberOfPassedRings;
    public static int score = 0;
    public static int currentLevelIndex;

    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        numberOfPassedRings = 0;
        gameOver = levelPassed = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameProgress();
    }

    public void LevelPassed()
    {
        PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex + 1);
        SceneManager.LoadScene("SampleScene");
    }

    public void GameOver()
    {
        score = 0;
        SceneManager.LoadScene("SampleScene");
        //PlayerPrefs.DeleteAll();
    }

    public void GameProgress()
    {
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex + 1).ToString();

        int progress = numberOfPassedRings * 100 / FindObjectOfType<HelixManager>().numberOfRings;
        gameProgressSlider.value = progress;

        scoreText.text = score.ToString();
    }
}
