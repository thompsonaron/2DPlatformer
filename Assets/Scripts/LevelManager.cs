using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    

    public float waitToRespawn;

    public int gemsCollected;

    public string levelToLoad;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gemsCollected = GemTracker.instance.GemsCount();
        UIController.instance.UpdateGemCountDisplay();
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCoroutine());
        
    }

    private IEnumerator RespawnCoroutine()
    {
        PlayerController.instance.gameObject.SetActive(false);
        AudioManager.instance.PlaySFX(8);

        yield return new WaitForSeconds(waitToRespawn - (1/UIController.instance.fadeSpeed));
        UIController.instance.FadeToBlack();
        yield return new WaitForSeconds((1f/UIController.instance.fadeSpeed)+ 0.2f);
        UIController.instance.FadeFromBlack();
        

        PlayerController.instance.gameObject.SetActive(true);

        PlayerController.instance.transform.position = CheckPointController.instance.spawnPoint;

        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;

        UIController.instance.UpdateHealthDisplay();
    }

    public void EndLevel()
    {
        StartCoroutine(EndLevelCoroutine());
        GemTracker.instance.AddGems(LevelManager.instance.gemsCollected);
        // TODO check
        PlayerPrefs.SetInt("topScore", LevelManager.instance.gemsCollected);
    }

    public IEnumerator EndLevelCoroutine()
    {
        PlayerController.instance.stopInput = true;

        CameraController.instance.stopFollow = true;

        UIController.instance.levelCompleteText.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + .25f);

        SceneManager.LoadScene(levelToLoad);
    }
}
