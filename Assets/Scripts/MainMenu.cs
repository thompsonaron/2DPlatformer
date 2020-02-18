using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string startScene;

    public GameObject options;
    private bool optionsToggle = false;

    public GameObject levelSelect;
    private bool levelSelectToggle = false;

    public Text topScore;


    public void StartGame()
    {
        SceneManager.LoadScene(startScene);
    }

    public void OptionsToggle()
    {
        if (optionsToggle == false)
        {
            int score = PlayerPrefs.GetInt("topScore");
            topScore.text = score.ToString();
        }
        optionsToggle = !optionsToggle;
        options.SetActive(optionsToggle);
        
    }

    public void LevelSelect()
    {
        levelSelectToggle = !levelSelectToggle;
        levelSelect.SetActive(levelSelectToggle);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
